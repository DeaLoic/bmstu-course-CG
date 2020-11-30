using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class IceMaterial : Material
    {
        public IceMaterial() : base(0.9, 0.7)
        {
            colorReflect = new Vector3d(0.95, 0.95, 0.95);
        }
    }
}
