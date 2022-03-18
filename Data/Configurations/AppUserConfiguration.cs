using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_ELearning.Models;

namespace Smart_ELearning.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUserModel>
    {
        public void Configure(EntityTypeBuilder<AppUserModel> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.SpecificId).IsUnique();
        }
    }
}