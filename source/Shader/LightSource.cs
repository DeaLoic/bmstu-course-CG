using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class LightSource
    {
        Dot3d place;
        Vector3d lightVector;
        Color color = Color.Yellow;
        public Dot3d Place { get => place; }
        public Vector3d Direction { get => lightVector; }
        public Color Color { get => color; }

        public LightSource(Dot3d place, Vector3d lightVector, Color color = default)
        {
            this.place = place;
            this.lightVector = lightVector;
            this.color = color;
        }
    }
}
