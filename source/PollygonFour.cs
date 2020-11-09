using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class PollygonFour : Object
    {
        Dot3d a;
        public Dot3d A { get { return ApplyTransformations(a); } }

        Dot3d b;
        public Dot3d B { get { return ApplyTransformations(b); } }

        Dot3d c;
        public Dot3d C { get { return ApplyTransformations(c); } }

        Dot3d d;
        public Dot3d D { get { return ApplyTransformations(d); } }

        List<Transformation3d> transformations;
        public List<Dot3d> pointsInside;
        public PollygonFour(Dot3d A, Dot3d B, Dot3d C, Dot3d D)
        {
            this.a = A;
            this.b = B;
            this.c = C;
            this.d = D;
            this.pointsInside = new List<Dot3d>();
            this.transformations = new List<Transformation3d>();
        }

        public void CalculatePointsInside(int maxX, int maxY)
        {
            pointsInside = new List<Dot3d>();

            List<Dot3d> triangle = new List<Dot3d>();
            triangle.Add(A);
            triangle.Add(C);
            triangle.Add(B);
            CalculatePointsInsideTriangle(triangle, maxX, maxY);
            triangle = new List<Dot3d>();
            triangle.Add(A);
            triangle.Add(C);
            triangle.Add(D);
            CalculatePointsInsideTriangle(triangle, maxX, maxY);
            
        }

        private void CalculatePointsInsideTriangle(List<Dot3d> v, int lastXPossible, int lastYPossible, int firstXPossible = 0, int firstYPossible = 0)
        {
            int yMax, yMin;
            int[] x = new int[3], y = new int[3];

            for (int i = 0; i < 3; ++i)
            {
                x[i] = v[i].X;
                y[i] = v[i].Y;
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
                        z2 = v[n].Z + m * (v[n1].Z - v[n].Z);
                    }
                    else
                    {
                        x1 = x[n] + (int)(m * (x[n1] - x[n]));
                        z1 = v[n].Z + m * (v[n1].Z - v[n].Z);
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
        public override void Transform(Transformation3d transformation)
        {
            if (transformations.Count == 0)
            {
                transformations.Add(transformation);
            }
            else
            {
                transformations.Add(transformation);
                a = transformations[0].Apply(a);
                b = transformations[0].Apply(b);
                c = transformations[0].Apply(c);
                d = transformations[0].Apply(d);
                transformations.RemoveAt(0);
            }
        }

        private Dot3d ApplyTransformations(Dot3d dot)
        {
            Dot3d dotResult = dot.Copy();
            for (int i = 0; i < transformations.Count; i++)
            {
                dotResult = transformations[i].Apply(dot);
            }
            return dotResult;
        }
    }
}
