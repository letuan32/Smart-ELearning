using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_ELearning.Models;

namespace Smart_ELearning.Data.Configurations
{
    public class SubmitDetailConfiguration : IEntityTypeConfiguration<SubmitDetailModel>
    {
        public void Configure(EntityTypeBuilder<SubmitDetailModel> builder)
        {
            builder.ToTable("SubmitDetails");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.SubmitModel).WithMany(x => x.SubmitDetailModels).HasForeignKey(x => x.SubmitId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}