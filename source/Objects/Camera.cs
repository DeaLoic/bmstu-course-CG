using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Camera
    {
        Vector3d place;
        EAngle view = new EAngle(0, 0, 0);
        double fov;
        double aspectRatio, cameraNear, cameraFar;


        public Camera(Dot3d place, int fov = 90, double aspectRatio = (800 / 600), double cameraNear = 0.1, double cameraFar = 1000)
        {
            this.place = new Vector3d(place);
            this.fov = fov;
            this.aspectRatio = aspectRatio;
            this.cameraNear = cameraNear;
            this.cameraFar = cameraFar;
        }

        public void Move(Vector3d move)
        {

            place += move;
        }

        public Matrix4x4 GetView()
        {
            Vector3d vecDirection = view.ToVector();
            Vector3d vecUp = new Vector3d(0, 1, 0);

            Vector3d vecCamRight = vecDirection.Cross(vecUp).Normalized();
            Vector3d vecCamUp = vecCamRight.Cross(vecDirection);

            return new Matrix4x4(vecCamRight, vecCamUp, -vecDirection, place).InvertedTR();
        }
        public Matrix4x4 GetProjection()
        {
            double flTanThetaOver2 = Math.Tan(MathSupport.ToRadian(fov / 2));

            Matrix4x4 m = new Matrix4x4();

            m.Reset();

            // X and Y scaling
            m[0, 0] = 1 / flTanThetaOver2;
            m[1, 1] = aspectRatio / flTanThetaOver2;

            // Z coordinate makes z -1 when we're on the near plane and +1 on the far plane
            m[2, 2] = (cameraNear + cameraFar) / (cameraNear - cameraFar);
            m[3, 2] = 2 * cameraNear * cameraFar / (cameraNear - cameraFar);

            // W = -1 so that we have [x y z -z], a homogenous vector that becomes [-x/z -y/z -1] after division by w.
            m[2, 3] = 1;

            // Must zero this out, the identity has it as 1.
            m[3, 3] = 1;

            return m;
        }
        public void Rotate(int ox, int oy, int oz, Dot3d rotateCenter = null)
        {
        }

        public void Scale(double ko)
        {
            
        }

        public Dot3d ApplyTransform(Dot3d dot)
        {/*
            Matrix4x4 matrix = new Matrix4x4();
            matrix.SetRotate(rotate.X, rotate.Y, rotate.Z);
            Dot3d newDot = matrix.Apply(dot);
            matrix.SetScaleGlobal(scale);
            newDot = matrix.Apply(newDot);
            matrix.SetTransfer(-place.X, -place.Y, -place.Z);

            return matrix.Apply(newDot);
            */
            return dot;
        }
        public Dot3d Proect(Dot3d dot)
        {
            Dot3d newDot = ApplyTransform(dot);
            Matrix4x4 matrix = new Matrix4x4();

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

            int focus = 2;
            newDot.X *= -100 / (focus - newDot.Z);
            newDot.Y *= -100 / (focus - newDot.Z);
            newDot.Z -= 10;
            

            return matrix.Apply(newDot);
        }
    }
}
