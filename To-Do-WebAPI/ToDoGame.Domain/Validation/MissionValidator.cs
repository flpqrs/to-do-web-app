using FluentValidation;
using ToDoGame.Domain.Entities;

namespace ToDoGame.Domain.Validation
{
    public class MissionValidator : AbstractValidator<Mission>
    {
        public MissionValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Title).Length(3, 80);
            RuleFor(x => x.CategoryId).NotNull().InclusiveBetween(1, 4);
        }
    }
}
