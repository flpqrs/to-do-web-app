using ToDoGame.Domain.Base;

namespace ToDoGame.Domain.Entities
{
    public class Mission : BaseEntity
    {
        public Guid ProfileId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = null;
        public Category Category { get; set; }
        public UserProfile Profile { get; set; }
    }
}
