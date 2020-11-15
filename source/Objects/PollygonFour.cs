using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PerlinLandscape
{
    class PollygonFour : Object
    {
        public Dot3d A;
        public Dot3d B;
        public Dot3d C;
        public Dot3d D;

        public List<Dot3d> pointsInside;
        public Color color;
        public PollygonFour(Dot3d A, Dot3d B, Dot3d C, Dot3d D)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
            this.pointsInside = new List<Dot3d>();
            double colorInt = (int)(A.Z + B.Z + C.Z + D.Z) / 4;
            color = Color.FromArgb((int)colorInt / 100 == 0 ? Math.Abs((int)(colorInt / 100 * 255)) : 255, 0, 0);
        }

        public void CalculatePointsInside(int maxX, int maxY, int minX=0, int minY=0)
        {
            pointsInside = new List<Dot3d>();

            List<Dot3d> triangle = new List<Dot3d>();
            triangle.Add(A);
            triangle.Add(C);
            triangle.Add(B);
            CalculatePointsInsideTriangle(triangle, maxX, maxY, minX, minY);
            triangle = new List<Dot3d>();
            triangle.Add(A);
            triangle.Add(C);
            triangle.Add(D);
            CalculatePointsInsideTriangle(triangle, maxX, maxY, minX, minY);
            
        }

        private void CalculatePointsInsideTriangle(List<Dot3d> v, int lastXPossible, int lastYPossible, int firstXPossible = 0, int firstYPossible = 0)
        {
            int yMax, yMin;
            int[] x = new int[3], y = new int[3];

            for (int i = 0; i < 3; ++i)
            {
                x[i] = (int)(v[i].X / v[i].W);
                y[i] = (int)(v[i].Y / v[i].W);
            }

            yMax = y.Max();
            yMin = y.Min();

            yMin = (yMin < firstYPossible) ? firstYPossible : yMin;
            yMax = (yMax < lastYPossible) ? yMax : lastYPossible;

            int x1 = 0, x2 = 0;
            double z1 = 0, z2 = 0;

            for (int yDot = yMin; yDot <= yMax; yDot++)
            {
                int fFirst = 1;
                for (int n = 0; n < 3; ++n)
                {
                    int n1 = (n == 2) ? 0 : n + 1;

                    if (yDot >= Math.Max(y[n], y[n1]) || yDot < Math.Min(y[n], y[n1])) // || y[n] == y[n1]  
                        continue; // точка вне

                    double m = (double)(y[n] - yDot) / (y[n] - y[n1]);
                    if (fFirst == 0)
                    {
                        x2 = x[n] + (int)(m * (x[n1] - x[n]));
                        z2 = (v[n].Z / v[n].W) + m * ((v[n1].Z / v[n1].W) - (v[n].Z/ v[n].W));
                    }
                    else
                    {
                        x1 = x[n] + (int)(m * (x[n1] - x[n]));
                        z1 = (v[n].Z / v[n].W) + m * ((v[n1].Z / v[n1].W) - (v[n].Z/ v[n].W));
                    }
                    fFirst = 0;
                }

                if (x2 < x1)
                {
                    int temp = x1;
                    x1 = x2;
                    x2 = temp;

                    double temp1 = z1;
                    z1 = z2;
                    z2 = temp1;
                }

                int xStart = (x1 < firstXPossible) ? firstXPossible : x1;
                int xEnd = (x2 < lastXPossible) ? x2 : lastXPossible;
                for (int xDot = xStart; xDot < xEnd; xDot++)
                {
                    double m = (double)(x1 - xDot) / (x1 - x2);
                    double zDot = z1 + m * (z2 - z1);

                    pointsInside.Add(new Dot3d(xDot, yDot, (int)zDot));
                }
            }
        }

        public override PollygonFour[] GetPollygonsFour()
        {
            return new PollygonFour[]{ this };
        }
    }
}
