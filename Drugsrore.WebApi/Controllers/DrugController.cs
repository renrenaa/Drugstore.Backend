using AutoMapper;
using Drugsrore.WebApi.Models;
using Drugstore.Application.Drugs.Commands.CreateDrug;
using Drugstore.Application.Drugs.Commands.DeleteDrug;
using Drugstore.Application.Drugs.Commands.UpdateDrug;
using Drugstore.Application.Drugs.Queries.GetDrug;
using Drugstore.Application.Drugs.Queries.GetDrugList;
using Microsoft.AspNetCore.Mvc;

namespace Drugsrore.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DrugController : BaseController
    {
        private readonly IMapper _mapper;

        public DrugController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets list of drugs
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /drug
        /// </remarks>
        /// <returns>Return DrugListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DrugListVm>> GetAll()
        {
            var query = new GetDrugListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Get drug by id 
        /// </summary>
        /// <remarks>
        /// Sample request: 
        /// GET /drug/a58e6ac5-c80f-4e50-b4f9-05ef16bfa160
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>DrugDetailVm</returns>
        /// <response code="200">Success</response>
        /// <response code="404">If drug not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DrugDegtailVm>> GetDrug(Guid id)
        {
            var query = new GetDrugQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Create a drug
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /drug
        /// {
        ///     "id": "b58e6ac5-c80f-4e50-b4f9-05ef16bfa160",
        ///     "price": 75,
        ///     "tittle": "Fluoksetin",
        ///     "quantity": 134,
        ///     "description": "Fluoksetin descroption",
        ///     "isOnPrescription": true
        /// }
        /// </remarks>
        /// <param name="drugDto">CreateDrugDto object</param>
        /// <returns>Returns id (Guid)</returns>
        ///<response code="201">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateDrug(
                [FromBody] CreateDrugDto drugDto)
        {
            var command = _mapper.Map<CreateDrugCommand>(drugDto);
            var id = await Mediator.Send(command);

            return Created(id.ToString(), id);
        }

        /// <summary>
        /// Update a drug
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /drug
        /// {
        ///     "id": "a58e6ac5-c80f-4e50-b4f9-05ef16bfa160",
        ///     "price": 134.76,
        ///     "tittle": "Fluoksetin",
        ///     "quantity": 134,
        ///     "description": "Fluoksetin descroption",
        ///     "isOnPrescription": true
        /// }
        /// </remarks>
        /// <param name="drugDto">UpdateDrugDto object</param>
        /// <returns>NoContent</returns>
        ///<response code="204">Success</response> 
        ///<response code="404">If drug not found</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateDrug(
                [FromBody] UpdateDrugDto drugDto)
        {
            var command = _mapper.Map<UpdateDrugCommand>(drugDto);
            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delte drug by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /drug/a58e6ac5-c80f-4e50-b4f9-05ef16bfa160
        /// </remarks>
        /// <param name="id">Id of the drug (Guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response> 
        /// <response code="404">If drug not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
