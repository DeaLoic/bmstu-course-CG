using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    abstract class Noize
    {
        public abstract double Generate(double x, double y);
    }
}
