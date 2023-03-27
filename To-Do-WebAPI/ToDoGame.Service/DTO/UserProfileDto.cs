namespace ToDoGame.Service.DTO
{
    public class UserProfileDto
    {
        public Guid? Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int LevelId { get; set; } = 1;
        public long ExperiencePoints { get; set; } = 0;
    }
}
