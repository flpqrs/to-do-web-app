using FluentValidation;
using ToDoGame.Domain.Entities;

namespace ToDoGame.Domain.Validation
{
    public class UserProfileValidator : AbstractValidator<UserProfile>
    {
        public UserProfileValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(3, 15);
        }
    }
}