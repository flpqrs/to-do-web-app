namespace ToDoGamePresentation.Models
{
    public class UserProfileViewModel
    {
        public Guid? Id { get; set; }
        public string? UserId { get; set; }
        public string Name { get; set; }
        public int LevelId { get; set; }
        public long ExperiencePoints { get; set; }
    }
}
