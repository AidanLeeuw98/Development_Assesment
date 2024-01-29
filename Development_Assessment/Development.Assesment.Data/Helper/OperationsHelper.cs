using Development.Assesment.Data.Interfaces;
using Development.Assesment.Data.Operations;

namespace Development.Assesment.Data.Helper
{
    public static class OperationsHelper
    {

        public static IOperations GetOperations(string service, IOperationsFactory operationsFactory)
        {
            switch (service)
            {
                case "User":
                    return GetService<IUserOperations>(operationsFactory);
                case "Group":
                    return GetService<IGroupOperations>(operationsFactory);
                case "Permission":
                    return GetService<IPermissionOperations>(operationsFactory);
                default:
                    throw new NotImplementedException();
            }
        }

        private static IOperations GetService<TService>(IOperationsFactory operationsFactory) where TService : IOperations 
        { 
            return operationsFactory.GetService<TService>();
        }
    }
}
