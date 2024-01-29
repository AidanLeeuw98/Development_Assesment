using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Development.Assesment.Data.Interfaces
{
    public interface IController
    {
        IActionResult Read(string service,int? id = null);
        IActionResult Update( object body, string service);
        IActionResult Delete( string body, string service);
        IActionResult Create( string body, string service);
    }
}
