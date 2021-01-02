using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PerlinLandscape.Materials
{
    class WaterMaterial : Material
    {
        public WaterMaterial() : base(0.4, 0.3)
        {
            colorReflect = ReflectFromColor(Color.DarkBlue);
        }
    }
}
