using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PerlinLandscape
{
    class DirtMaterial : Material
    {
        public DirtMaterial() : base(0.7, 0.1)
        {
            colorReflect = ReflectFromColor(Color.SaddleBrown);
        }
    }
}
