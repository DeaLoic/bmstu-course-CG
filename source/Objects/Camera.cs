using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Camera
    {
        public Vector3d place;
        public Vector3d eye = new Vector3d();
        public Vector3d lookAt = new Vector3d(0, 0, 0);
        EAngle view = new EAngle(0, 0, 0);
        double fov;
        double aspectRatio, cameraNear, cameraFar;
        double xScale;


        public Camera(Dot3d place, int fov = 90, double aspectRatio = (800 / (double)600), double cameraNear = 0.1, double cameraFar = 10000)
        {
            this.place = new Vector3d(place);
            this.fov = fov;
            this.aspectRatio = aspectRatio;
            this.cameraNear = cameraNear;
            this.cameraFar = cameraFar;
            this.xScale = 1 / Math.Tan(MathSupport.ToRadian(fov / 2));
        }

        public Matrix4x4 GetView()
        {
            Vector3d vecDirection = view.ToVector();
            Vector3d vecUp = new Vector3d(0, 1, 0);

            Vector3d vecCamRight = vecDirection.Cross(vecUp).Normalized();
            Vector3d vecCamUp = vecCamRight.Cross(vecDirection);

            return new Matrix4x4(vecCamRight, vecCamUp, vecDirection, place);
        }
        public Matrix4x4 GetProjection()
        {
            Matrix4x4 m = new Matrix4x4();

            m.Reset();
            m[2, 3] = -1 / (double)100;
            /*
            m[0, 0] = xScale * 100;
            m[1, 1] = m[0, 0];

            m[2, 2] = (cameraFar + cameraNear) / (cameraFar - cameraNear);
            m[3, 2] = 2 * cameraNear * cameraFar / (cameraFar - cameraNear);

            m[2, 3] = -1 / (double)100;
            m[3, 3] = 0;
            */
            return m;
        }

        public Matrix4x4 GetLookAt()//Vector3d eye, Vector3d lookAt, Vector3d up)
        {
            Vector3d eye = place;
            Vector3d up = new Vector3d(0, 1, 0);

            Vector3d zaxis = (eye - lookAt).Normalized();
            Vector3d xaxis = up.Cross(zaxis).Normalized();
            Vector3d yaxis = xaxis.Cross(zaxis).Normalized();

            Matrix4x4 matrix = new Matrix4x4();
            matrix[0, 0] = xaxis.X; matrix[0, 1] = xaxis.Y; matrix[0, 2] = xaxis.Z; matrix[0, 3] = 0;//-xaxis.DotProduct(eye);
            matrix[1, 0] = yaxis.X; matrix[1, 1] = yaxis.Y; matrix[1, 2] = yaxis.Z; matrix[1, 3] = 0;//-yaxis.DotProduct(eye);
            matrix[2, 0] = zaxis.X; matrix[2, 1] = zaxis.Y; matrix[2, 2] = zaxis.Z; matrix[2, 3] = 0;// -zaxis.DotProduct(eye);
            matrix[3, 0] = 0;         matrix[3, 1] = 0;         matrix[3, 2] = 0;         matrix[3, 3] = 1;

            return matrix;
        }
    public void Move(Vector3d move)
        {
            place += move;
        }
        public void Rotate(int ox, int oy, int oz, Dot3d rotateCenter = null)
        {
            view.AddDegrees(ox, oy, oz);
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
