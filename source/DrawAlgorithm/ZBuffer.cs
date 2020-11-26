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
        public override void Process(Bitmap bitmap, Scene scene, int typeView = 0)
        {
            int[][] Zbuf = null;
            InitBuf(ref Zbuf, bitmap.Width, bitmap.Height, int.MinValue);
            Matrix4x4 mainMatrix = scene.GetMainTransform(typeView);
            ViewFrustum viewFrustum = scene.GetCameraFrustum();
            Shader shader = new Shader(scene.lightSource, scene.camera.place.ToDot());
            foreach (Object m in scene.GetObjects())
            {
                ProcessModel(Zbuf, bitmap, m, mainMatrix, viewFrustum, shader);
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

        private void ProcessModel(int[][] buffer, Bitmap image, Object o, Matrix4x4 transform, ViewFrustum frustum, Shader shader)
        {
            Color draw;
            foreach (PollygonDraw pol in o.GetPollygonsDraw())
            {
                PollygonDraw polygon = frustum.Clip(pol);
                polygon.Transform(transform);
                polygon.Normilize();
                polygon.CalculatePointsInside(image.Width / 2, image.Height / 2, -image.Width / 2, -image.Height / 2);
                draw = shader.GetColorSimple(pol);
                foreach (Dot3d point in polygon.pointsInside)
                {
                    ProcessPoint(buffer, image, point, draw);
                }
            }
        }

        private void ProcessPoint(int[][] buffer, Bitmap image, Dot3d point, Color color)
        {
            int h = image.Height;
            int w = image.Width;
            
            point = new Dot3d(point.X / point.W + image.Width / 2, point.Y / point.W + image.Height / 2, point.Z / point.W);
            
            if (!(point.X < 0 || point.X >= w || point.Y < 0 || point.Y >= h || double.IsNaN(point.X) || double.IsNaN(point.Y)))// || point.Z > 1 || point.Z < 0))
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
