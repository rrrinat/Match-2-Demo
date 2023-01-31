using Match2.Partial.Gameplay.Entities;
using VContainer;

namespace Match2.Partial.Gameplay.Factories
{
    public class FieldFactory : IFieldFactory
    {
        private IObjectResolver container;
        
        public FieldFactory(IObjectResolver container)
        {
            this.container = container;
        }
        
        public IField Create()
        {
            var field = new Field();
            container.Inject(field);
            field.Initialize();
            
            return field;
        }
    }
}