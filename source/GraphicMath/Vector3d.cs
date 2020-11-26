using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Vector3d
    {
        double x;
        public double X { get => x; }
        double y;
        public double Y { get => y; }
        double z;
        public double Z { get => z; }
        double w;
        public double W { get => w; }

        double length;
        public double Length { get => length; }

        public Vector3d(Dot3d dot)
        {
            x = dot.X;
            y = dot.Y;
            z = dot.Z;
            w = dot.W;
            CountLenght();
        }

        public Vector3d(double x = 0, double y = 0, double z = 0, double w = 1)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
            CountLenght();
        }

        private void CountLenght()
        {
            length = Math.Sqrt(x * x + y * y + z * z);
        }
        public Vector3d Normalized()
        {
            return this / (this.Length > 0 ? this.Length : 1);
        }
        public void Normalize()
        {
            length = Length == 0 ? 1 : Length;
            this.x = x / Length;
            this.y = y / Length;
            this.z = z / Length;
            this.w = 1;
            CountLenght();
        }
        public Vector3d Copy()
        {
            return new Vector3d(x, y, z, w);
        }

        public double DotProduct(Vector3d first)
        {
            return x * first.x + y * first.y + z * first.z;
        }
        public Vector3d Cross(Vector3d first)
        {
            return new Vector3d(y * first.z - z * first.y, z * first.x - x * first.z, x * first.y - y * first.x);
        }

        public Dot3d ToDot()
        {
            return new Dot3d(X, Y, Z, W);
        }
        public static Vector3d operator +(Vector3d first, Vector3d second)
        {
            return new Vector3d(first.x + second.x, first.y + second.y, first.z + second.z, first.w);
        }
        public static Vector3d operator -(Vector3d first, Vector3d second)
        {
            return new Vector3d(first.x - second.x, first.y - second.y, first.z - second.z, first.w);
        }
        public static Vector3d operator *(Vector3d first, double s)
        {
            return new Vector3d(first.x * s, first.y * s, first.z * s, first.w);
        }
        public static Vector3d operator /(Vector3d first, double s)
        {
            s = s != 0 ? s : 1;
            return new Vector3d(first.x / s, first.y / s, first.z / s, first.w);
        }
        public static Vector3d operator -(Vector3d first)
        {
            return new Vector3d(-first.x, -first.y, -first.z, first.w);
        }

        public static Dot3d operator +(Dot3d first, Vector3d second)
        {
            return new Dot3d(first.X + second.x, first.Y + second.y, first.Z + second.z, second.w);
        }
        public static Dot3d operator -(Dot3d first, Vector3d second)
        {
            return new Dot3d(first.X - second.x, first.Y - second.y, first.Z - second.z, second.w);
        }
    }
}
