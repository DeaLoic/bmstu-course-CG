using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Material
    {
        double diffuse;
        double specular;
        protected Vector3d colorReflect = new Vector3d(0.8, 0, 0.2);

        public double Diffuse { get => diffuse; }
        public double Specular { get => specular; }
        public Vector3d ColorReflect { get => colorReflect; }

        public Material(double diffuseCoeff, double specularCoeff, Vector3d colorReflect = null)
        {
            diffuse = diffuseCoeff;
            specular = specularCoeff;
            if (colorReflect != null)
            {
                this.colorReflect = colorReflect.Copy();
            }
        }

        protected Vector3d ReflectFromColor(Color color)
        {
            return new Vector3d(color.R / 255.0, color.G / 255.0, color.B / 255.0);
        }

    }
}
