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
        PollygonFour[] polygons;

        public Landscape(HeightMap map)
        {
            polygons = new PollygonFour[0];
            heightMap = map;
            FormPollygons();
        }

        public override PollygonFour[] GetPollygonsFour()
        {
            return polygons;
        }

        public override void Transform(Transformation3d transformation)
        {
            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].Transform(transformation);
            }
        }

        private void FormPollygons()
        {
            polygons = new PollygonFour[(heightMap.Width - 1) * (heightMap.Height - 1)];
            int currentPos = 0;
            for (int i = 0; i < heightMap.Width - 1; i++)
            {
                for (int j = 0; j < heightMap.Height - 1; j++)
                {
                    polygons[currentPos] = new PollygonFour(new Dot3d(i, j, heightMap[i, j]),
                                                            new Dot3d(i, j + 1, heightMap[i, j + 1]),
                                                            new Dot3d(i + 1, j + 1, heightMap[i + 1, j + 1]),
                                                            new Dot3d(i + 1, j, heightMap[i + 1, j + 1]));
                    currentPos++;
                }
            }
        }
    }
}
