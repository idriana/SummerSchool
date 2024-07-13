using SummerSchoolGUI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.GameCommands
{
    public record EntityListCommand : IValueCommand<List<Entity>>
    {
        public List<Entity> Value { get; set; }

        internal EntityListCommand(List<Entity> entities)
        {
            Value = entities;
        }
    }

    public class EntityListCommandFactory : IValueCommandFactory<EntityListCommand, List<Entity>>
    {
        public ICommand CreateCommand(List<Entity> data) 
        {
            return new EntityListCommand(data);
        }
    }
}
