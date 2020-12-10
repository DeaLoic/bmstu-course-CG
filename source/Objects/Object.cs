using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    abstract class Object
    {
        bool isVisible;
        protected Dot3d centralDot = new Dot3d();
        public Dot3d CentralDot { get => centralDot; }
        public bool IsVisible { get { return isVisible; } }

        public Object(bool isVisible = true)
        {
            this.isVisible = isVisible;
        }
        public abstract Object Transform(Matrix4x4 transformation);
        public abstract void Colorize(Shader shader);
        public abstract PollygonDraw[] GetPollygonsDraw();
        public abstract void Normilize();
    }
}
