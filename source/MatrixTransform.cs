using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class MatrixTransform : Matrix
    {
        public MatrixTransform() : base(4, 4) 
        {
            this[0, 0] = 1;
            this[1, 1] = 1;
            this[2, 2] = 1;
            this[3, 3] = 1;
        }

        public void Reset()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    this[i, j] = 0;
                }
            }
            this[0, 0] = 1;
            this[1, 1] = 1;
            this[2, 2] = 1;
            this[3, 3] = 1;
        }
        
        // в k раз
        public void SetScaleGlobal(double ks)
        {
            this.Reset();
            ks = ks != 0 ? ks : 1;
            this[3, 3] = 1 / ks; 
        }
        
        // перенос
        public void SetTransfer(double dx, double dy, double dz)
        {
            this.Reset();
            this[3, 0] = dx;
            this[3, 1] = dy;
            this[3, 2] = dz;
        }

        public void SetScalePartition(double kx, double ky, double kz)
        {
            this.Reset();
            this[0, 0] = kx;
            this[1, 1] = ky;
            this[2, 2] = kz;
        }

        /* [x+yd+hz, bx+y+iz, cx+fy+z, 1]. сдвиг */
        public void SetShift(double d, double h, double b, double i, double c, double f)
        {
            this.Reset();
            this[0, 1] = b;
            this[0, 2] = c;
            this[1, 0] = d;
            this[1, 2] = f;
            this[2, 0] = h;
            this[2, 1] = i;
        }

        public void SetRotate(double ox, double oy, double oz)
        {
            this.Reset();
            ox = MathSupport.ToRadian(ox);
            oy = MathSupport.ToRadian(oy);
            oz = MathSupport.ToRadian(oz);

            this[1, 1] = Math.Cos(ox);
            this[2, 2] = this[1, 1];
            this[1, 2] = Math.Sin(ox);
            this[2, 1] = -this[1, 2];

            MatrixTransform matrix = new MatrixTransform();
            matrix[0, 0] = Math.Cos(oz);
            matrix[1, 1] = matrix[0, 0];
            matrix[0, 1] = Math.Sin(oz);
            matrix[1, 0] = -matrix[0, 1];
            matrix = (MatrixTransform)MultiplyVinograd(matrix);
            this.Reset();
            this[0, 0] = Math.Cos(oy);
            this[2, 2] = this[0, 0];
            this[2, 0] = Math.Sin(oy);
            this[0, 2] = -this[2, 0];
            matrix = (MatrixTransform)matrix.MultiplyVinograd(this);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    this[i, j] = matrix[i, j];
                }
            }
        }

        public Dot3d Apply(Dot3d dot)
        {
            Matrix dotVector = new Matrix(1, 4);
            dotVector[0, 0] = dot.X;
            dotVector[0, 1] = dot.Y;
            dotVector[0, 2] = dot.Z;
            dotVector[0, 3] = dot.W;

            dotVector = dotVector.MultiplyVinograd(this);
            return new Dot3d(dotVector[0, 0], dotVector[0, 1], dotVector[0, 2], dotVector[0, 3]);
        }

        public MatrixTransform MultiplyVinograd(MatrixTransform second)
        {
            MatrixTransform result = new MatrixTransform();
            if (this.M == second.N && this.N != 0 && second.M != 0)
            {
                int n1 = this.N;
                int m1 = this.M;
                int n2 = second.N;
                int m2 = second.M;

                double[] mulH = new double[n1];
                double[] mulV = new double[m2];

                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m1 / 2; j++)
                    {
                        mulH[i] += this[i, j * 2] * this[i, j * 2 + 1];
                    }
                }

                for (int i = 0; i < m2; i++)
                {
                    for (int j = 0; j < n2 / 2; j++)
                    {
                        mulV[i] += second[j * 2, i] * second[j * 2 + 1, i];
                    }
                }

                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        result[i, j] = -mulH[i] - mulV[j];
                        for (int k = 0; k < m1 / 2; k++)
                        {
                            result[i, j] += (this[i, 2 * k + 1] + second[2 * k, j]) * (this[i, 2 * k] + second[2 * k + 1, j]);
                        }
                    }
                }

                if (m1 % 2 == 1)
                {
                    for (int i = 0; i < n1; i++)
                    {
                        for (int j = 0; j < m2; j++)
                        {
                            result[i, j] += this[i, m1 - 1] * second[m1 - 1, j];
                        }
                    }
                }
            }

            return result;
        }
    }
}