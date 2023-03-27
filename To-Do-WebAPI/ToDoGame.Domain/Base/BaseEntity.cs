using ToDoGame.Domain.Interfaces.Entities;

namespace ToDoGame.Domain.Base
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }

    }
}
