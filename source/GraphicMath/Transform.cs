using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    static class Transformation3d
    {
        public static Dot3d Move(Dot3d dot, int dx, int dy, int dz)
        {
            return new Dot3d(dot.X + dx, dot.Y + dy, dot.Z + dz);
        }
        public static Dot3d Rotate(Dot3d dot, double ox, double oy, double oz, Dot3d rotateCenter)
        {
            
            double x_tmp = dot.X;
            double y_tmp = dot.Y;
            double z_tmp = dot.Z;
            RotateX(ref y_tmp, ref z_tmp, ox, rotateCenter);
            RotateY(ref x_tmp, ref z_tmp, oy, rotateCenter);
            RotateZ(ref x_tmp, ref y_tmp, oz, rotateCenter);

            return new Dot3d(x_tmp, y_tmp, z_tmp);
        }
        public static Dot3d Scale(Dot3d dot, double kx, double ky, double kz, Dot3d scaleCenter)
        {
            return new Dot3d((int)(dot.X * kx), (int)(dot.Y * ky), (int)(dot.Z * kz));
        }

    static void RotateX(ref double y, ref double z, double tetax, Dot3d rotateCenter)
        {
            tetax = tetax * Math.PI / 180;
            double buf = y;
            y = rotateCenter.Y + Math.Cos(tetax) * (y - rotateCenter.Y) - Math.Sin(tetax) * z;
            z = Math.Cos(tetax) * z + Math.Sin(tetax) * (buf - rotateCenter.Y);
        }

        static void RotateZ(ref double x, ref double y, double tetaz, Dot3d rotateCenter)
        {
            tetaz = tetaz * Math.PI / 180;
            double buf = x;
            x = rotateCenter.X + Math.Cos(tetaz) * (x - rotateCenter.X) - Math.Sin(tetaz) * (y - rotateCenter.Y);
            y = rotateCenter.Y + Math.Cos(tetaz) * (y - rotateCenter.Y) + Math.Sin(tetaz) * (buf - rotateCenter.X);
        }

        static void RotateY(ref double x, ref double z, double tetay, Dot3d rotateCenter)
        {
            tetay = tetay * Math.PI / 180;
            double buf = x;
            x = rotateCenter.X + Math.Cos(tetay) * (x - rotateCenter.X) - Math.Sin(tetay) * z;
            z = Math.Cos(tetay) * z + Math.Sin(tetay) * (buf - rotateCenter.X);
        }
    }
}
