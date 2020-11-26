using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class ViewFrustum
    {
        Dot3d A, B, C, D; // near
        Dot3d E, F, G, H; // far

        Cutter near;
        Cutter far;
        Cutter left;
        Cutter right;
        Cutter upper;
        Cutter under;

        public ViewFrustum(Dot3d center, Vector3d up, Vector3d lookVector, int fovWidth, int fovHeight, double nearDistance, double farDistance)
        {
            double tanWidth = Math.Tan(MathSupport.ToRadian(fovWidth / (double)2));
            double tanHeight = Math.Tan(MathSupport.ToRadian(fovHeight / (double)2));
            lookVector = lookVector.Normalized();
            if (lookVector.Lenght == 0)
            {
                lookVector = new Vector3d(0, 0, -1);
            }

            up = up.Normalized();
            Vector3d widthVec = up.Cross(lookVector).Normalized();
            up = widthVec.Cross(lookVector).Normalized();


            Vector3d offsetVec = new Vector3d(center);
            Vector3d nearBase = offsetVec + lookVector * nearDistance;
            Vector3d nearUp = up * (nearDistance * tanHeight);
            Vector3d nearRight = widthVec * (nearDistance * tanWidth);
            A = (nearBase + nearUp - nearRight).ToDot();
            B = (nearBase + nearUp + nearRight).ToDot();
            C = (nearBase - nearUp + nearRight).ToDot();
            D = (nearBase - nearUp - nearRight).ToDot();

            Vector3d farBase = offsetVec + lookVector * farDistance;
            Vector3d farUp = up * (farDistance * tanHeight);
            Vector3d farRight = widthVec * (farDistance * tanWidth);
            E = (farBase + farUp - farRight).ToDot();
            F = (farBase + farUp + farRight).ToDot();
            G = (farBase - farUp + farRight).ToDot();
            H = (farBase - farUp - farRight).ToDot();

            Dot3d controlDot = farBase.ToDot();
            near = new Cutter(new Dot3d[] { A, B, C, D });
            if (!near.IsDotOnRightSide(controlDot))
            {
                near.ChangeNormalSign();
            }

            far = new Cutter(new Dot3d[] { E, F, G, H  });
            if (!far.IsDotOnRightSide(center))
            {
                far.ChangeNormalSign();
            }

            left = new Cutter(new Dot3d[] { A, E, H, D });
            if (!left.IsDotOnRightSide(controlDot))
            {
                left.ChangeNormalSign();
            }

            right = new Cutter(new Dot3d[] { B, F, G, C });
            if (!right.IsDotOnRightSide(controlDot))
            {
                right.ChangeNormalSign();
            }

            upper = new Cutter(new Dot3d[] { A, E, F, B });
            if (!upper.IsDotOnRightSide(controlDot))
            {
                upper.ChangeNormalSign();
            }

            under = new Cutter(new Dot3d[] { D, H, G, C });
            if (!under.IsDotOnRightSide(controlDot))
            {
                under.ChangeNormalSign();
            }

        }

        public PollygonDraw Clip(PollygonDraw pollygon)
        {
            PollygonDraw result = near.Clip(pollygon);
            if (result.Size > 0)
            {
                result = far.Clip(result);
            }
            /*
            if (result.Size > 0)
            {
                result = left.Clip(result);
            }
            if (result.Size > 0)
            {
                result = right.Clip(result);
            }
            if (result.Size > 0)
            {
                result = upper.Clip(result);
            }
            if (result.Size > 0)
            {
                result = under.Clip(result);
            }
            */
            return result;
        }
    }
}
