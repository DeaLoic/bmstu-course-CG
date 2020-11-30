using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    abstract class DrawAlgorithm
    {
        public abstract void Process(Bitmap bitmap, Scene scene, int typeView = 0);
        public abstract double GetZ(int x, int y);
    }
}
