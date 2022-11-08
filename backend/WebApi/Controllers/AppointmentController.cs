using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Applications.AppointmentOperations.Commands.CreateAppointment;
using WebApi.Applications.AppointmentOperations.Commands.DeleteAppointment;
using WebApi.Applications.AppointmentOperations.Queries.GetAppointmentDetail;
using WebApi.Applications.AppointmentOperations.Queries.GetAppointments;
using WebApi.Applications.AppointmentOperations.Commands.UpdateAppointment;
using WebApi.DBOperations;
using static WebApi.Applications.AppointmentOperations.Commands.CreateAppointment.CreateAppointmentCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class AppointmentController : ControllerBase
    {   

        private readonly AppointmentDbContext _context;

        public AppointmentController (AppointmentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAppointments()
        {
            GetAppointmentsQuery query = new GetAppointmentsQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAppointmentById(int id)
        {
            AppointmentDetailViewModel result;
            GetAppointmentDetailQuery query = new GetAppointmentDetailQuery(_context);
            query.AppointmentId = id;
            
            GetAppointmentDetailQueryValidator validator = new GetAppointmentDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAppointment([FromBody] CreateAppointmentModel newAppointment)
        {

            CreateAppointmentCommand command = new CreateAppointmentCommand(_context);
            command.Model = newAppointment;
                
            CreateAppointmentCommandValidator validator = new CreateAppointmentCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, [FromBody] UpdateAppointmentModel updateAppointment)
        {
            UpdateAppointmentCommand command = new UpdateAppointmentCommand(_context);
            command.AppointmentId = id;
            command.Model = updateAppointment;

            UpdateAppointmentCommandValidator validator = new UpdateAppointmentCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            DeleteAppointmentCommand command = new DeleteAppointmentCommand(_context);
            command.AppointmentId = id;

            DeleteAppointmentCommandValidator validator = new DeleteAppointmentCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
             
            return Ok();
        }

    }
    
}