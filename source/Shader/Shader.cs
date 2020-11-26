using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Shader
    {
        LightSource light;
        Dot3d viewer;
        double ambient;
        double specularPower = 1;
        public Shader(LightSource lightSource, Dot3d viewerPlace, double ambientCoeff = 0.1, double specularPower = 10)
        {
            light = lightSource;
            viewer = viewerPlace;
            this.ambient = ambientCoeff;
            this.specularPower = specularPower;
        }

        public Color GetColorSimple(PollygonDraw pollygon)
        {
            Vector3d normal = pollygon.Normal();

            Vector3d coeffs = new Vector3d();
            foreach (Dot3d dot in pollygon.GetDots())
            {
                coeffs = coeffs + GetCoeffInDot(dot, normal, pollygon.Material);
            }
            coeffs = coeffs / pollygon.Size;
            Color ambientColor = MulltiplyColor(coeffs.X, pollygon.color);
            Color diffuse = MulltiplyColor(coeffs.Y, pollygon.color);
            Color specular = MulltiplyColor(coeffs.Z, light.Color);

            return Add(Add(ambientColor, diffuse), specular);
        }

        public Vector3d GetCoeffInDot(Dot3d dot, Vector3d normal, Material material)
        {
            Vector3d lightVector = new Vector3d(viewer - dot);
            Vector3d H = (lightVector + new Vector3d(viewer - dot).Normalized());
            H.Normalize();
            double diffuse = material.Diffuse * Math.Max(0, (lightVector).DotProduct(normal));
            double specular = material.Specular * Math.Pow(Math.Max(0, (H).DotProduct(normal)), specularPower);

            return new Vector3d(ambient, diffuse, specular);
        }

        public Color MulltiplyColor(double coeff, Color color)
        {
            coeff = coeff > 1 ? 1 : coeff;
            coeff = coeff < 0 ? 0 : coeff;
            return Color.FromArgb((int)(color.R * coeff), (int)(color.G * coeff), (int)(color.B * coeff));
        }
        public Color Add(Color first, Color second)
        {
            int red = first.R + second.R;
            int green = first.G + second.G;
            int blue = first.B + second.B;
            return Color.FromArgb(red > 255 ? 255 : red, green > 255 ? 255 : green, blue > 255 ? 255 : blue);
        }
        public Color Mix(Color a, Color b, float aPers)
        {
            aPers = Math.Min(aPers, 1);
            float bPers = 1 - aPers;
            int red = (int)(a.R * aPers + b.R * bPers);
            int green = (int)(a.G * aPers + b.G * bPers);
            int blue = (int)(a.B * aPers + b.B * bPers);

            return Color.FromArgb(red, green, blue);
        }
    }
}
