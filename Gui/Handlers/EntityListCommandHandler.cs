using Commands.GameCommands;
using MyEngine.Ecs;
using SummerSchoolGUI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commands;
using MyEngine.Gui.DataConverters;
using MyEngine.Ecs.Components;

namespace MyEngine.Gui.Handlers
{
    public class EntityListCommandHandler : IECSHandler
    {
        private MyEcs _ecs;
        private Converter _converter;
        public MyEcs Ecs { get { return _ecs; } }
        public Converter Converter { get { return _converter; } }

        public EntityListCommandHandler(MyEcs ecs, Converter converter) 
        { 
            _ecs = ecs;
            _converter = converter;
        }

        public void Execute(ICommand command)
        {
            if (command is EntityListCommand entityListCommand)
            {
                List<Entity> entities = entityListCommand.Value;
                foreach (Entity entity in entities)
                {
                    foreach (IComponent guiComponent in entity.components)
                    {
                        IECSComponent ecsComponent = _converter.Convert(guiComponent);
                        _ecs.UpdateEntity(entity.ID, ecsComponent);
                    }
                }
            }
            else
            {
                throw new ArgumentException($"Expected command of type EntityListCommand, got {command.GetType()}");
            }
        }
    }
}
