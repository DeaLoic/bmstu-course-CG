using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Matrix4x4
    {
        int n = 4;
        int m = 4;
        double[,] body;

        public int N { get => n; }
        public int M { get => m; }

        public double this[int i, int j]
        {
            get { return body[i, j]; }
            set { body[i, j] = value; }
        }
        public Matrix4x4()
        {
            this.body = new double[this.n, this.m];
            this[0, 0] = 1;
            this[1, 1] = 1;
            this[2, 2] = 1;
            this[3, 3] = 1;
        }

        public Matrix4x4(Vector3d vecForward, Vector3d vecUp, Vector3d vecRight, Vector3d vecPosition) : this()
        {
            this[0, 0] = vecForward.X;
            this[0, 1] = vecForward.Y;
            this[0, 2] = vecForward.Z;

            this[1, 0] = vecUp.X;
            this[1, 1] = vecUp.Y;
            this[1, 2] = vecUp.Z;

            this[2, 0] = vecRight.X;
            this[2, 1] = vecRight.Y;
            this[2, 2] = vecRight.Z;

            this[3, 0] = vecPosition.X;
            this[3, 1] = vecPosition.Y;
            this[3, 2] = vecPosition.Z;

            this[0, 3] = 0;
            this[1, 3] = 0;
            this[2, 3] = 0;
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
        
        public Matrix4x4 Transposed()
        {
            Matrix4x4 M = new Matrix4x4();

            // Create the transposed upper 3x3 matrix
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    M[i,j] = this[j,i];
                }
            }

            return M;
        }

        public static Matrix4x4 operator *(Matrix4x4 first, Matrix4x4 second)
        {
            return first.MultiplyVinograd(second);
        }
        public static Vector3d operator *(Vector3d first, Matrix4x4 second)
        {
            Vector3d vecResult = new Vector3d(
                first.X * second[0, 0] + first.Y * second[1, 0] + first.Z * second[2, 0] + first.W * second[3, 0],
                first.X * second[0, 1] + first.Y * second[1, 1] + first.Z * second[2, 1] + first.W * second[3, 1],
                first.X * second[0, 2] + first.Y * second[1, 2] + first.Z * second[2, 2] + first.W * second[3, 2],
                first.X * second[0, 3] + first.Y * second[1, 3] + first.Z * second[2, 3] + first.W * second[3, 3]
                );

            return vecResult;
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

            Matrix4x4 matrix = new Matrix4x4();
            matrix[0, 0] = Math.Cos(oz);
            matrix[1, 1] = matrix[0, 0];
            matrix[0, 1] = Math.Sin(oz);
            matrix[1, 0] = -matrix[0, 1];
            matrix = (Matrix4x4)MultiplyVinograd(matrix);
            this.Reset();
            this[0, 0] = Math.Cos(oy);
            this[2, 2] = this[0, 0];
            this[2, 0] = Math.Sin(oy);
            this[0, 2] = -this[2, 0];
            matrix = (Matrix4x4)matrix.MultiplyVinograd(this);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    this[i, j] = matrix[i, j];
                }
            }
        }

        public void SetRotateAxis(double ox, double oy, double oz, Vector3d xaxis, Vector3d yaxis, Vector3d zaxis)
        {
            Matrix4x4 changeOrt = new Matrix4x4();
            changeOrt.SetChangeOrts(xaxis, yaxis, zaxis);
            Matrix4x4 matrix = new Matrix4x4();
            matrix.SetRotate(ox, oy, oz);

            this.body = (changeOrt * matrix * changeOrt.Transposed()).body;
        }

        public void SetChangeOrts(Vector3d xaxis, Vector3d yaxis, Vector3d zaxis)
        {
            this[0, 0] = xaxis.X; this[0, 1] = yaxis.X; this[0, 2] = zaxis.X; this[0, 3] = 0;
            this[1, 0] = xaxis.Y; this[1, 1] = yaxis.Y; this[1, 2] = zaxis.Y; this[1, 3] = 0;
            this[2, 0] = xaxis.Z; this[2, 1] = yaxis.Z; this[2, 2] = zaxis.Z; this[2, 3] = 0;
            this[3, 0] = 0; this[3, 1] = 0; this[3, 2] = 0; this[3, 3] = 1;
        }

        public Dot3d Apply(Dot3d dot)
        {
            Vector3d dotVector;

            dotVector = (new Vector3d(dot) * this);
            return new Dot3d(dotVector.X, dotVector.Y, dotVector.Z, dotVector.W, dot.Normal);
        }

        public Matrix4x4 MultiplyVinograd(Matrix4x4 second)
        {
            Matrix4x4 result = new Matrix4x4();
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