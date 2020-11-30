using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Vertex : DotDraw
    {
        PollygonDraw[] neighborsPolygons = new PollygonDraw[0];
        public Vertex(double x = 0, double y = 0, double z = 0, double w = 1) : base(x, y, z, w) { }
        public Vertex(Vertex first, Vertex second, double coeff) : base(first.X + coeff * (second.X - first.X),
                                                                        first.Y + coeff * (second.Y - first.Y),
                                                                        first.Z + coeff * (second.Z - first.Z),
                                                                        first.W + coeff * (second.W - first.W))
        {
            int min = Math.Min(second.interpolatedValues.Length, first.interpolatedValues.Length);
            for (int i = 0; i < min; i++)
            {
                AddInterpolatedValue(first.GetInterpolatedValue(0) + coeff * (second.GetInterpolatedValue(0) - first.GetInterpolatedValue(0)));
            }
        }
        public void AddNeighborPolygon(PollygonDraw polygon)
        {
            Array.Resize(ref neighborsPolygons, neighborsPolygons.Length + 1);
            neighborsPolygons[neighborsPolygons.Length - 1] = polygon;
        }

        public PollygonDraw[] GetNeighborsPolygons()
        {
            return neighborsPolygons;
        }
    }
}
