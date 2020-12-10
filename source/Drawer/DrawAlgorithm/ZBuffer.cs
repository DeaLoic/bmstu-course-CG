using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerlinLandscape
{
    class ZBuffer : DrawAlgorithm
    {

        double[][] Zbuf = new double[0][];
        public override void Process(Bitmap bitmap, Scene scene)
        {
            long time, timeInit, timeGet, timeColor, timeTransform, timeProcess, timeNormilize;
            double timeMS;
            Stopwatch clock = new Stopwatch();

            clock.Restart();
            InitBuf(bitmap.Width, bitmap.Height, double.MaxValue);
            clock.Stop();
            timeInit = clock.Elapsed.Ticks;

            clock.Restart();
            Matrix4x4 mainMatrix = scene.GetMainTransform();
            ViewFrustum unTransformed = scene.camera.GetFrustum();
            Shader shader = new Shader(scene.lightSource, scene.camera.place.ToDot());
            clock.Stop();
            timeGet = clock.Elapsed.Ticks;

            foreach (Object m in scene.GetObjects())
            {
                clock.Restart();
                m.Colorize(shader);
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

                clock.Restart();
                ProcessModel(bitmap, transformedModel, mainMatrix, unTransformed, shader);
                clock.Stop();
                timeProcess = clock.Elapsed.Ticks;
                time = timeColor + timeGet + timeInit + timeProcess + timeTransform + timeNormilize;
                timeMS = time / 10000.0;
                Console.Write(timeMS);
                Console.Write("  ");
                Console.Write(timeColor / 10000.0);
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

        private void ProcessModel(Bitmap image, Object o, Matrix4x4 mainMatrix, ViewFrustum frustum, Shader shader)
        {
            Color draw;
            Stopwatch clock = new Stopwatch();
            long timeClip = 0, timeNormilize, timeCalculate, timeDraw, time;
            double timeMS = 0;
            Cutter window = new Cutter(new Dot3d[] { new Dot3d(-398, -298, -100), new Dot3d(398, -298, -100), new Dot3d(398, 298, -100), new Dot3d(-398, 298, -100) });
            foreach (PollygonDraw pol in o.GetPollygonsDraw())
            {
                
                PollygonDraw polygon = window.Clip(pol);
                if (polygon.Size < 3)
                {
                    continue;
                }


                clock.Restart();
                polygon.CalculatePointsInside(398, 298, -398, -298);
                clock.Stop();
                timeCalculate = clock.Elapsed.Ticks;

                //draw = pol.color;

                clock.Restart();
                foreach (Dot3d point in polygon.pointsInside)
                {
                    draw = Shader.GetAnswerColor(point.coeffColor, pol.Material, shader.Color);
                    ProcessPoint(image, point, draw);
                }
                clock.Stop();
                timeDraw = clock.Elapsed.Ticks;
                time = timeCalculate + timeClip + timeDraw;
                timeMS += time / 10000.0;
            }
        }

        private void ProcessPoint(Bitmap image, Dot3d point, Color color)
        {
            int x = (int)point.X;
            int y = (int)point.Y;
            x += 398;
            y += 298;

            if (point.Z <= Zbuf[y][x])
            {
                Zbuf[y][x] = point.Z;
                image.SetPixel(x, y, color);
            }
        }
    }
}
