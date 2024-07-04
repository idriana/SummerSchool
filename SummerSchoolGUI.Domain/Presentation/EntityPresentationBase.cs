using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public abstract class EntityPresentationBase 
    {
        float posX;
        float posY;
        float rotX;
        float rotY;
        float scaleX;
        float scaleY;

        public float PosX { get { return posX; } set { posX = value; } }
        public float PosY { get { return posY; } set { posY = value; } }
        public float RotX { get { return rotX; } set { rotX = value; } }
        public float RotY { get { return rotY; } set { rotY = value; } }
        public float ScaleX { get { return scaleX; } set { scaleX = value; } }
        public float ScaleY { get { return scaleY; } set { scaleY = value; } }
    }
}
