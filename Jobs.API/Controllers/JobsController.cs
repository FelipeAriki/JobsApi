using Jobs.Application.Commands.CreateJob;
using Jobs.Application.Commands.DeleteJob;
using Jobs.Application.Commands.UpdateJob;
using Jobs.Application.Queries.GetJobById;
using Jobs.Application.Queries.GetProjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var result = await _mediator.Send(new GetJobsQuery());
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var result = await _mediator.Send(new GetJobByIdQuery(id));
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateJob(CreateJobCommand command)
        {
            var result = await _mediator.Send(command);
            if(!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateJob(UpdateJobCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteJob(DeleteJobCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
