using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace PerlinLandscape
{
    class ZBuffer : DrawAlgorithm
    {
        double[][] Zbuf = new double[0][];
        Stopwatch clock1 = new Stopwatch();
        long timeRast = 0;
        public override double Process(Bitmap bitmap, Scene scene)
        {
            long time = 0, timeInit = 0, timeGet = 0, timeColor = 0, timeTransform = 0, timeProcess = 0, timeNormilize = 0;
            double timeMS = 0;
            timeRast = 0;
            Stopwatch clock = new Stopwatch();

            clock.Restart();
            InitBuf(bitmap.Width, bitmap.Height, double.MaxValue);
            clock.Stop();
            timeInit = clock.Elapsed.Ticks;

            clock.Restart();
            Matrix4x4 mainMatrix = scene.GetMainTransform();
            ViewFrustum unTransformed = scene.camera.GetFrustum();
            Shader shader = new Shader(scene.lightSource, scene.camera.place.ToDot());
            shader.isPolygonColorized = scene.isPolygonColorized;
            clock.Stop();
            timeGet = clock.Elapsed.Ticks;

            foreach (Object m in scene.GetObjects())
            {
                clock.Restart();
                m.Colorize(shader, shader.isPolygonColorized);
                clock.Stop();
                timeColor = clock.Elapsed.Ticks;

                clock.Restart();
                Object transformedModel = m.Transform(mainMatrix);
                clock.Stop();
                timeTransform = clock.Elapsed.Ticks;

                clock.Restart();
                transformedModel.Normilize();
                clock.Stop();
                timeNormilize = clock.Elapsed.Ticks;
                transformedModel.SetShift(398, 298, 0);

                clock.Restart();
                ProcessModel(bitmap, transformedModel, mainMatrix, unTransformed, shader);
                clock.Stop();
                timeProcess = clock.Elapsed.Ticks;

                /*
                clock.Restart();
                for (int i = 0; i < bitmap.Height; i++)
                {
                    for (int j = 0; j < bitmap.Width; j++)
                    {
                        if (Zbuf[i][j] < double.MaxValue)
                        {
                            bitmap.SetPixel(j, i, ZbufColor[i][j]);
                        }
                    }
                }
                clock.Stop();
                timeDraw = clock.Elapsed.Ticks;
                */
                time = timeColor + timeGet + timeInit + timeProcess + timeTransform + timeNormilize;
                timeMS = time / 10000.0;

            }
            Console.Write(timeMS);
            Console.Write("  ");
            Console.Write(timeColor / 10000.0);
            Console.Write("  ");
            Console.Write(timeProcess / 10000.0);
            Console.Write("  ");
            Console.Write(timeRast / (double)time);
            Console.WriteLine("  ");
            return timeRast / (double)time;
        }
        public override double GetZ(int x, int y)
        {
            try
            {
                return Zbuf[x - 1][y - 1];
            }
            catch
            {
                return int.MinValue;
            }
        }
        private void InitBuf(int w, int h, double value)
        {
            int a = 0;
            if (Zbuf.Length == 0)
            {
                Zbuf = new double[h][];
                a = 1;
            }
            for (int i = 0; i < h; i++)
            {
                if (a == 1)
                {
                    Zbuf[i] = new double[w];
                }
                for (int j = 0; j < w; j++)
                {
                    Zbuf[i][j] = value;
                }
            }
        }

        private void ProcessPolygon(object paramsObj)
        {
            ParametersForPolygon paramses = (ParametersForPolygon)paramsObj;
            for (int i = paramses.polStart; i < paramses.polEnd; i++)
            {
                PollygonDraw polygon = paramses.window.Clip(paramses.pollygons[i]);
                if (polygon.Size < 3)
                {
                    return;
                }
                polygon.CalculatePointsInside(798, 598);

                Color draw = paramses.pollygons[i].color;

                foreach (Dot3d point in polygon.pointsInside)
                {
                    if (!paramses.shader.isPolygonColorized)
                    {
                    clock1.Restart();
                        draw = Shader.GetAnswerColor(point.coeffColor, paramses.pollygons[i].Material, paramses.shader.Color);
                clock1.Stop();
                timeRast += clock1.Elapsed.Ticks;
                    }
                    ProcessPoint(paramses.image, point, draw, paramses.mutex);
                }
            }
        }

        private void ProcessModel(Bitmap image, Object o, Matrix4x4 mainMatrix, ViewFrustum frustum, Shader shader)
        {
            Color draw;
            Stopwatch clock = new Stopwatch();
            long timeClip = 0, timeNormilize, timeCalculate, timeDraw, time;
            double timeMS = 0;
            Cutter window = new Cutter(new Dot3d[] { new Dot3d(0, 0, -100), new Dot3d(798, 0, -100), new Dot3d(798, 598, -100), new Dot3d(0, 598, -100) });
            PollygonDraw[] polygons = o.GetPollygonsDraw();
            Thread[] threads = new Thread[1];
            Mutex mutex = new Mutex(false);
            int step = polygons.Length / 1;
            int polStart = 0, polEnd = 0;
            for (int i = 0; i < 0; i++)
            {
                threads[i] = new Thread(ProcessPolygon);
                threads[i].Start(new ParametersForPolygon(image, polygons, polStart, polStart + step, window, mutex, shader));
                polStart += step;
            }
            threads[0] = new Thread(ProcessPolygon);
            threads[0].Start(new ParametersForPolygon(image, polygons, polStart, polygons.Length, window, mutex, shader));

            for (int i = 0; i < 1; i++)
            {
                threads[i].Join();
            }
        }

        private void ProcessPoint(Bitmap image, Dot3d point, Color color, Mutex mutex)
        {
            int x = (int)point.X;
            int y = (int)point.Y;

            if (point.Z <= Zbuf[y][x])
            {
                Zbuf[y][x] = point.Z;
                image.SetPixel(x, y, color);
            }
        }
    }
}
