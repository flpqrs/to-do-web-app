using AutoMapper;
using FluentValidation;
using ToDoGame.Domain.Entities;
using ToDoGame.Domain.Interfaces.Repositories;
using ToDoGame.Service.DTO;
using ToDoGame.Service.Interfaces;

namespace ToDoGame.Service
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IRepository<UserProfile> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<UserProfile> _userProfileValidator;

        public UserProfileService(IRepository<UserProfile> repository,
            IMapper mapper,
            IValidator<UserProfile> userProfileValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _userProfileValidator = userProfileValidator;
        }

        public async Task<IEnumerable<UserProfileDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var profiles = _repository.GetAll();

            return _mapper.Map<IEnumerable<UserProfileDto>>(profiles);
        }

        public async Task<Guid> CreateAsync(UserProfileDto profileDto, CancellationToken cancellationToken)
        {

            if (_repository.GetAll().Any(up => up.UserId == profileDto.UserId))
            {
                throw new InvalidOperationException();
            }
            var userProfile = _mapper.Map<UserProfile>(profileDto);

            var validationResult = await _userProfileValidator.ValidateAsync(userProfile, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new Exception("Invalid UserName");
            }

            await _repository.InsertAsync(userProfile, cancellationToken);

            return userProfile.Id;
        }

        public async Task UpdateAsync(UserProfileDto userProfileDto, CancellationToken cancellationToken)
        {
            var userProfile = _mapper.Map<UserProfile>(userProfileDto);

            await _repository.UpdateAsync(userProfile, cancellationToken);
        }

        public async Task<UserProfileDto> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAsync(id, cancellationToken);

            return _mapper.Map<UserProfileDto>(entity);

        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(id, cancellationToken);
        }

        public async Task<UserProfileDto> GetUserProfileAsync(string userId, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetUserProfileAsync(userId, cancellationToken);

            return _mapper.Map<UserProfileDto>(entity);
        }

    }
}
