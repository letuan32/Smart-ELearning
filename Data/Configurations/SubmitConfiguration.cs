using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_ELearning.Models;

namespace Smart_ELearning.Data.Configurations
{
    public class SubmitConfiguration : IEntityTypeConfiguration<SubmitModel>
    {
        public void Configure(EntityTypeBuilder<SubmitModel> builder)
        {
            builder.ToTable("Submits");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.TestModels).WithMany(x => x.SubmitModels).HasForeignKey(x => x.TestId);
        }
    }
}