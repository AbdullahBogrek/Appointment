using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Applications.StaffOperations.Commands.CreateStaff;
using WebApi.Applications.StaffOperations.Commands.DeleteStaff;
using WebApi.Applications.StaffOperations.Queries.GetStaffDetail;
using WebApi.Applications.StaffOperations.Queries.GetStaffs;
using WebApi.Applications.StaffOperations.Commands.UpdateStaff;
using static WebApi.Applications.StaffOperations.Commands.CreateStaff.CreateStaffCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class StaffController : ControllerBase
    {
        private readonly StaffDbContext _context;

        public StaffController (StaffDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStaffs()
        {
            GetStaffsQuery query = new GetStaffsQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetStaffById(int id)
        {
            StaffDetailViewModel result;
            GetStaffDetailQuery query = new GetStaffDetailQuery(_context);
            query.StaffId = id;

            GetStaffDetailQueryValidator validator = new GetStaffDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateStaff([FromBody] CreateStaffModel newStaff)
        {
            CreateStaffCommand command = new CreateStaffCommand(_context);
            command.Model = newStaff;

            CreateStaffCommandValidator validator = new CreateStaffCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStaff(int id, [FromBody] UpdateStaffModel updateStaff)
        {
            UpdateStaffCommand command = new UpdateStaffCommand(_context);
            command.StaffId = id;
            command.Model = updateStaff;

            UpdateStaffCommandValidator validator = new UpdateStaffCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            DeleteStaffCommand command = new DeleteStaffCommand(_context);
            command.StaffId = id;

            DeleteStaffCommandValidator validator = new DeleteStaffCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

    }

}