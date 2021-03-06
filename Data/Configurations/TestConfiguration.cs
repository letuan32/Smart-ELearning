using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_ELearning.Models;

namespace Smart_ELearning.Data.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<TestModel>
    {
        public void Configure(EntityTypeBuilder<TestModel> builder)
        {
            builder.ToTable("Testes");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ScheduleModel).WithMany(x => x.TestModels).HasForeignKey(x => x.ScheduleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}