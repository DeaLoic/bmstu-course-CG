using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class HeightMap
    {
        public int Height { get; }
        public int Width { get; }

        public double maxHeight;

        double[,] map;
        public double this[int i, int j]
        {
            get => map[i, j];
            set => map[i, j] = value;
        }

        public HeightMap(int height = 100, int width = 100, double maxHeight = 1)
        {
            this.Height = height;
            this.Width = width;
            this.map = new double[height, width];
            this.maxHeight = maxHeight;
        }

        public void FillFlat(int constant = 0)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    map[i, j] = constant;
                }
            }
        }

        public void FillTriangle(int constant = 0)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    map[i, j] = i % 2 * 100;
                }
            }
        }

        public void Generate(Noize noize)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    map[i, j] = noize.Generate(i, j) * maxHeight;
                }
            }
        }

        public void Normilize()
        {
            double max = -100;
            double min = 100;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (map[i, j] > max)
                    {
                        max = map[i, j];
                    }
                    if (map[i, j] < min)
                    {
                        min = map[i, j];
                    }
                }
            }
            if (max > 1 || min < 0)
            {
                double acc = 1 / (max - min);
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        map[i, j] = (map[i, j] - min) * acc;
                        map[i, j] = map[i, j] > 1 ? 1 : (map[i, j] < 0 ? 0 : map[i, j]);
                    }
                }
            }
        }
    }
}
