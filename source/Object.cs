using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    abstract class Object
    {
        public abstract PollygonFour[] GetPollygonsFour();
        public abstract void Transform(Transformation3d transformation);
    }
}
