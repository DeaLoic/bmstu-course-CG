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
        public Camera camera = new Camera(new Dot3d(0, 0, -350));
        public LightSource lightSource = new LightSource(new Dot3d(), new Vector3d(0, 0, -1), Color.White);

        public Scene(){}

        public void AddObject(Object addingObject)
        {
            Array.Resize(ref objects, objects.Count() + 1);
            objects[objects.Count() - 1] = addingObject;
        }

        public void SetLight(Dot3d place)
        {
            lightSource.SetPlace(place);
        }
        public Matrix4x4 GetMainTransform()
        {
            Matrix4x4 view;
            Matrix4x4 perspective;

            view = camera.GetLookAt();
            perspective = camera.GetProjectionSimple();

            return view * perspective;
        }

        public ViewFrustum GetCameraFrustum()
        {
            return camera.GetTransformFrustum();
        }
        public Object[] GetObjects()
        {
            return this.objects;
        }

        public void DeleteObjects()
        {
            Array.Resize(ref objects, 0);
        }
    }
}
