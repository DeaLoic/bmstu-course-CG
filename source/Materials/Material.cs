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
        Color color;

        public double Diffuse { get => diffuse; }
        public double Specular { get => specular; }

        public Material(double diffuseCoeff, double specularCoeff)
        {
            diffuse = diffuseCoeff;
            specular = specularCoeff;
        }

    }
}
