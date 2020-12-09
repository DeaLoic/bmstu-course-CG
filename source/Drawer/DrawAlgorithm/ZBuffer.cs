using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerlinLandscape
{
    class ZBuffer : DrawAlgorithm
    {
        double[,] Zbuf = new double[0, 0];

        public override void Process(Bitmap bitmap, Scene scene)
        {
            InitBuf(bitmap.Width, bitmap.Height, int.MaxValue);
            Matrix4x4 mainMatrix = scene.GetMainTransform();
            Matrix4x4 viewMatrix = scene.camera.GetLookAt();
            Matrix4x4 projectMatrix = scene.camera.GetProjectionSimple();

            ViewFrustum unTransformed = scene.camera.GetFrustum();
            ViewFrustum viewFrustum = scene.GetCameraFrustum();
            Shader shader = new Shader(scene.lightSource, scene.camera.place.ToDot());
            foreach (Object m in scene.GetObjects())
            {
                m.Colorize(shader);
                Object transformedModel = m.Transform(mainMatrix);
                ProcessModel(Zbuf, bitmap, transformedModel, mainMatrix, unTransformed, shader);
            }
        }
        public override double GetZ(int x, int y)
        {
            try
            {
                return Zbuf[x - 1, y - 1];
            }
            catch
            {
                return int.MinValue;
            }
        }
        private void InitBuf(int w, int h, double value)
        {
            Zbuf = new double[h, w];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    Zbuf[i, j] = value;
                }
            }
        }

        private void ProcessModel(double[,] buffer, Bitmap image, Object o, Matrix4x4 mainMatrix, ViewFrustum frustum, Shader shader)
        {
            Color draw;
            foreach (PollygonDraw pol in o.GetPollygonsDraw())
            {
                PollygonDraw polygon = frustum.Clip(pol);
                polygon.Normilize();
                polygon.CalculatePointsInside(image.Width, image.Height, -image.Width, -image.Height);
                //draw = Shader.GetAnswerColor((pol.GetDots()[0].coeffColor + pol.GetDots()[1].coeffColor + pol.GetDots()[2].coeffColor + pol.GetDots()[3].coeffColor) / 4, pol.Material, shader.Color);
                foreach (Dot3d point in polygon.pointsInside)
                {
                    draw = Shader.GetAnswerColor(point.coeffColor, pol.Material, shader.Color);
                    ProcessPoint(buffer, image, point, draw);
                }
            }
        }

        private void ProcessPoint(double[,] buffer, Bitmap image, Dot3d point, Color color)
        {
            int h = image.Height;
            int w = image.Width;

            point = new Dot3d(point.X / point.W + w / 2, point.Y / point.W + h / 2, point.Z / point.W);
            
            if (!(point.X < 0 || point.X >= w || point.Y < 0 || point.Y >= h || double.IsNaN(point.X) || double.IsNaN(point.Y)))// || point.Z > 1 || point.Z < 0))
            {
                if (point.Z <= buffer[(int)point.Y, (int)point.X])
                {
                    buffer[(int)point.Y, (int)point.X] = point.Z;
                    image.SetPixel((int)point.X, (int)point.Y, color);
                }
                double a = buffer[(int)point.Y, (int)point.X];
            }
        }
    }
}
