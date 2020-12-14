using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerlinLandscape
{
    class ZBuffer : DrawAlgorithm
    {

        double[][] Zbuf = new double[0][];
        Stopwatch clock = new Stopwatch();
        long timeDraw = 0;
        public override void Process(Bitmap bitmap, Scene scene)
        {
            long time, timeInit, timeGet, timeColor, timeTransform, timeProcess, timeNormilize;
            double timeMS;

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
                timeDraw = 0;
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

                Stopwatch clock1 = new Stopwatch();
                clock1.Restart();
                ProcessModel(bitmap, transformedModel, mainMatrix, unTransformed, shader);
                clock1.Stop();
                timeProcess = clock1.Elapsed.Ticks;
                time = timeColor + timeGet + timeInit + timeProcess + timeTransform + timeNormilize;
                timeMS = timeDraw / 10000.0;
                Console.Write(timeMS);
                Console.Write("  ");
                Console.Write(time / 10000.0);
                Console.Write("  ");
                Console.Write(timeProcess / 10000.0);
                Console.WriteLine("  ");
            }
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
                    Zbuf[i][j] = value;
            }
        }

        /*
        private void ProcessPolygon(Bitmap image, Object o, Matrix4x4 mainMatrix, ViewFrustum frustum, Shader shader)
        {
            for (int i = paramses.polStart; i < paramses.polEnd; i++)
            {
                PollygonDraw polygon = window.Clip(paramses.pollygons[i]);
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
                        draw = Shader.GetAnswerColor(point.coeffColor, paramses.pollygons[i].Material, paramses.shader.Color);
                    }
                    ProcessPoint(paramses.image, point, draw);
                }
            }
        }
        */

        private void ProcessModel(Bitmap image, Object o, Matrix4x4 mainMatrix, ViewFrustum frustum, Shader shader)
        {
            Color draw;
            Cutter window = new Cutter(new Dot3d[] { new Dot3d(0, 0, -100), new Dot3d(798, 0, -100), new Dot3d(798, 598, -100), new Dot3d(0, 598, -100) });

            foreach (PollygonDraw pol in o.GetPollygonsDraw())
            {
                PollygonDraw polygon = window.Clip(pol);
                if (polygon.Size < 3)
                {
                    return;
                }
                polygon.CalculatePointsInside(798, 598);

                draw = pol.color;

                foreach (Dot3d point in polygon.pointsInside)
                {
                    if (!shader.isPolygonColorized)
                    {
                        draw = Shader.GetAnswerColor(point.coeffColor, pol.Material, shader.Color);
                    }
                    ProcessPoint(image, point, draw);
                }
            }
        }

        private void ProcessPoint(Bitmap image, Dot3d point, Color color)
        {
            int x = (int)point.X;
            int y = (int)point.Y;

            if (point.Z <= Zbuf[y][x])
            {
                Zbuf[y][x] = point.Z;
                clock.Restart();
                image.SetPixel(x, y, color);
                clock.Stop();
                timeDraw += clock.Elapsed.Ticks;
            }
        }
    }
}
