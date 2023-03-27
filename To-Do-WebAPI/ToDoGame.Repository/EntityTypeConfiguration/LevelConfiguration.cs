using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoGame.Domain.Entities;

namespace ToDoGame.Repository.EntityTypeConfiguration
{
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {

            builder.HasData(new[]
                {
                new Level() { Id = 1, ExperienceRangeFrom = 0, ExperienceRangeTo = 99},
                new Level() { Id = 2, ExperienceRangeFrom = 100, ExperienceRangeTo = 199},
                new Level() { Id = 3, ExperienceRangeFrom = 200, ExperienceRangeTo = 299},
                new Level() { Id = 4, ExperienceRangeFrom = 300, ExperienceRangeTo = 399},
                new Level() { Id = 5, ExperienceRangeFrom = 400, ExperienceRangeTo = 499},
                new Level() { Id = 6, ExperienceRangeFrom = 500, ExperienceRangeTo = 599},
                new Level() { Id = 7, ExperienceRangeFrom = 600, ExperienceRangeTo = 699},
            });
        }
    }
}
