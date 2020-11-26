using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Shader
    {
        LightSource light;
        Dot3d viewer;
        public Shader(LightSource lightSource, Dot3d viewerPlace)
        {
            light = lightSource;
            viewer = viewerPlace;
        }
    }
}
