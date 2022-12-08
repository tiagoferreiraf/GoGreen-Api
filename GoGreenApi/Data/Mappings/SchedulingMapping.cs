using GoGreenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoGreenApi.Data.Mappings
{

    public class SchedulingMapping : IEntityTypeConfiguration<SchedulingModel>
    {
        public void Configure(EntityTypeBuilder<SchedulingModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdUsuario).IsRequired();
            builder.Property(x => x.IdCompany).IsRequired();
            builder.Property(x => x.Product).IsRequired().HasMaxLength(255);
            builder.Property(x => x.StatusScheduling).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Category).IsRequired();
            builder.Property(x => x.dtCreated).IsRequired();
            builder.Property(x => x.DescriptionProduct).HasMaxLength(255);
           
    }
}
}
