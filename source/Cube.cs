using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Cube : Object
    {
        Dot3d A = new Dot3d();

        PollygonFour[] polygons;
        public Cube(int size)
        {
            A.X = size;
            A.Y = size;
            A.Z = size;
            polygons = new PollygonFour[6];
            polygons[0] = (new PollygonFour(A, new Dot3d(A.X, A.Y, 0), new Dot3d(A.X, 0, A.Z), new Dot3d(A.X, 0, 0)));
            polygons[1] = (new PollygonFour(new Dot3d(0, 0, 0), new Dot3d(0, A.Y, 0), new Dot3d(0, 0, A.Z), new Dot3d(0, A.Y, A.Z)));
            polygons[2] = (new PollygonFour(A, new Dot3d(0, A.Y, A.Z), new Dot3d(A.X, 0, A.Z), new Dot3d(0, 0, A.Z)));
            polygons[3] = (new PollygonFour(new Dot3d(0, 0, 0), new Dot3d(A.X, 0, 0), new Dot3d(0, A.Y, 0), new Dot3d(A.X, A.Y, 0)));
            polygons[4] = (new PollygonFour(A, new Dot3d(0, A.Y, A.Z), new Dot3d(0, A.Y, 0), new Dot3d(A.X, A.Y, 0)));
            polygons[5] = (new PollygonFour(new Dot3d(0, 0, 0), new Dot3d(0, 0, A.Z), new Dot3d(A.X, 0, A.Z), new Dot3d(A.X, 0, 0)));
        }

        public override PollygonFour[] GetPollygonsFour()
        {
            return polygons;
        }
    }
}
