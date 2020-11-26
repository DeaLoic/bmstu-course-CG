using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class LightSource
    {
        Dot3d place;
        Vector3d lightVector;
        public Dot3d Place { get => place; }
        public Vector3d Dirrection { get => lightVector; }
        public LightSource(Dot3d place, Vector3d lightVector)
        {
            this.place = place;
            this.lightVector = lightVector;
        }
    }
}
