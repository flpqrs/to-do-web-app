using AutoMapper;
using FluentValidation;
using ToDoGame.Domain.Entities;
using ToDoGame.Domain.Interfaces.Repositories;
using ToDoGame.Service.DTO;
using ToDoGame.Service.Interfaces;

namespace ToDoGame.Service
{
    public class MissionService : IMissionService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Mission> _repository;
        private readonly IRepository<UserProfile> _userProfileRepository;
        private readonly ISpecialRepository<Category> _categoryRepository;
        private readonly ISpecialRepository<Level> _levelRepository;
        private readonly IValidator<Mission> _missionValidator;

        public MissionService(IMapper mapper,
            IRepository<Mission> repository,
            IRepository<UserProfile> userProfileRepository,
            ISpecialRepository<Category> categoryRepository,
            ISpecialRepository<Level> levelRepository,
            IValidator<Mission> missionValidator)
        {

            _mapper = mapper;
            _repository = repository;
            _userProfileRepository = userProfileRepository;
            _categoryRepository = categoryRepository;
            _levelRepository = levelRepository;
            _missionValidator = missionValidator;
        }
        public async Task<Guid> CreateAsync(MissionDto missionDto, CancellationToken cancellationToken)
        {
            var mission = _mapper.Map<Mission>(missionDto);

            var validationResult = await _missionValidator.ValidateAsync(mission, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new Exception("Validation Failed");
            }

            await _repository.InsertAsync(mission, cancellationToken);

            return mission.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<MissionDto>> GetAllByUserProfileIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var missions = _repository.GetAll().Where(m => m.ProfileId == userId);

            return _mapper.Map<IEnumerable<MissionDto>>(missions);
        }

        public async Task<MissionDto> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetAsync(id, cancellationToken);

            return _mapper.Map<MissionDto>(entity);
        }

        public async Task UpdateAsync(MissionDto missionDto, CancellationToken cancellationToken)
        {
            var mission = _mapper.Map<Mission>(missionDto);

            mission.UpdatedDate = DateTime.UtcNow;

            if (mission.IsCompleted)
            {
                var currentMission = await _repository.GetAsync(missionDto.Id, cancellationToken);
                var category = await _categoryRepository.GetAsync(currentMission.CategoryId, cancellationToken);
                var user = await _userProfileRepository.GetAsync(mission.ProfileId, cancellationToken);

                user.ExperiencePoints += category.ExperiencePoints;

                var level = await _levelRepository.GetCurrentLevelAsync(user, cancellationToken);

                if (level != null && level.Id != user.LevelId)
                {
                    user.LevelId = level.Id;
                }

                await _repository.DeleteAsync(mission.Id, cancellationToken);
            }
            else
            {
                await _repository.UpdateAsync(mission, cancellationToken);
            }
        }

    }
}
