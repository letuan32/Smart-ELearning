using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_ELearning.Models;

namespace Smart_ELearning.Data.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<SubjectModel>
    {
        public void Configure(EntityTypeBuilder<SubjectModel> builder)
        {
            builder.ToTable("Subjects");
            builder.HasKey(x => x.Id);
        }
    }
}