using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PerlinLandscape
{
    class Converter
    {
        private PointF min;
        private PointF max;
        private Size area;
        private int indent;
        private int indentX;
        private int indentY;
        private float scale;

        public Converter(PointF min, PointF max, Size area, int indent = 0)
        {
            this.min = min;
            this.max = max;
            this.area = area;
            this.indent = indent;

        }

        public PointF ConvertDot(PointF point)
        {
            PointF resultPoint = new PointF();

            resultPoint.X = ConvertX(point.X);
            resultPoint.Y = ConvertY(point.Y);

            return resultPoint;
        }

        public PointF ConvertDotOffset(PointF point)
        {
            PointF resultPoint = ConvertDot(point);

            resultPoint.X += indent;
            resultPoint.Y += indent;

            return point;
        }

        public float ConvertSize(float size)
        {
            return size * scale;
        }
        private float ConvertY(float y)
        {
            return ((max.Y - y) * scale);
        }

        private float ConvertX(float x)
        {
            return ((x - min.X) * scale);
        }
    }
}
