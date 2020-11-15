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

        int[,] map;
        public int this[int i, int j]
        {
            get => map[i, j];
            set => map[i, j] = value;
        }

        public HeightMap(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            this.map = new int[height, width];
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
            Random rand = new Random();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    map[i, j] = rand.Next(0, 100);
                }
            }
        }
    }
}
