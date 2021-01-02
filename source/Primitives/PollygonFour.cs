using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PerlinLandscape
{
    class PollygonFour : PollygonDraw
    {
        public Dot3d A;
        public Dot3d B;
        public Dot3d C;
        public Dot3d D;

        public PollygonFour(Dot3d A, Dot3d B, Dot3d C, Dot3d D, Material material = null) : base(new Dot3d[]{ A, B, C, D }, material)
        {
            this.A = dots[0];
            this.B = dots[1];
            this.C = dots[2];
            this.D = dots[3];
            double colorInt = (int)(A.Z + B.Z + C.Z + D.Z) / 4;
            color = Color.FromArgb((int)colorInt / 100 == 0 ? Math.Abs((int)(colorInt / 100 * 255)) : 255, 0, 0);
        }
    }
}
