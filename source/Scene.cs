using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinLandscape
{
    class Scene
    {
        Object[] objects = new Object[0];
        public Camera camera = new Camera(new Dot3d(0, 0, 0));

        public Scene(){}

        public void AddObject(Object addingObject)
        {
            Array.Resize(ref objects, objects.Count() + 1);
            objects[objects.Count() - 1] = addingObject;
        }

        public Object[] GetObjects()
        {
            return this.objects;
        }
    }
}
