using Microsoft.Practices.ServiceLocation;
using Triangle.SharedKernel.Interfaces;

namespace Triangle.SharedKernel
{
    public class DomainEvents
    {
        public static void Initialize(IServiceLocator ServiceLocator)
        {
            serviceLocator = ServiceLocator;
        }

        private static IServiceLocator serviceLocator;

        public static void Raise<T>(T Event) where T : IDomainEvent
        {
            var handlers = serviceLocator.GetAllInstances<IHandle<T>>();
            foreach (var handler in handlers)
            {
                handler.Handle(Event);
            }
        }
    }
}