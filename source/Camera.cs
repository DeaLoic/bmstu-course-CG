using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Camera
    {
        Dot3d place;
        int focus;
        int angleX;
        int angleY;
        Dot3d rotate;
        MatrixTransform transform = new MatrixTransform();
        double xScale, yScale;

        public Camera(Dot3d place, int angleX = 60, int angleY = 90, int focus = 30, int widthSee = 60)
        {
            this.place = place;
            this.focus = focus;
            this.angleX = angleX;
            this.angleY = angleY;
            this.yScale = 1.0 / Math.Tan(MathSupport.ToRadian(angleY / 2));
            this.xScale = yScale / (800 / 600);
            transform = new MatrixTransform();
            rotate = new Dot3d(0, 0, 0);
        }

        public void Move(int dx, int dy, int dz)
        {
            place.X += dx;
            place.Y += dy;
            place.Z += dz;
            focus += dz;

            MatrixTransform matrix = new MatrixTransform();
            matrix.SetTransfer(dx, dy, dz);
            transform = transform.MultiplyVinograd(matrix);
        }

        public void Rotate(int ox, int oy, int oz, Dot3d rotateCenter = null)
        {
            if (rotateCenter == null)
            {
                rotateCenter = place;
            }
            rotate.X += ox;
            rotate.Y += oy;
            rotate.Z += oz;
            MatrixTransform matrix = new MatrixTransform();
            matrix.SetRotate(ox, oy, oz);
            transform = transform.MultiplyVinograd(matrix);
        }

        public void Scale(double ko)
        {
            MatrixTransform matrix = new MatrixTransform();
            matrix.SetScaleGlobal(ko);
            transform = transform.MultiplyVinograd(matrix);
        }

        public Dot3d ApplyTransform(Dot3d dot)
        {
            return transform.Apply(dot);
        }
        public Dot3d Proect(Dot3d dot)
        {
            Dot3d newDot = ApplyTransform(dot);
            transform[0, 0] = xScale;
            transform[1, 1] = yScale;
            transform[2, 3] = 1 / focus;
            double z_f = 10000;
            transform[2, 2] = z_f / (z_f - focus);
            transform[3, 2] = transform[2, 2] * (-focus);

            return transform.Apply(newDot);
        }
    }
}
