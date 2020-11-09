using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    abstract class Transformation3d
    {
        public abstract Dot3d Apply(Dot3d dot);
    }

    class TransformationRotate3d : Transformation3d
    {
        double ox, oy, oz;
        Dot3d rotateCenter;

        public TransformationRotate3d(double ox, double oy, double oz, Dot3d rotateCenter)
        {
            this.ox = ox; this.oy = oy; this.oz = oz; this.rotateCenter = rotateCenter;
        }

        public override Dot3d Apply(Dot3d dot)
        {
            double x_tmp = dot.X;
            double y_tmp = dot.Y;
            double z_tmp = dot.Z;
            RotateX(ref y_tmp, ref z_tmp, ox);
            RotateY(ref x_tmp, ref z_tmp, oy);
            RotateZ(ref x_tmp, ref y_tmp, oz);

            return new Dot3d((int)x_tmp, (int)y_tmp, (int)z_tmp);
        }

        void RotateX(ref double y, ref double z, double tetax)
        {
            tetax = tetax * Math.PI / 180;
            double buf = y;
            y = rotateCenter.Y + Math.Cos(tetax) * (y - rotateCenter.Y) - Math.Sin(tetax) * z;
            z = Math.Cos(tetax) * z + Math.Sin(tetax) * (buf - rotateCenter.Y);
        }

        void RotateZ(ref double x, ref double y, double tetaz)
        {
            tetaz = tetaz * Math.PI / 180;
            double buf = x;
            x = rotateCenter.X + Math.Cos(tetaz) * (x - rotateCenter.X) - Math.Sin(tetaz) * (y - rotateCenter.Y);
            y = rotateCenter.Y + Math.Cos(tetaz) * (y - rotateCenter.Y) + Math.Sin(tetaz) * (buf - rotateCenter.X);
        }

        void RotateY(ref double x, ref double z, double tetay)
        {
            tetay = tetay * Math.PI / 180;
            double buf = x;
            x = rotateCenter.X + Math.Cos(tetay) * (x - rotateCenter.X) - Math.Sin(tetay) * z;
            z = Math.Cos(tetay) * z + Math.Sin(tetay) * (buf - rotateCenter.X);
        }
    }

    class TransformationMove3d : Transformation3d
    {
        int dx, dy, dz;
        public TransformationMove3d(int dx, int dy, int dz)
        {
            this.dx = dx; this.dy = dy; this.dz = dz;
        }
        public override Dot3d Apply(Dot3d dot)
        {
            return new Dot3d(dot.X + dx, dot.Y + dy, dot.Z + dz);
        }
    }

    class TransformationScale3d : Transformation3d
    {
        double kx, ky, kz;
        public TransformationScale3d(double kx, double ky, double kz)
        {
            this.kx = kx; this.ky = ky; this.kz = kz;
        }
        public override Dot3d Apply(Dot3d dot)
        {
            return new Dot3d((int)(dot.X * kx), (int)(dot.Y * ky), (int)(dot.Z * kz));
        }
    }
}
