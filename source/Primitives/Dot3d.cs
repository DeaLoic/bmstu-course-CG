using System;
using System.Collections.Generic;
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
        public Dot3d(double x = 0, double y = 0, double z = 0, double w = 1)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public Dot3d Copy()
        {
            return new Dot3d(X, Y, Z, W);
        }

        public void Normilize()
        {
            W = W != 0 ? W : 1;
            X /= W;
            Y /= W;
            Z /= W;
            W = 1;
        }

        public Dot3d Normilized()
        {
            double w = W != 0 ? W : 1;
            return new Dot3d(X / w, Y / w, Z / w);
        }

        public static Dot3d operator -(Dot3d first, Dot3d second)
        {
            return new Dot3d(first.X - second.X, first.Y - second.Y, first.Z - second.Z, first.W);
        }
        public static Dot3d operator -(Dot3d first)
        {
            return new Dot3d(-first.X, -first.Y, -first.Z, first.W);
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
