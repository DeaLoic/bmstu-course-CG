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

        Noize noize;
        double maxHeight;

        double[,] map;
        public double this[int i, int j]
        {
            get => map[i, j];
            set => map[i, j] = value;
        }

        public HeightMap(Noize noize, int height = 100, int width = 100, double maxHeight = 1)
        {
            this.noize = noize;
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

        public void Generate()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    map[i, j] = noize.Generate(i, j) * maxHeight;
                }
            }
        }
    }
}
