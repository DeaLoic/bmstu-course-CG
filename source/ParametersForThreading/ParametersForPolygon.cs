using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class ParametersForPolygon
    {
        public Bitmap image;
        public PollygonDraw[] pollygons;
        public int polStart, polEnd;
        public Cutter window;
        public Shader shader;
        public Mutex mutex;
        public ParametersForPolygon(Bitmap image1, PollygonDraw[] polygons1, int polStart1, int polEnd1, Cutter window1, Mutex mutex1, Shader shader1)
        {
            shader = shader1;
            image = image1;
            pollygons = polygons1;
            polStart = polStart1;
            polEnd = polEnd1;
            window = window1;
            mutex = mutex1;
        }
    }
}
