using GoGreenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoGreenApi.Data.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<CompanyModel>
    {
        public void Configure(EntityTypeBuilder<CompanyModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ImageUrl).HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.City).IsRequired().HasMaxLength(255);
            builder.Property(x => x.State).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cep).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Category).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);


        }
    }
}
