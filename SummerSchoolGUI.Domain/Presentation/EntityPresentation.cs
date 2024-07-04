using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class EntityPresentation : EntityPresentationBase
    {
        public EntityPresentation(float PosX, float PosY, float RotX, float RotY, float ScaleX, float ScaleY) 
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.RotX = RotX;
            this.RotY = RotY;
            this.ScaleX = ScaleX;
            this.ScaleY = ScaleY;
        }
    }
}
