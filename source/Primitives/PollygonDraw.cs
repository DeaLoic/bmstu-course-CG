using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PerlinLandscape
{
    class PollygonDraw : Pollygon
    {
        int averageHeight;
        public List<Dot3d> pointsInside;
        public Color color;
        Material material = new Material(0.5, 0.1);
        public Material Material { get => material; }

        public PollygonDraw(Dot3d[] dots, Material material = null) : base(dots)
        {
            this.pointsInside = new List<Dot3d>();
            if (material != null)
            {
                this.material = material;
            }
        }

        public void CalculatePointsInside(int maxX, int maxY, int minX = 0, int minY = 0)
        {
            pointsInside = new List<Dot3d>();

            if (dots.Length > 2)
            {
                for (int i = 2; i < dots.Length; i += 1)
                {
                    List<Dot3d> triangle = new List<Dot3d>();
                    triangle.Add(dots[0]);
                    triangle.Add(dots[i - 1]);
                    triangle.Add(dots[i]);
                    CalculatePointsInsideTriangle(triangle, maxX, maxY, minX, minY);
                }
            }
        }

        private void CalculatePointsInsideTriangle(List<Dot3d> v, int lastXPossible, int lastYPossible, int firstXPossible = 0, int firstYPossible = 0)
        {
            double yMax, yMin;
            double[] x = new double[3], y = new double[3];
            double[] z = new double[3];

            for (int i = 0; i < 3; i++)
            {
                x[i] = (v[i].X / v[i].W);
                y[i] = (v[i].Y / v[i].W);
                z[i] = (v[i].Z / v[i].W);
            }

            yMax = y.Max();
            yMin = y.Min();

            yMin = (yMin < firstYPossible) ? firstYPossible : yMin;
            yMax = (yMax < lastYPossible) ? yMax : lastYPossible;

            double x1 = 0, x2 = 0;
            double z1 = 0, z2 = 0;

            for (int yDot = (int)yMin; yDot <= yMax; yDot++)
            {
                int fFirst = 1;
                for (int n = 0; n < 3; n++)
                {
                    int n1 = (n == 2) ? 0 : n + 1;

                    if (yDot > Math.Max(y[n], y[n1]) || yDot < Math.Min(y[n], y[n1]))
                        continue; // точка вне

                    double m = (double)(y[n] - yDot) / (y[n] - y[n1]);
                    if ((y[n] - y[n1]) == 0)
                    {
                        m = 0;
                    }
                    if (fFirst == 0)
                    {
                        x2 = x[n] + (m * (x[n1] - x[n]));
                        z2 = z[n] + m * (z[n1] - z[n]);
                    }
                    else
                    {
                        x1 = x[n] + (m * (x[n1] - x[n]));
                        z1 = z[n] + m * (z[n1] - z[n]);
                    }
                    fFirst = 0;
                }

                if (x2 < x1)
                {
                    double temp = x1;
                    x1 = x2;
                    x2 = temp;

                    temp = z1;
                    z1 = z2;
                    z2 = temp;
                }
                double xStart = (x1 < firstXPossible) ? firstXPossible : x1;
                double xEnd = (x2 < lastXPossible) ? x2 : lastXPossible;
                for (int xDot = (int)xStart; xDot <= xEnd; xDot++)
                {
                    if (x1 - x2 != 0)
                    { 
                        double m = (double)(x1 - xDot) / (x1 - x2);
                        double zDot = z1 + m * (z2 - z1);
                        pointsInside.Add(new Dot3d(xDot, yDot, zDot));
                    }
                }
            }
        }
    }
}
