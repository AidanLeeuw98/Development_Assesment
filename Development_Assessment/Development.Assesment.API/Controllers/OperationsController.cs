using Development.Assesment.Data.Helper;
using Development.Assesment.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Development.Assesment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController : Controller, IController
    {
        private IOperationsFactory _operationsFactory;
        public OperationsController(IOperationsFactory operationsFactory)
        {
            _operationsFactory = operationsFactory;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] string body, string service)
        {
            try
            {
                return Ok(OperationsHelper.GetOperations(service, _operationsFactory).Create(body));
            }
            catch (Exception)
            {
                return BadRequest("Error occurred when trying to add new item");
            }
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] string body, string service)
        {
            try
            {
                return Ok(OperationsHelper.GetOperations(service, _operationsFactory).Delete(body));
            }
            catch (Exception)
            {
                return BadRequest("Error occurred when trying to delete item");
            }
        }

        [HttpGet("Read")]
        public IActionResult Read(string service, int? id = null)
        {
            try
            {
                return Ok(OperationsHelper.GetOperations(service, _operationsFactory).Read(id));
            }
            catch (Exception)
            {
                return BadRequest("Error occurred when trying to load item(s)");
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] object data, string service)
        {
            try
            {
                return Ok(OperationsHelper.GetOperations(service, _operationsFactory).Update(data));
            }
            catch (Exception)
            {
                return BadRequest("Error occurred when trying to update item");
            }
        }
    }
}
