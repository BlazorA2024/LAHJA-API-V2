using Api.Repositories;
using ASG.Api2.Results;
using AutoMapper;
using Dto;
using Dto.ModelAi;
using Entities;
using Microsoft.AspNetCore.Mvc;
using VM;

namespace ASG.Api2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpaceController : ControllerBase
    {
        private readonly ISpaceRepository _spaceRepository;
        private readonly IMapper _mapper;

        public SpaceController(ISpaceRepository spaceRepository, IMapper mapper)
        {
            _spaceRepository = spaceRepository;
            _mapper = mapper;
        }

        // Get All Spaces
        [EndpointSummary("Get all Spaces")]
        [HttpGet(Name = "GetSpaces")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<SpaceResponse>>> GetAll()
        {
            var items = await _spaceRepository.GetAllAsync();
            var result = _mapper.Map<List<SpaceResponse>>(items);
            return Ok(result);
        }

        // Get Space by Id
        [EndpointSummary("Get one Space")]
        [HttpGet("{id}", Name = "GetSpace")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SpaceResponse>> GetOne(string id)
        {
            var item = await _spaceRepository.GetByAsync(s => s.Id == id);
            if (item == null)
                return NotFound();
            var result = _mapper.Map<SpaceResponse>(item);
            return Ok(result);
        }

        // Create a Space
        [EndpointSummary("Create a Space")]
        [HttpPost("CreateSpace")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SpaceResponse>> Create(CreateSpaceRequest model)
        {
            try
            {
                var item = _mapper.Map<CreateSpaceRequest, Space>(model);
                var result = await _spaceRepository.CreateAsync(item);
                var resultVM = _mapper.Map<SpaceResponse>(result);
                return CreatedAtAction(nameof(GetOne), new { id = result.Id }, resultVM);
            }
            catch (Exception ex)
            {
                return BadRequest(new ProblemDetails { Type = ex.GetType().FullName, Title = ex.Message, Detail = ex.InnerException?.Message });
            }
        }

        // Update a Space
        [EndpointSummary("Update Space")]
        [HttpPut("{id}", Name = "UpdateSpace")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SpaceResponse>> Update(string id, UpdateSpaceRequest model)
        {
            try
            {
                var space = await _spaceRepository.GetByAsync(r => r.Id == id);
                if (space == null)
                {
                    return NotFound("Space not found");
                }
                var item = _mapper.Map<UpdateSpaceRequest, Space>(model);
                item.Id = id;
                var updatedSpace = await _spaceRepository.UpdateAsync(item);
                var result = _mapper.Map<SpaceResponse>(updatedSpace);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ProblemDetails { Type = ex.GetType().FullName, Title = ex.Message, Detail = ex.InnerException?.Message });
            }
        }

        // Delete a Space
        [EndpointSummary("Delete Space")]
        [HttpDelete("{id}", Name = "DeleteSpace")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeletedResponse>> Delete(string id)
        {
            try
            {
                if (!await _spaceRepository.Exists(s => s.Id == id))
                {
                    return NotFound($"Space with id {id} not exists");
                }
                await _spaceRepository.RemoveAsync(s => s.Id == id);
                return Ok(new DeletedResponse { Id = id, Deleted = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new ProblemDetails { Type = ex.GetType().FullName, Title = ex.Message, Detail = ex.InnerException?.Message });
            }
        }
    }
}
