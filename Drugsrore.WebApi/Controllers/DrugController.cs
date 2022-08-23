using AutoMapper;
using Drugsrore.WebApi.Models;
using Drugstore.Application.Drugs.Commands.CreateDrug;
using Drugstore.Application.Drugs.Commands.DeleteDrug;
using Drugstore.Application.Drugs.Commands.UpdateCommand;
using Drugstore.Application.Drugs.Queries.GetDrug;
using Drugstore.Application.Drugs.Queries.GetDrugList;
using Microsoft.AspNetCore.Mvc;

namespace Drugsrore.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DrugController : BaseController
    {
        private IMapper _mapper;

        public DrugController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<DrugListVm>> GetAll()
        {
            var query = new GetDrugListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DrugDegtailVm>> GetDrug(Guid id)
        {
            var query = new GetDrugQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDrug(
            [FromBody] CreateDrugDto drugDto)
        {
            var command = _mapper.Map<CreateDrugCommand>(drugDto);
            var id = await Mediator.Send(command);

            return Created(id.ToString(), id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDrug(
            [FromBody] UpdateDrugDto drugDto)
        {
            var command = _mapper.Map<UpdateDrugCommand>(drugDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDrug(Guid id)
        {
            var command = new DeleteDrugCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
