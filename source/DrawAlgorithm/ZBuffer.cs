using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class ZBuffer : DrawAlgorithm
    {
        public override void Process(Bitmap bitmap, Scene scene)
        {
            int[][] Zbuf = null;
            InitBuf(ref Zbuf, bitmap.Width, bitmap.Height, int.MinValue);
            Matrix4x4 mainMatrix = scene.GetMainTransform();
            foreach (Object m in scene.GetObjects())
            {
                ProcessModel(Zbuf, bitmap, m, mainMatrix);
                continue;
                var a = m.GetPollygonsFour()[4];
                var b = m.GetPollygonsFour()[5];

                DrawLine(bitmap, mainMatrix.Apply(a.A), mainMatrix.Apply(a.B));
                DrawLine(bitmap, mainMatrix.Apply(a.C), mainMatrix.Apply(a.B));
                DrawLine(bitmap, mainMatrix.Apply(a.C), mainMatrix.Apply(a.D));
                DrawLine(bitmap, mainMatrix.Apply(a.A), mainMatrix.Apply(a.D));
                DrawLine(bitmap, mainMatrix.Apply(b.A), mainMatrix.Apply(b.B));
                DrawLine(bitmap, mainMatrix.Apply(b.C), mainMatrix.Apply(b.B));
                DrawLine(bitmap, mainMatrix.Apply(b.C), mainMatrix.Apply(b.D));
                DrawLine(bitmap, mainMatrix.Apply(b.A), mainMatrix.Apply(b.D));
                DrawLine(bitmap, mainMatrix.Apply(a.A), mainMatrix.Apply(b.C));
                DrawLine(bitmap, mainMatrix.Apply(a.B), mainMatrix.Apply(b.B));
                DrawLine(bitmap, mainMatrix.Apply(a.C), mainMatrix.Apply(b.A));
                DrawLine(bitmap, mainMatrix.Apply(a.D), mainMatrix.Apply(b.D));
            }
        }
        private void DrawLine(Bitmap bitmap, Dot3d first, Dot3d second)
        {
            first.X += 400;
            second.X += 400;
            first.Y += 300;
            second.Y += 300;

            if (!(first.X < 0 || first.X >= 800 || first.Y < 0 || first.Y >= 600 || double.IsNaN(first.X) || double.IsNaN(first.Y)) &&
                !(second.X < 0 || second.X >= 800 || second.Y < 0 || second.Y >= 600 || double.IsNaN(second.X) || double.IsNaN(second.Y)))
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawLine(new Pen(Color.Black), (float)first.X, (float)first.Y, (float)second.X, (float)second.Y);
            }
        }
        private void InitBuf(ref int[][] buf, int w, int h, int value)
        {
            buf = new int[h][];
            for (int i = 0; i < h; i++)
            {
                buf[i] = new int[w];
                for (int j = 0; j < w; j++)
                    buf[i][j] = value;
            }
        }

        private void ProcessModel(int[][] buffer, Bitmap image, Object o, Matrix4x4 transform)
        {
            Color draw;
            foreach (PollygonFour pol in o.GetPollygonsFour())
            {
                PollygonFour polygon = new PollygonFour(transform.Apply(pol.A),
                                                        transform.Apply(pol.B),
                                                        transform.Apply(pol.C),
                                                        transform.Apply(pol.D));

                polygon.CalculatePointsInside(image.Width / 2, image.Height / 2, -image.Width / 2, -image.Height / 2);
                draw = pol.color;
                foreach (Dot3d point in polygon.pointsInside)//new Dot3d[] { polygon.A, polygon.B, polygon.C, polygon.D })
                {
                    ProcessPoint(buffer, image, point, draw);
                }
            }
        }

        private void ProcessPoint(int[][] buffer, Bitmap image, Dot3d point, Color color)
        {
            int h = image.Height;
            int w = image.Width;
            /*
            Dot3d newPoint = new Dot3d(point.X / point.W + image.Width / 2, point.Y / point.W + image.Height / 2, point.Z / point.W);
            if (!(newPoint.X < 0 || newPoint.X >= w || newPoint.Y < 0 || newPoint.Y >= h))
            {
                if (newPoint.Z > buffer[(int)newPoint.Y][(int)newPoint.X])
                {
                    buffer[(int)newPoint.Y][(int)newPoint.X] = (int)newPoint.Z;
                    image.SetPixel((int)newPoint.X, (int)newPoint.Y, color);
                }
            }
            */
            
            point = new Dot3d(point.X / point.W + image.Width / 2, point.Y / point.W + image.Height / 2, point.Z / point.W);
            
            if (!(point.X < 0 || point.X >= w || point.Y < 0 || point.Y >= h || double.IsNaN(point.X) || double.IsNaN(point.Y)))
            {
                if (point.Z >= buffer[(int)point.Y][(int)point.X])
                {
                    buffer[(int)point.Y][(int)point.X] = (int)point.Z;
                    image.SetPixel((int)point.X, (int)point.Y, color);
                }
            }
        }
    }
}
