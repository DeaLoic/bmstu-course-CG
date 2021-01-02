using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PerlinLandscape.Materials
{
    class SandMaterial : Material
    {
        public SandMaterial() : base(0.6, 0.3)
        {
            colorReflect = ReflectFromColor(Color.SandyBrown);
        }
    }
}
