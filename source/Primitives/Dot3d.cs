using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Dot3d
    {
        public double X;
        public double Y;
        public double Z;
        public double W;

        public Vector3d Normal = new Vector3d(1, 0, 0);
        public Vector3d coeffColor = new Vector3d(1, 1, 1);
        public Dot3d(double x = 0, double y = 0, double z = 0, double w = 1, Vector3d normal = null)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
            if (normal != null)
            {
                Normal = normal.Copy();
                Normal.Normalize();
            }
        }

        public static void CountDotsNormal(Dot3d A, Dot3d B, Dot3d C, Dot3d D)
        {
            Vector3d normal = new Vector3d(B.Normilized() - A.Normilized()).Cross(new Vector3d(C.Normilized() - A.Normilized()));
            normal.Normalize();
            A.Normal = A.Normal + normal;
            A.Normal.Normalize();

            B.Normal = B.Normal + normal;
            B.Normal.Normalize();

            C.Normal = C.Normal + normal;
            C.Normal.Normalize();

            D.Normal = D.Normal + normal;
            D.Normal.Normalize();
        }

        public Dot3d Copy()
        {
            return new Dot3d(X, Y, Z, W, Normal);
        }

        public void Normilize()
        {
            W = W != 0 ? W : 1;
            X /= W;
            Y /= W;
            Z /= W;
            W = 1;
            Normal.Normalize();
        }

        public Dot3d Normilized()
        {
            double w = W != 0 ? W : 1;
            return new Dot3d(X / w, Y / w, Z / w, normal: Normal);
        }

        public static Dot3d operator -(Dot3d first, Dot3d second)
        {
            return new Dot3d(first.X - second.X, first.Y - second.Y, first.Z - second.Z, first.W, first.Normal + second.Normal);
        }
        public static Dot3d operator -(Dot3d first)
        {
            return new Dot3d(-first.X, -first.Y, -first.Z, first.W, first.Normal);
        }
    }

    class Point3D
    {
        public int x, y, z;
        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
