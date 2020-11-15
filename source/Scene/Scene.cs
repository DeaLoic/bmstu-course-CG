using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Scene
    {
        Object[] objects = new Object[0];
        public Camera camera = new Camera(new Dot3d(0, 0, 10));

        public Scene(){}

        public void AddObject(Object addingObject)
        {
            Array.Resize(ref objects, objects.Count() + 1);
            objects[objects.Count() - 1] = addingObject;
        }

        public Matrix4x4 GetMainTransform()
        {
            Matrix4x4 transform = new Matrix4x4();
            transform.SetScaleGlobal(20);
            return camera.GetLookAt() * transform;// * camera.GetProjection();// * transform;
        }

        public Object[] GetObjects()
        {
            return this.objects;
        }
    }
}
