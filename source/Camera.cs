using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Camera
    {
        Dot3d place;
        int focus;
        int widthSee;
        Dot3d rotate;

        TransformationMove3d transformDot = new TransformationMove3d(0, 0, 0);

        public Camera(Dot3d place, int angleY = 0, int focus = 30, int widthSee = 60)
        {
            this.place = place;
            this.focus = focus;
            this.widthSee = widthSee;
            rotate = new Dot3d(0, 0, 0);
        }

        public void Move(int dx, int dy, int dz)
        {
            place.X += dx;
            place.Y += dy;
            place.Z += dz;
        }

        public void Rotate(int ox, int oy, int oz)
        {
            rotate.X += ox;
            rotate.Y += oy;
            rotate.Z += oz;
        }

        public Dot3d GetTransform(Dot3d dot)
        {
            TransformationMove3d moveT = new TransformationMove3d(place.X, place.Y, place.Z);
            Dot3d newDot = moveT.Apply(dot);
            TransformationRotate3d rotateT = new TransformationRotate3d(rotate.X, rotate.Y, rotate.Z, place);
            newDot = rotateT.Apply(newDot);

            return newDot;
        }
    }
}
