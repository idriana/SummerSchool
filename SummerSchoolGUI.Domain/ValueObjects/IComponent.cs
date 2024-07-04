using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.Domain.ValueObjects
{
    public interface IComponent
    {
        public abstract IComponent Copy();
    }
}
