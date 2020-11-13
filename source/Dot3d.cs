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
