using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    public static class MathSupport
    {
        public static double ToRadian(double angle)
        {
            return Math.PI * angle / 180;
        }
    }
}
