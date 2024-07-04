using SummerSchoolGUI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.GameCommands
{
    public record EntityListCommand : IGameCommand<List<Entity>>
    {
        public List<Entity> Value { get; set; }
    }
}
