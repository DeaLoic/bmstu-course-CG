﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PerlinLandscape
{
    class StoneMaterial : Material
    {
        public StoneMaterial() : base(0.6, 0.1)
        {
            colorReflect = ReflectFromColor(Color.DarkGray);
        }
    }
}
