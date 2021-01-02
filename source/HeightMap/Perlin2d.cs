using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Perlin2d : Noize
    {
        private Vector3d[,] grid;
        private Random random = new Random((int)DateTime.UtcNow.Ticks);
        private double stepX;
        private double stepY;
        public Perlin2d(int width, int height, int minReal, int maxReal)
        {
            grid = new Vector3d[width + 1, height + 1];
            double angle;
            for (var i = 0; i < width + 1; i++)
            {
                for (var j = 0; j < height + 1; j++)
                {
                    angle = random.NextDouble() * Math.PI * 2;
                    grid[i, j] = new Vector3d(Math.Cos(angle), Math.Sin(angle));
                }
            }
            this.stepX = (double)width / (maxReal - minReal);
            this.stepY = (double)height / (maxReal - minReal);
        }

        public override double Generate(double x, double y)
        {
            x = InsideGridX(x);
            y = InsideGridY(y);
            int x0 = (int)x;
            double dx = x - x0;
            int y0 = (int)y;
            double dy = y - y0;

            var vx0y0 = grid[x0, y0];
            var vx0y1 = grid[x0, y0 + 1];
            var vx1y0 = grid[x0 + 1, y0];
            var vx1y1 = grid[x0 + 1, y0 + 1];
            var s = vx0y0.DotProduct( new Vector3d(dx, dy));
            var t = vx1y0.DotProduct(new Vector3d(dx - 1, dy));
            var u = vx0y1.DotProduct(new Vector3d(dx, dy - 1));
            var v = vx1y1.DotProduct(new Vector3d(dx - 1, dy - 1));

            var a = GetWeightedAverage(s, t, dx);
            var b = GetWeightedAverage(u, v, dx);
            var c = GetWeightedAverage(a, b, dy);

            return Normalize(c);
        }
        private double Fade(double t)
        {
            return 6 * t * t * t * t * t - 15 * t * t * t * t + 10 * t * t * t;
        }

        private double GetWeightedAverage(double a, double b, double weight)
        {
            return a + Fade(weight) * (b - a);
        }

        private double Normalize(double x)
        {
            return x + 0.5;// (x - 1) / 2;
        }

        private double InsideGridX(double x)
        {
            return x * stepX;
        }

        private double InsideGridY(double x)
        {
            return x * stepY;
        }
    }
}
