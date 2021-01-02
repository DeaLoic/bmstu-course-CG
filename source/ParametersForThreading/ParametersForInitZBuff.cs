using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class ParametersForInitZBuff
    {
        public int minY, maxY, width;
        public ParametersForInitZBuff(int minY, int maxY, int width)
        {
            this.maxY = maxY;
            this.minY = minY;
            this.width = width;
        }
    }
}
