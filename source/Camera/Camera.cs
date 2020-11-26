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
        Vector3d up = new Vector3d(0, 1, 0);
        EAngle view = new EAngle(0, 0, 0);
        Matrix4x4 transformToView = new Matrix4x4();
        double fov;
        double aspectRatio, cameraNear, cameraFar;
        double xScale;

        ViewFrustum viewFrustum;

        public Camera(Dot3d place, int fov = 90, double aspectRatio = (800 / (double)600), double cameraNear = 100, double cameraFar = 100000)
        {
            this.place = new Vector3d(place);
            this.fov = fov;
            this.aspectRatio = aspectRatio;
            this.cameraNear = cameraNear;
            this.cameraFar = cameraFar;
            this.xScale = 1 / Math.Tan(MathSupport.ToRadian(fov / 2));
            viewFrustum = new ViewFrustum(place, up, new Vector3d(0, 0, 0) - new Vector3d(place), fov, (int)(fov / aspectRatio), cameraNear, cameraFar);
            transformToView.Reset();
        }

        public Matrix4x4 GetView()
        {
            Vector3d vecDirection = view.ToVector();
            Vector3d vecCamRight = vecDirection.Cross(up).Normalized();
            Vector3d vecCamUp = vecCamRight.Cross(vecDirection);

            return new Matrix4x4(vecCamRight, vecCamUp, vecDirection, place);
        }

        public Matrix4x4 GetTransformToView()
        {
            return transformToView;
        }
        public Matrix4x4 GetProjectionDx()
        {
            Matrix4x4 m = new Matrix4x4();

            m.Reset();            
            m[0, 0] = xScale;
            m[1, 1] = m[0, 0];

            m[2, 2] = (cameraFar) / (cameraFar - cameraNear);
            m[3, 2] = -cameraNear * cameraFar / (cameraFar - cameraNear);

            m[2, 3] = 1;
            m[3, 3] = 0;
            
            return m;
        }

        public Matrix4x4 GetProjectionYou()
        {
            Matrix4x4 m = new Matrix4x4();

            m.Reset();
            m[0, 0] = xScale;
            m[1, 1] = m[0, 0];

            m[2, 2] = (cameraFar + cameraNear) / (cameraFar - cameraNear);
            m[3, 2] = 2 * cameraNear * cameraFar / (cameraFar - cameraNear);

            m[2, 3] = -1;
            m[3, 3] = 0;

            return m;
        }

        public Matrix4x4 GetProjectionSimple()
        {
            Matrix4x4 m = new Matrix4x4();

            m.Reset();
            m[2, 3] = -1 / (double)cameraNear;

            return m;
        }

        public Matrix4x4 GetLookAt()//Vector3d eye, Vector3d lookAt, Vector3d up)
        {
            Vector3d zaxis = (lookAt - place).Normalized();
            if (zaxis.Lenght == 0)
            {
                zaxis = new Vector3d(0, 0, -1);
            }
            Vector3d xaxis = up.Cross(zaxis).Normalized();
            Vector3d yaxis = xaxis.Cross(zaxis).Normalized();

            Matrix4x4 matrix = new Matrix4x4();
            matrix[0, 0] = xaxis.X; matrix[0, 1] = xaxis.Y; matrix[0, 2] = xaxis.Z; matrix[0, 3] = 0;// -xaxis.DotProduct(eye);
            matrix[1, 0] = yaxis.X; matrix[1, 1] = yaxis.Y; matrix[1, 2] = yaxis.Z; matrix[1, 3] = 0;//-yaxis.DotProduct(eye);
            matrix[2, 0] = zaxis.X; matrix[2, 1] = zaxis.Y; matrix[2, 2] = zaxis.Z; matrix[2, 3] = 0;// -zaxis.DotProduct(eye);
            matrix[3, 0] = -xaxis.DotProduct(place);         matrix[3, 1] = -yaxis.DotProduct(place);         matrix[3, 2] =  -zaxis.DotProduct(place);         matrix[3, 3] = 1;

            return matrix;
        }
        public void Move(Vector3d move)
        {
            Vector3d zaxis = (lookAt - place).Normalized();
            Vector3d xaxis = up.Cross(zaxis).Normalized();
            Vector3d yaxis = xaxis.Cross(zaxis).Normalized();

            place = place + (zaxis * move.Z + xaxis * move.X + yaxis * move.Y);

            var transform = new Matrix4x4();
            transform.SetTransfer(move.X, move.Y, move.Z);
            transformToView = transformToView * transform;
        }
        public void Rotate(double ox, double oy, double  oz, Dot3d rotateCenter = null)
        {
            //view.AddDegrees(ox, oy, oz);

            var transform = new Matrix4x4();
            transform.SetRotate(ox, oy, oz);
            transformToView = transformToView * transform;

            place = new Vector3d (transform.Apply(place.ToDot()));
        }

        public void Scale(double ko)
        {
        }

        public ViewFrustum GetTransformFrustum()
        {
            viewFrustum = new ViewFrustum(place.ToDot(), up, lookAt - place, (int)fov, (int)(fov / aspectRatio), cameraNear, cameraFar);
            return viewFrustum;
            // viewFrustum.Transform(GetView());
        }
    }
}
