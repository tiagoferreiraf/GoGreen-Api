using GoGreenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoGreenApi.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Username).IsRequired().HasMaxLength(24);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(24);
            builder.Property(x => x.City).IsRequired().HasMaxLength(255);
            builder.Property(x => x.State).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cep).IsRequired().HasMaxLength(255);
        }
    }
}
