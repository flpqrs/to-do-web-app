using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ToDoGame.Service.DTO;
using ToDoGame.Service.Interfaces;
using ToDoGamePresentation.Models;

namespace ToDoGamePresentation.Controllers
{
    [Authorize]
    [Route("/mission")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _missionService;
        private readonly IMapper _mapper;

        public MissionController(IMissionService missionService, IMapper mapper)
        {
            _missionService = missionService;
            _mapper = mapper;
        }

        [SwaggerOperation(Summary = "Returns all user's missions by the userProfile id provided.")]
        [HttpGet("profile/{id}")]
        public async Task<IEnumerable<MissionViewModel>> GetAllByUserProfileId(Guid id, CancellationToken cancellationToken)
        {
            var missions = await _missionService.GetAllByUserProfileIdAsync(id, cancellationToken);

            return _mapper.Map<IEnumerable<MissionViewModel>>(missions);
        }

        [SwaggerOperation(Summary = "Create a single mission.")]
        [HttpPost]
        public async Task<Guid> CreateMission(MissionViewModel missionVm, CancellationToken cancellationToken)
        {
            var id = await _missionService.CreateAsync(_mapper.Map<MissionDto>(missionVm), cancellationToken);
            return id;
        }
        [SwaggerOperation(Summary = "Delete a single mission as defined by the id provided.")]
        [HttpDelete("{id}")]
        public async Task DeleteMission(Guid id, CancellationToken cancellationToken)
        {
            await _missionService.DeleteAsync(id, cancellationToken);
        }

        [SwaggerOperation(Summary = "Update mission. Or mark as completed.")]
        [HttpPut]
        public async Task UpdateAsync(MissionViewModel missionVm, CancellationToken cancellationToken)
        {
            await _missionService.UpdateAsync(_mapper.Map<MissionDto>(missionVm), cancellationToken);
        }

        [SwaggerOperation(Summary = "Get a single mission as defined by the id provided.")]
        [HttpGet("{id}")]
        public async Task<MissionViewModel> GetMissionById(Guid id, CancellationToken cancellationToken)
        {
            return _mapper.Map<MissionViewModel>(await _missionService.GetAsync(id, cancellationToken));
        }
    }
}