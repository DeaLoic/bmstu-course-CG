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
        double focus;
        int angleX;
        int angleY;
        Dot3d rotate;
        double scale = 0;
        MatrixTransform transform = new MatrixTransform();
        double xScale, yScale;

        public Camera(Dot3d place, int angleX = 60, int angleY = 90, int focus = 30, int widthSee = 60)
        {
            this.place = place;
            this.focus = focus;
            this.angleX = angleX;
            this.angleY = angleY;
            this.yScale = 1.0 / Math.Tan(MathSupport.ToRadian(angleY / (double)2));
            this.xScale = 1;// yScale / (800 / (double)600);
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
            scale += ko;
        }

        public Dot3d ApplyTransform(Dot3d dot)
        {
            MatrixTransform matrix = new MatrixTransform();
            matrix.SetRotate(rotate.X, rotate.Y, rotate.Z);
            Dot3d newDot = matrix.Apply(dot);
            matrix.SetScaleGlobal(scale);
            newDot = matrix.Apply(newDot);
            matrix.SetTransfer(-place.X, -place.Y, -place.Z);

            return matrix.Apply(newDot);
        }
        public Dot3d Proect(Dot3d dot)
        {
            Dot3d newDot = ApplyTransform(dot);
            MatrixTransform matrix = new MatrixTransform();

            /*
            matrix[0, 0] = xScale;
            matrix[1, 1] = yScale;
            matrix[2, 3] = -1;
            double z_f = 1000;
            focus = 0.1;
            matrix[2, 2] = (z_f + focus) / (focus - z_f);
            matrix[3, 2] = (2 * focus * z_f) / (focus - z_f);
            matrix[3, 3] = 0;
            */
            /*
             matrix[0, 0] = xScale;
            matrix[1, 1] = yScale;
            matrix[2, 3] = -1 / (double)1;
            double z_f = -100000;
            focus = 1;
            matrix[2, 2] = z_f / (z_f - focus);
            matrix[3, 2] = matrix[2, 2] * (-focus);
            matrix[3, 3] = 0;
            */
            
            newDot.X /= newDot.W;
            newDot.Y /= newDot.W;
            newDot.Z /= newDot.W;

            focus = place.Z;
            newDot.X *= -100 / (focus - newDot.Z);
            newDot.Y *= -100 / (focus - newDot.Z);
            newDot.Z -= 10;
            

            return matrix.Apply(newDot);
        }
    }
}
