using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using ToDoGame.Service.DTO;
using ToDoGame.Service.Interfaces;
using ToDoGamePresentation.Models;

namespace ToDoGamePresentation.Controllers
{
    [Authorize]
    [Route("/profile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;
        public UserProfileController(IUserProfileService userprofileService, IMapper mapper)
        {
            _userProfileService = userprofileService;
            _mapper = mapper;
        }

        [SwaggerOperation(Summary = "Returns all userProfiles")]
        [HttpGet]
        public async Task<IEnumerable<UserProfileViewModel>> GetAllUserProfiles(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<UserProfileViewModel>>(await _userProfileService.GetAllAsync(cancellationToken));
        }

        [SwaggerOperation(Summary = "Create userProfile if it does not exist for current User.")]
        [HttpPost]
        public async Task<Guid> CreateUserProfile(UserProfileViewModel userProfileVm, CancellationToken cancellationToken)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            userProfileVm.UserId = userId;

            var id = await _userProfileService.CreateAsync(_mapper.Map<UserProfileDto>(userProfileVm), cancellationToken);

            return id;
        }

        [SwaggerOperation(Summary = "Delete a single userProfile as defined by the id provided.")]
        [HttpDelete("{id}")]
        public async Task DeleteUserProfile(Guid id, CancellationToken cancellationToken)
        {
            await _userProfileService.DeleteAsync(id, cancellationToken);
        }

        [SwaggerOperation(Summary = "Update userProfile")]
        [HttpPut]
        public async Task UpdateUserProfile(UserProfileViewModel userProfileVm, CancellationToken cancellationToken)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            userProfileVm.UserId = userId;

            await _userProfileService.UpdateAsync(_mapper.Map<UserProfileDto>(userProfileVm), cancellationToken);

        }

        [SwaggerOperation(Summary = "Returns a single userProfile by the id provided.")]
        [HttpGet("{id}")]
        public async Task<UserProfileViewModel> GetUserProfileById(Guid id, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserProfileViewModel>(await _userProfileService.GetAsync(id, cancellationToken));
        }

        [SwaggerOperation(Summary = "Returns a single userProfile by the userId provided.")]
        [HttpGet("user/{id}")]
        public async Task<UserProfileViewModel> GetUserProfileByUserId(string id, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserProfileViewModel>(await _userProfileService.GetUserProfileAsync(id, cancellationToken));
        }

    }
}
