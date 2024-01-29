using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Development.Assesment.Data.Interfaces
{
    public interface IOperations
    {
        object Read(int? id = null);
        bool Update(object body);
        bool Delete(string body);
        bool Create(string body);
    }
}
