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
        double fov; // in radians
        double aspectRatio, cameraNear, cameraFar;
        double xScale;
        double yScale;

        ViewFrustum viewFrustum;

        public Camera(Dot3d place, int widthWindow = 800, double aspectRatio = (800 / (double)600), double cameraNear = 100, double cameraFar = 100000)
        {
            this.place = new Vector3d(place);
            this.fov = Math.Atan(cameraNear / (widthWindow / 2.0));
            this.aspectRatio = aspectRatio;
            this.cameraNear = cameraNear;
            this.cameraFar = cameraFar;
            lookAt = new Vector3d(0, 0, 0);
            this.xScale = ((widthWindow / 2) / cameraNear);
            viewFrustum = new ViewFrustum(place, up, new Vector3d(0, 0, 0) - new Vector3d(0, 0, -cameraNear), fov, (fov / aspectRatio), cameraNear, cameraFar);
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
            m[3, 2] = 0;// -cameraNear * cameraFar / (cameraFar - cameraNear);

            m[2, 3] = 1 / cameraNear;
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
            m[2, 3] = 1 / (double)cameraNear;
            m[0, 0] = xScale;
            m[1, 1] = xScale;

            return m;
        }

        public Matrix4x4 GetLookAt()//Vector3d eye, Vector3d lookAt, Vector3d up)
        {
            Vector3d zaxis = (lookAt - place).Normalized();
            if (zaxis.Length == 0)
            {
                zaxis = new Vector3d(0, 0, -1);
            }
            Vector3d xaxis = up.Cross(zaxis).Normalized();
            Vector3d yaxis = zaxis.Cross(xaxis).Normalized();

            Matrix4x4 matrix = new Matrix4x4();
            /*
            matrix[0, 0] = xaxis.X; matrix[0, 1] = xaxis.Y; matrix[0, 2] = xaxis.Z; matrix[0, 3] = -xaxis.DotProduct(place);
            matrix[1, 0] = yaxis.X; matrix[1, 1] = yaxis.Y; matrix[1, 2] = yaxis.Z; matrix[1, 3] = -yaxis.DotProduct(place);
            matrix[2, 0] = zaxis.X; matrix[2, 1] = zaxis.Y; matrix[2, 2] = zaxis.Z; matrix[2, 3] = -zaxis.DotProduct(place);
            matrix[3, 0] = 0;         matrix[3, 1] = 0;         matrix[3, 2] = 0;         matrix[3, 3] = 1;
            */

            matrix[0, 0] = xaxis.X; matrix[0, 1] = yaxis.X; matrix[0, 2] = zaxis.X; matrix[0, 3] = 0;
            matrix[1, 0] = xaxis.Y; matrix[1, 1] = yaxis.Y; matrix[1, 2] = zaxis.Y; matrix[1, 3] = 0;
            matrix[2, 0] = xaxis.Z; matrix[2, 1] = yaxis.Z; matrix[2, 2] = zaxis.Z; matrix[2, 3] = 0;
            matrix[3, 0] = -xaxis.DotProduct(place); matrix[3, 1] = -yaxis.DotProduct(place); matrix[3, 2] = -zaxis.DotProduct(place); matrix[3, 3] = 1;

            return matrix;
        }
        public void Move(Vector3d move)
        {
            Vector3d zaxis = (lookAt - place).Normalized();
            Vector3d xaxis = up.Cross(zaxis).Normalized();
            Vector3d yaxis = zaxis.Cross(xaxis).Normalized();

            place = place + (zaxis * move.Z + xaxis * move.X + yaxis * move.Y);
            up = yaxis.Normalized();

            var transform = new Matrix4x4();
            transform.SetTransfer(move.X, move.Y, move.Z);
            transformToView = transformToView * transform;
        }
        public void Rotate(double ox, double oy, double oz, Dot3d rotateCenter = null)
        {
            var transform = new Matrix4x4();
            Vector3d zaxis = (lookAt - place).Normalized();
            Vector3d xaxis = up.Cross(zaxis).Normalized();
            Vector3d yaxis = zaxis.Cross(xaxis).Normalized();

            transform.SetRotateAxis(ox, oy, oz, xaxis, yaxis, zaxis);
            up = yaxis.Normalized();
            transformToView = transformToView * transform;

            place = new Vector3d (transform.Apply(place.ToDot()));
        }

        public void Scale(double ko)
        {
        }

        public void SetLookAtDot(Dot3d dot)
        {
            lookAt = new Vector3d(dot);
        }

        public ViewFrustum GetFrustum()
        {
            viewFrustum = new ViewFrustum(new Dot3d(0, 0, -cameraNear), new Vector3d(1, 0, 0), new Vector3d(0, 0, 0) - new Vector3d(0, 0, -cameraNear), fov, (fov / aspectRatio), -cameraNear, cameraFar);
            return viewFrustum;
        }

        public ViewFrustum GetTransformFrustum()
        {
            viewFrustum = new ViewFrustum(place.ToDot(), up, lookAt - place, fov, (fov / aspectRatio), -cameraNear - 1, cameraFar);
            return viewFrustum;
            // viewFrustum.Transform(GetView());
        }
    }
}
