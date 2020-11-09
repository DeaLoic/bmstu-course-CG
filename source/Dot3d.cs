using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Dot3d
    {
        public int X;
        public int Y;
        public int Z;
        public Dot3d(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public Dot3d Copy()
        {
            return new Dot3d(X, Y, Z);
        }
    }
}
