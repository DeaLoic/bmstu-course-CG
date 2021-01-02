using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    // эйлер угол
    class EAngle
    {
        public double pitch, yaw, roll;

        // except roll
        public EAngle(double pitch = 0, double yaw = 0, double roll = 0)
        {
            this.pitch = MathSupport.ToRadian(pitch);
            this.yaw = MathSupport.ToRadian(yaw);
            this.roll = MathSupport.ToRadian(roll);
        }

        public void AddDegrees(double pitch = 0, double yaw = 0, double roll = 0)
        {
            this.pitch += MathSupport.ToRadian(pitch);
            this.yaw += MathSupport.ToRadian(yaw);
            this.roll += MathSupport.ToRadian(roll);
        }

        public Vector3d ToVector()
        {
            Matrix4x4 matrix = new Matrix4x4();
            matrix.Reset();
            matrix[0, 0] = Math.Cos(yaw);
            matrix[1, 0] = Math.Sin(yaw);
            matrix[1, 1] = Math.Cos(yaw);
            matrix[0, 1] = -Math.Sin(yaw);

            Vector3d vec = new Vector3d(1, 1, 1, 1);
            vec = vec * matrix;

            Matrix4x4 second = new Matrix4x4();
            second[1, 1] = Math.Cos(roll);
            second[2, 1] = Math.Sin(roll);
            second[2, 2] = Math.Cos(roll);
            second[1, 2] = -Math.Sin(roll);

            vec = vec * second;

            second.Reset();
            second[0, 0] = Math.Cos(pitch);
            second[1, 0] = Math.Sin(pitch);
            second[1, 1] = Math.Cos(pitch);
            second[0, 1] = -Math.Sin(pitch);

            return vec * second;
        }

        public Matrix4x4 ToMatrix()
        {
            Matrix4x4 matrix = new Matrix4x4();
            matrix.Reset();
            matrix[0, 0] = Math.Cos(yaw);
            matrix[1, 0] = Math.Sin(yaw);
            matrix[1, 1] = Math.Cos(yaw);
            matrix[0, 1] = -Math.Sin(yaw);

            Matrix4x4 second = new Matrix4x4();
            second[1, 1] = Math.Cos(roll);
            second[2, 1] = Math.Sin(roll);
            second[2, 2] = Math.Cos(roll);
            second[1, 2] = -Math.Sin(roll);

            matrix = matrix * second;

            second.Reset();
            second[0, 0] = Math.Cos(pitch);
            second[1, 0] = Math.Sin(pitch);
            second[1, 1] = Math.Cos(pitch);
            second[0, 1] = -Math.Sin(pitch);

            return matrix * second;
        }
    }
}
