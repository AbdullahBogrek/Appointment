using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Applications.ServiceOperations.Commands.CreateService;
using WebApi.Applications.ServiceOperations.Commands.DeleteService;
using WebApi.Applications.ServiceOperations.Queries.GetServiceDetail;
using WebApi.Applications.ServiceOperations.Queries.GetServices;
using WebApi.Applications.ServiceOperations.Commands.UpdateService;
using static WebApi.Applications.ServiceOperations.Commands.CreateService.CreateServiceCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceDbContext _context;

        public ServiceController (ServiceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetServices()
        {
            GetServicesQuery query = new GetServicesQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetServiceById(int id)
        {
            ServiceDetailViewModel result;
            GetServiceDetailQuery query = new GetServiceDetailQuery(_context);
            query.ServiceId = id;

            GetServiceDetailQueryValidator validator = new GetServiceDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateService([FromBody] CreateServiceModel newService)
        {
            CreateServiceCommand command = new CreateServiceCommand(_context);
            command.Model = newService;

            CreateServiceCommandValidator validator = new CreateServiceCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateService(int id, [FromBody] UpdateServiceModel updateService)
        {
            UpdateServiceCommand command = new UpdateServiceCommand(_context);
            command.ServiceId = id;
            command.Model = updateService;
            
            UpdateServiceCommandValidator validator = new UpdateServiceCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            DeleteServiceCommand command = new DeleteServiceCommand(_context);
            command.ServiceId = id;

            DeleteServiceCommandValidator validator = new DeleteServiceCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        }
    }

}