using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Cutter : Pollygon
    {
        public Cutter(Dot3d[] dots) : base(dots){ }

        public PollygonDraw Clip(PollygonDraw cutting)
        {
            // сазерленд-ходжман
            Dot3d[] result = new Dot3d[0];
            Dot3d[] dotsCut = cutting.GetDots();
            int num = dotsCut.Length;
            if (dots.Length > 2 && num >= 2)
            {
                Dot3d p1, p2, tmp;
                double t1, t2;
                double k;

                result = new Dot3d[num];
                int fill = 0;
                for (int i = 0; i < dotsCut.Length; i++)
                {
                    p1 = dotsCut[i];
                    p2 = dotsCut[(i + 1) % num];
                    t1 = Normal().DotProduct(new Vector3d(p1 - dots[0]));
                    t2 = Normal().DotProduct(new Vector3d(p2 - dots[0]));
                    if (t1 >= 0)
                    {   // если начало лежит в области
                        if (fill == result.Length)
                        {
                            Array.Resize(ref result, (int)(fill * 1.5));
                        }
                        result[fill] = p1;
                        fill++;
                    }
                    // если ребро пересекает границу
                    if (((t1 > 0) && (t2 < 0)) ||
                        ((t2 >= 0) && (t1 < 0)))
                    {
                        k = 1 - t2 / (t2 - t1);
                        if (fill == result.Length)
                        {
                            Array.Resize(ref result, (int)(fill * 1.5));
                        }
                        result[fill] = new Dot3d(p1.X + k * (p2.X - p1.X), p1.Y + k * (p2.Y - p1.Y), p1.Z + k * (p2.Z - p1.Z));
                        fill++;
                    }
                }
                Array.Resize(ref result, fill);
            }

            return new PollygonDraw(result);
        }

        public bool IsDotOnRightSide(Dot3d dot)
        {
            bool isOnRightSide = false;
            if (dots.Length > 2 && normal.DotProduct(new Vector3d(dot - dots[0])) >= 0)
            {
                isOnRightSide = true;
            }
            return isOnRightSide;
        }
    }
}
