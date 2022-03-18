using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_ELearning.Models;

namespace Smart_ELearning.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<QuestionModel>
    {
        public void Configure(EntityTypeBuilder<QuestionModel> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.TestModel).WithMany(x => x.QuestionModels).HasForeignKey(x => x.TestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}