﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Drawer
    {
        DrawAlgorithm drawAlgorithm;

        public Drawer(DrawAlgorithm drawAlgorithm)
        {
            this.drawAlgorithm = drawAlgorithm;
        }

        public double Draw(Bitmap bitmap, Scene scene)
        {
            return drawAlgorithm.Process(bitmap, scene);
        }

        public double GetZ(int x, int y)
        {
            return drawAlgorithm.GetZ(x, y);
        }
    }
}
