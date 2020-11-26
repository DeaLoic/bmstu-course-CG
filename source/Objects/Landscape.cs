using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Landscape : Object
    {
        HeightMap heightMap;
        PollygonDraw[] polygons;

        public Landscape(HeightMap map, int maxHeightDelta = 500, int step = 4)
        {
            polygons = new PollygonFour[0];
            heightMap = map;
            FormPollygons(step, maxHeightDelta);
        }

        public override PollygonDraw[] GetPollygonsDraw()
        {
            return polygons;
        }

        private void FormPollygons(int step, double maxHeightDelta)
        {
            polygons = new PollygonFour[((heightMap.Width - 1) / step) * ((heightMap.Height - 1) / step)];
            int currentPos = 0;
            int xOffset = -heightMap.Width / 2;
            int yOffsetZero = -heightMap.Height / 2;
            int yOffset;
            for (int i = 0; i < (heightMap.Width - step); i += step, xOffset += step)
            {
                yOffset = yOffsetZero;
                for (int j = 0; j < (heightMap.Height - step); j += step, yOffset += step)
                {

                    polygons[currentPos] = new PollygonFour(new Dot3d(xOffset, yOffset, heightMap[i, j] * maxHeightDelta),
                                                            new Dot3d(xOffset, yOffset + step, heightMap[i, j + step] * maxHeightDelta),
                                                            new Dot3d(xOffset + step, yOffset + step, heightMap[i + step, j + step] * maxHeightDelta),
                                                            new Dot3d(xOffset + step, yOffset, heightMap[i + step, j] * maxHeightDelta));
                    currentPos++;
                }
            }
        }
    }
}
