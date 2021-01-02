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
        public bool isPolygonColorized = false;

        public Color Color { get => light.Color; }
        public Shader(LightSource lightSource, Dot3d viewerPlace, double ambientCoeff = 0.1, double specularPower = 1)
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
                coeffs = coeffs + GetCoeffInDot(dot);
            }
            coeffs = coeffs / pollygon.Size;
            Color ambientColor = MulltiplyColor(coeffs.X, Color.White);
            Color diffuse = MulltiplyColor(pollygon.Material.Diffuse * coeffs.Y, light.Color);
            Color specular = MulltiplyColor(pollygon.Material.Specular * coeffs.Z, light.Color);

            return Add(MulltiplyColor(pollygon.Material.ColorReflect, Add(ambientColor, diffuse)), specular);
        }

        public Vector3d GetCoeffInDot(Dot3d dot)
        {
            Vector3d lightVector = new Vector3d(light.Place - dot).Normalized();
            lightVector.Normalize();
            Vector3d H = (lightVector + new Vector3d(viewer - dot).Normalized());
            H.Normalize();
            double diffuse = Math.Max(0, (lightVector).DotProduct(dot.Normal));
            double specular = Math.Pow(Math.Max(0, (H).DotProduct(dot.Normal)), specularPower);

            return new Vector3d(ambient, diffuse, specular);
        }

        public static Color MulltiplyColor(double coeff, Color color)
        {
            coeff = coeff > 1 ? 1 : coeff;
            coeff = coeff < 0 ? 0 : coeff;
            return Color.FromArgb((int)(color.R * coeff), (int)(color.G * coeff), (int)(color.B * coeff));
        }

        public static Color MulltiplyColor(Vector3d coeff, Color color)
        {
            return Color.FromArgb((int)(color.R * coeff.X), (int)(color.G * coeff.Y), (int)(color.B * coeff.Z));
        }

        static public Color GetAnswerColor(Vector3d coeffs, Material material, Color lightColor)
        {
            Color ambientColor = MulltiplyColor(coeffs.X, Color.White);
            Color diffuse = MulltiplyColor(material.Diffuse * coeffs.Y, lightColor);
            Color specular = MulltiplyColor(material.Specular * coeffs.Z, lightColor);
            return Add(MulltiplyColor(material.ColorReflect, Add(ambientColor, diffuse)), specular);
        }

        public static Color Add(Color first, Color second)
        {
            int red = first.R + second.R;
            int green = first.G + second.G;
            int blue = first.B + second.B;
            return Color.FromArgb(red > 255 ? 255 : red, green > 255 ? 255 : green, blue > 255 ? 255 : blue);
        }

    }
}
