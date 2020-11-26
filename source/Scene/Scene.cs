using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Scene
    {
        Object[] objects = new Object[0];
        public Camera camera = new Camera(new Dot3d(0, 0, 350));
        public LightSource lightSource = new LightSource(new Dot3d(), new Vector3d(0, 0, -1), Color.White);

        public Scene(){}

        public void AddObject(Object addingObject)
        {
            Array.Resize(ref objects, objects.Count() + 1);
            objects[objects.Count() - 1] = addingObject;
        }

        public Matrix4x4 GetMainTransform(int typeView = 0)
        {
            Matrix4x4 view;
            Matrix4x4 perspective;
            switch (typeView)
            {
                case 2:
                    view = camera.GetTransformToView();
                    break;
                case 1:
                    view = camera.GetLookAt();
                    break;
                default:
                    view = camera.GetView();
                    break;
            }
            perspective = camera.GetProjectionSimple();

            return view;
        }

        public ViewFrustum GetCameraFrustum()
        {
            return camera.GetTransformFrustum();
        }
        public Object[] GetObjects()
        {
            return this.objects;
        }
    }
}
