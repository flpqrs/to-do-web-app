using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoGame.Domain.Entities;

namespace ToDoGame.Repository.EntityTypeConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasData(new[]
                {
                new Category() { Id = 1, Name="Daily", ExperiencePoints = 5},
                new Category() { Id = 2, Name="Weekly", ExperiencePoints = 10},
                new Category() { Id = 3, Name="Monthly", ExperiencePoints = 15},
                new Category() { Id = 4, Name="LongTerm", ExperiencePoints = 20},
            });
        }
    }
}