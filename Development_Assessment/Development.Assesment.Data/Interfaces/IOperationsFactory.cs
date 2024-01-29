using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Development.Assesment.Data.Interfaces
{
    public interface IOperationsFactory
    {
        IOperations GetService<TService>() where TService : IOperations;
    }
}
