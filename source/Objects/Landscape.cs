using PerlinLandscape.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Landscape : Object
    {
        HeightMap heightMap;
        PollygonDraw[] polygons;
        Dot3d[,] dots;
        int iceHeight = 480;
        int stoneHeight = 370;
        int grassHeight = 100;
        int waterHeight = 10;
        int maxHeightDelta;
        int step;

        public Landscape(HeightMap map, int maxHeightDelta = 500, int step = 4, bool generate = true)
        {
            polygons = new PollygonFour[0];
            heightMap = map;
            iceHeight = maxHeightDelta - iceHeight;
            stoneHeight = maxHeightDelta - stoneHeight;
            grassHeight = maxHeightDelta - grassHeight;
            waterHeight = maxHeightDelta - waterHeight;
            this.maxHeightDelta = maxHeightDelta;
            this.step = step;
            if (generate)
            {
                FormDots();
                FormPollygons(step, maxHeightDelta);
            }
        }

        private void FormDots()
        {
            this.dots = new Dot3d[heightMap.Width, heightMap.Height];
            int xOffset = -heightMap.Width / 2;
            int yOffsetZero = -heightMap.Height / 2;
            int yOffset = 0;
            for (int i = 0; i < (heightMap.Width); i += 1, xOffset += 1)
            {
                yOffset = yOffsetZero;
                for (int j = 0; j < (heightMap.Height); j += 1, yOffset += 1)
                {
                    dots[i, j] = new Dot3d(xOffset, yOffset, heightMap[i, j] * maxHeightDelta);
                }
            }

            for (int i = 0; i < heightMap.Width - 1; i += 1)
            {
                for (int j = 0; j < heightMap.Height - 1; j += 1)
                {
                    Dot3d.CountDotsNormal(dots[i, j], dots[i, j + 1], dots[i + 1, j + 1], dots[i + 1, j]);
                }
            }
        }

        public override void Colorize(Shader shader)
        {
            for (int i = 0; i < (heightMap.Width); i++)
            {
                for (int j = 0; j < (heightMap.Height); j++)
                {
                    dots[i, j].coeffColor = shader.GetCoeffInDot(dots[i, j], dots[i, j].Normal);
                }
            }

            for (int i = 0; i < polygons.Length; i++)
            {
                polygons[i].color = shader.GetColorSimple(polygons[i]);
            }
        }

        public override Object Transform(Matrix4x4 transformation)
        {
            Dot3d[,] newDots = new Dot3d[(heightMap.Width / step), (heightMap.Height / step)];
            for (int i = 0; i < (heightMap.Width); i += step)
            {
                for (int j = 0; j < (heightMap.Height); j += step)
                {
                    newDots[i / step, j / step] = transformation.Apply(dots[i, j]);
                    newDots[i / step, j / step].coeffColor = dots[i, j].coeffColor;
                }
            }
            Landscape landscape = new Landscape(heightMap, maxHeightDelta, step, false);
            landscape.polygons = new PollygonFour[((heightMap.Width - 1 )/ step) * ((heightMap.Height - 1)/ step)];
            int currentPos = 0;
            for (int i = 0; i < (heightMap.Width / step) - 1; i++)
            {
                for(int j = 0; j < (heightMap.Height / step) - 1; j++)
                {
                    PollygonFour pol = new PollygonFour(newDots[i, j], newDots[i, j + 1], newDots[i + 1, j + 1], newDots[i + 1, j]);
                    pol.color = polygons[currentPos].color;
                    pol.SetMaterial(polygons[currentPos].Material);
                    landscape.polygons[currentPos] = pol;
                    currentPos++;
                }
            }

            return landscape;
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
                    PollygonFour pol = new PollygonFour(dots[i, j], dots[i, j + step], dots[i + step, j + step], dots[i + step, j]);
                    double currentHeight = heightMap[i, j] + heightMap[i, j + step] + heightMap[i + step, j + step] + heightMap[i + step, j];
                    heightMax = Math.Max(heightMax, currentHeight / 4);
                    heightMin = Math.Min(heightMin, heightMap[i, j]);
                    heightMiddle += currentHeight;
                    PaintPolygon(pol);
                    polygons[currentPos] = pol;

                    currentPos++;
                }
            }
            heightMiddle /= polygons.Length * 4;
            heightMiddle *= maxHeightDelta;

            centralDot = new Dot3d(0, 0, heightMiddle);
        }

        private void PaintPolygon(PollygonFour pollygon)
        {
            double currentHeight = pollygon.A.Z + pollygon.B.Z + pollygon.C.Z + pollygon.D.Z;
            currentHeight *= (maxHeightDelta / 4);
            if (currentHeight > iceHeight)
            {
                pollygon.SetMaterial(new IceMaterial());
            }
            if (currentHeight > stoneHeight)
            {
                pollygon.SetMaterial(new StoneMaterial());
            }
            if (currentHeight > grassHeight)
            {
                pollygon.SetMaterial(new MaterialGrass());
                pollygon.Material.Outrage(5, (int)DateTime.UtcNow.Ticks * DateTime.UtcNow.Millisecond * (int)currentHeight);
            }
            if (currentHeight > waterHeight)
            {
                pollygon.SetMaterial(new WaterMaterial());
            }
        }
    }
}
