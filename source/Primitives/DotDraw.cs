using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class DotDraw : Dot3d
    {
        protected double[] interpolatedValues = new double[0];
        public DotDraw(double x = 0, double y = 0, double z = 0, double w = 1, Vector3d coeffColor = null) : base(x, y, z, w, coeffColor)
        {
            this.coeffColor = coeffColor;
        }
    }
}
