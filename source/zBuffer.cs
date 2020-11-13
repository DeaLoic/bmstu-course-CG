using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    static class ZBuffer
    {
        static public void Process(Bitmap bitmap, Scene scene)
        {
            int[][] Zbuf = null;
            InitBuf(ref Zbuf, bitmap.Width, bitmap.Height, int.MinValue);

            Color[][] imgPar = new Color[bitmap.Width][];
            for (int i = 0; i < bitmap.Width; i++)
            {
                imgPar[i] = new Color[bitmap.Height];
            }

            foreach (Object m in scene.GetObjects())
            {
                ProcessModel(Zbuf, bitmap, m, scene.camera);
            }
        }
        static private void InitBuf(ref int[][] buf, int w, int h, int value)
        {
            buf = new int[h][];
            for (int i = 0; i < h; i++)
            {
                buf[i] = new int[w];
                for (int j = 0; j < w; j++)
                    buf[i][j] = value;
            }
        }

        static private void ProcessModel(int[][] buffer, Bitmap image, Object o, Camera camera)
        {
            Color draw;
            foreach (PollygonFour pol in o.GetPollygonsFour())
            {
                PollygonFour polygon = new PollygonFour(camera.Proect(pol.A.Copy()),
                                           camera.Proect(pol.B.Copy()),
                                           camera.Proect(pol.C.Copy()),
                                           camera.Proect(pol.D.Copy()));
                polygon.CalculatePointsInside(image.Width, image.Height);
                draw = pol.color;
                foreach (Dot3d point in polygon.pointsInside)//new Dot3d[] { polygon.A, polygon.B, polygon.C, polygon.D })
                {
                    ProcessPoint(buffer, image, point, draw);
                }
            }
        }

        static private void ProcessPoint(int[][] buffer, Bitmap image, Dot3d point, Color color)
        {
            int h = image.Height;
            int w = image.Width;
            point = new Dot3d(point.X / point.W, point.Y / point.W, point.Z / point.W);
            if (!(point.X < 0 || point.X >= w || point.Y < 0 || point.Y >= h))
            {
                if (point.Z > buffer[(int)point.Y][(int)point.X])
                {
                    buffer[(int)point.Y][(int)point.X] = (int)point.Z;
                    image.SetPixel((int)point.X, (int)point.Y, color);
                }
            }
        }
    }
}
