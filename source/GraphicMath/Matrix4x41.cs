using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    /*
    class Matrix4x4
    {
        int n;
        int m;
        double[,] body;

        public int N { get => n; }
        public int M { get => m; }

        public Matrix4x4(int n, int m)
        {
            this.n = n >= 0 ? n : 0;
            this.m = m >= 0 ? m : 0;
            this.body = new double[this.n, this.m];
        }

        public double this[int i, int j]
        {
            get { return body[i, j]; }
            set { body[i, j] = value; }
        }

        public Matrix4x4 MultiplyVinograd(Matrix4x4 second)
        {
            Matrix4x4 result = new Matrix4x4(0, 0);
            if (this.M == second.N && this.N != 0 && second.M != 0)
            {
                int n1 = this.N;
                int m1 = this.M;
                int n2 = second.N;
                int m2 = second.M;

                result = new Matrix4x4(n1, m2);
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
    */
}
