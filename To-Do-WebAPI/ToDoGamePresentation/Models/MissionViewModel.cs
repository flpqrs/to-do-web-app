namespace ToDoGamePresentation.Models
{
    public class MissionViewModel
    {
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }
        public string? Title { get; set; }
        public int CategoryId { get; set; }
        public bool IsCompleted { get; set; }

    }
}
