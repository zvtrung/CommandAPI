using System.Collections.Generic;
using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    // [Route("api/testcommand")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private ICommandAPIRepo _repository;

        public CommandsController(ICommandAPIRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> Get()
        {
            // return new string[] { "this", "is", "hard", "coded" };
            var lstCommands = _repository.GetAllCommands();
            return Ok(lstCommands);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetById(int id)
        {
            var command = _repository.GetCommandById(id);
            if (command == null)
                return NotFound();
            else
                return Ok(command);
        }
    }
}
