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

        PollygonDraw[] polygons;
        public Cube(int size)
        {
            A.X = size;
            A.Y = size;
            A.Z = size;
            polygons = new PollygonFour[6];
            polygons[0] = (new PollygonFour(A, new Dot3d(A.X, A.Y, 0), new Dot3d(A.X, 0, 0), new Dot3d(A.X, 0, A.Z)));
            polygons[0].color = Color.Red;
            polygons[1] = (new PollygonFour(new Dot3d(0, 0, 0), new Dot3d(0, A.Y, 0), new Dot3d(0, A.Y, A.Z), new Dot3d(0, 0, A.Z)));
            polygons[1].color = Color.Red;
            polygons[2] = (new PollygonFour(A, new Dot3d(0, A.Y, A.Z), new Dot3d(0, 0, A.Z), new Dot3d(A.X, 0, A.Z)));
            polygons[2].SetMaterial(new IceMaterial());
            polygons[3] = (new PollygonFour(new Dot3d(0, 0, 0), new Dot3d(A.X, 0, 0), new Dot3d(A.X, A.Y, 0), new Dot3d(0, A.Y, 0)));
            polygons[3].color = Color.Black;
            polygons[4] = (new PollygonFour(A, new Dot3d(0, A.Y, A.Z), new Dot3d(0, A.Y, 0), new Dot3d(A.X, A.Y, 0)));
            polygons[4].color = Color.DeepPink;
            polygons[5] = (new PollygonFour(new Dot3d(0, 0, 0), new Dot3d(0, 0, A.Z), new Dot3d(A.X, 0, A.Z), new Dot3d(A.X, 0, 0)));
            polygons[5].color = Color.DeepPink;

            centralDot = new Dot3d(A.X / 2, A.Y / 2, A.Z / 2);
        }

        public override void Normilize()
        {
            throw new NotImplementedException();
        }
        public override PollygonDraw[] GetPollygonsDraw()
        {
            return polygons;
        }
        public override Object Transform(Matrix4x4 transformation)
        {
            throw new NotImplementedException();
        }

        public override void Colorize(Shader shader)
        {
            throw new NotImplementedException();
        }
    }
}
