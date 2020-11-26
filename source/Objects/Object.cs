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
        public bool IsVisible { get { return isVisible; } }

        public Object(bool isVisible = true)
        {
            this.isVisible = isVisible;
        }
        public abstract PollygonDraw[] GetPollygonsDraw();
    }
}
