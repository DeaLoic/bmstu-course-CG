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


        public List<DotDraw> pointsInside;
        public Color color;
        Material material = new Material(0.5, 0.3);
        public Material Material { get => material; }

        public PollygonDraw(Dot3d[] dots, Material material = null) : base(dots)
        {
            this.pointsInside = new List<DotDraw>();
            if (material != null)
            {
                this.material = material;
            }
        }

        public void CalculatePointsInside(int maxX, int maxY, int minX = 0, int minY = 0)
        {
            pointsInside = new List<DotDraw>();

            if (dots.Length > 2)
            {
                for (int i = 2; i < dots.Length; i += 1)
                {
                    Dot3d[] triangle = new Dot3d[3];
                    triangle[0] = (dots[0]);
                    triangle[1] = (dots[i - 1]);
                    triangle[2] = (dots[i]);
                    CalculatePointsInsideTriangle(triangle, maxX, maxY, minX, minY);
                }
            }
        }

        private void CalculatePointsInsideTriangle(Dot3d[] v, int lastXPossible, int lastYPossible, int firstXPossible = 0, int firstYPossible = 0)
        {
            double yMax, yMin;
            double[] x = new double[3], y = new double[3];
            double[] z = new double[3];
            Vector3d[] c = new Vector3d[3];

            for (int i = 0; i < 3; i++)
            {
                x[i] = (v[i].X);
                y[i] = (v[i].Y);
                z[i] = (v[i].Z);
                c[i] = v[i].coeffColor;
            }

            yMax = y.Max();
            yMin = y.Min();

            yMin = (yMin < firstYPossible) ? firstYPossible : yMin;
            yMax = (yMax < lastYPossible) ? yMax : lastYPossible;

            yMin = (yMin > lastYPossible) ? lastYPossible : yMin;
            yMax = (yMax > firstYPossible) ? yMax : firstYPossible;

            double x1 = 0, x2 = 0;
            double z1 = 0, z2 = 0;

            Vector3d c1 = new Vector3d(1, 1, 1), c2 = new Vector3d(1, 1, 1);

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
                        c2 = c[n] + ((c[n1] - c[n]) * m);
                    }
                    else
                    {
                        x1 = x[n] + (m * (x[n1] - x[n]));
                        z1 = z[n] + m * (z[n1] - z[n]);
                        c1 = c[n] + ((c[n1] - c[n]) * m);
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

                    Vector3d tempCoeff = c1;
                    c1 = c2;
                    c2 = tempCoeff;
                }
                double xStart = (x1 < firstXPossible) ? firstXPossible : x1;
                xStart = (xStart > lastXPossible) ? lastXPossible : xStart;

                double xEnd = (x2 < lastXPossible) ? x2 : lastXPossible;
                xEnd = (xEnd > firstXPossible) ? xEnd : firstXPossible;

                for (int xDot = (int)xStart; xDot <= xEnd; xDot++)
                {
                    if (x1 - x2 != 0)
                    { 
                        double m = (double)(x1 - xDot) / (x1 - x2);
                        double zDot = z1 + m * (z2 - z1);
                        pointsInside.Add(new DotDraw(xDot, yDot, zDot, coeffColor: c1 + ((c2 - c1) * m)));
                    }
                }
            }
        }

        public void SetMaterial(Material newMaterial)
        {
            material = newMaterial;
        }
    }
}
