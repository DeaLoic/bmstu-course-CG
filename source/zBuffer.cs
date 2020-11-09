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
            foreach (PollygonFour polygon in o.GetPollygonsFour())
            {
                polygon.CalculatePointsInside(image.Width, image.Height);
                draw = Color.FromArgb(Math.Abs(polygon.A.Z) % 255, 0, 0);
                foreach (Dot3d point in polygon.pointsInside)
                {
                    ProcessPoint(buffer, image, camera.GetTransform(point), draw);
                }
            }
        }

        static private void ProcessPoint(int[][] buffer, Bitmap image, Dot3d point, Color color, int w = 1000, int h = 500)
        {
            int hDiv2 = image.Height / 2;
            int wDiv2 = image.Width / 2;
            if (!(point.X < -wDiv2 || point.X > wDiv2 || point.Y < -hDiv2 || point.Y > hDiv2))
            {
                if (point.Z > buffer[point.Y + hDiv2][point.X + wDiv2])
                {
                    buffer[point.Y + hDiv2][point.X + wDiv2] = point.Z;
                    image.SetPixel(point.X + wDiv2, point.Y + hDiv2, color);
                }
            }
        }
    }
}
