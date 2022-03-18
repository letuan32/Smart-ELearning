using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_ELearning.Models;

namespace Smart_ELearning.Data.Configurations
{
    public class ClassConfiguration : IEntityTypeConfiguration<ClassModel>
    {
        public void Configure(EntityTypeBuilder<ClassModel> builder)
        {
            builder.ToTable("Classes");
            builder.HasKey(x => x.Id);
        }
    }
}