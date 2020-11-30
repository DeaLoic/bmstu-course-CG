using PerlinLandscape.Materials;
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
        int iceHeight = 480;
        int stoneHeight = 370;
        int grassHeight = 100;
        int waterHeight = 10;

        public Landscape(HeightMap map, int maxHeightDelta = 500, int step = 4)
        {
            polygons = new PollygonFour[0];
            heightMap = map;
            iceHeight = maxHeightDelta - iceHeight;
            stoneHeight = maxHeightDelta - stoneHeight;
            grassHeight = maxHeightDelta - grassHeight;
            waterHeight = maxHeightDelta - waterHeight;
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
            double heightMax = -100;
            double heightMin = 100;
            double heightMiddle = 0;
            for (int i = 0; i < (heightMap.Width - step); i += step, xOffset += step)
            {
                yOffset = yOffsetZero;
                for (int j = 0; j < (heightMap.Height - step); j += step, yOffset += step)
                {

                    polygons[currentPos] = new PollygonFour(new Dot3d(xOffset, yOffset, heightMap[i, j] * maxHeightDelta),
                                                            new Dot3d(xOffset, yOffset + step, heightMap[i, j + step] * maxHeightDelta),
                                                            new Dot3d(xOffset + step, yOffset + step, heightMap[i + step, j + step] * maxHeightDelta),
                                                            new Dot3d(xOffset + step, yOffset, heightMap[i + step, j] * maxHeightDelta));
                    double currentHeight = heightMap[i, j] + heightMap[i, j + step] + heightMap[i + step, j + step] + heightMap[i + step, j];
                    heightMax = Math.Max(heightMax, currentHeight / 4);
                    heightMin = Math.Min(heightMin, heightMap[i, j]);
                    heightMiddle += currentHeight;
                    currentHeight *= (maxHeightDelta / 4);
                    if (currentHeight > iceHeight)
                    {
                        polygons[currentPos].SetMaterial(new IceMaterial());
                    }
                    if (currentHeight > stoneHeight)
                    {
                        polygons[currentPos].SetMaterial(new StoneMaterial());
                    }
                    if (currentHeight > grassHeight)
                    {
                        polygons[currentPos].SetMaterial(new MaterialGrass());
                    }
                    if (currentHeight > waterHeight)
                    {
                        polygons[currentPos].SetMaterial(new WaterMaterial());
                    }
                    currentPos++;
                }
            }
            heightMiddle /= polygons.Length * 4;
            heightMiddle *= maxHeightDelta;

            centralDot = new Dot3d(0, 0, heightMiddle);
        }
    }
}
