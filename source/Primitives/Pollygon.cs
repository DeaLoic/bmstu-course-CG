using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Pollygon
    {
        protected Dot3d[] dots = new Dot3d[0];
        protected Vector3d normal = new Vector3d();

        public int Size { get => dots.Length; }
        public Dot3d this[int a] { get => dots[a]; }
        public Pollygon(Dot3d[] dots)
        {
            if (dots != null)
            {
                this.dots = new Dot3d[dots.Length];
                for (int i = 0; i < dots.Length; i++)
                {
                    this.dots[i] = dots[i];
                }
                if (dots.Length > 2)
                {
                    normal = new Vector3d(dots[1].Normilized() - dots[0].Normilized()).Cross(new Vector3d(dots[2].Normilized() - dots[0].Normilized()));
                    normal.Normalize();
                }
            }
        }

        public void Transform(Matrix4x4 transform)
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i] = transform.Apply(dots[i]);
            }
        }
        public void Normilize()
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].Normilize();
            }
        }
        public Vector3d Normal()
        {
            return normal.Copy();
        }
        public void ChangeNormalSign()
        {
            normal = -normal;
        }

        public Dot3d[] GetDots()
        {
            return dots;
        }
    }
}
