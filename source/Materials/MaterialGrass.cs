using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PerlinLandscape
{
    class MaterialGrass : Material
    {
        public MaterialGrass() : base(0.8, 0.1)
        {
            colorReflect = ReflectFromColor(Color.DarkGreen);
        }
    }
}
