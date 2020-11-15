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
        double pitch, yaw, roll;

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
            return new Vector3d(Math.Cos(yaw) * Math.Cos(pitch), Math.Sin(pitch), Math.Sin(yaw) * Math.Cos(pitch));
        }
    }
}
