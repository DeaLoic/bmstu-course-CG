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

        public void AddInterpolatedValue(double value)
        {
            Array.Resize(ref interpolatedValues, interpolatedValues.Length + 1);
            interpolatedValues[interpolatedValues.Length - 1] = value;
        }
        public double GetInterpolatedValue(int index)
        {
            return interpolatedValues[index];
        }
    }
}
