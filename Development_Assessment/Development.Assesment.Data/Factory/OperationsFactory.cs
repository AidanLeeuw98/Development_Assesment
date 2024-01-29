using Development.Assesment.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Development.Assesment.Data.Factory
{
    public class OperationsFactory : IOperationsFactory
    {
        private IServiceProvider _serviceProvider;
        public OperationsFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IOperations GetService<TService>() where TService : IOperations =>
            _serviceProvider.GetService<TService>();

    }
}
