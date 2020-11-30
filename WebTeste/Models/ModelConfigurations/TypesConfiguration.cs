using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTeste.Models.ModelConfigurations
{
    public class TypesConfiguration : BaseConfiguration<Types>
    {
        public override void Configure(EntityTypeBuilder<Types> builder)
        {
            base.Configure(builder);

            builder.ToTable("Types");

            builder.Property(prop => prop.Type).HasMaxLength(36)
                .IsRequired();


        }
    }
}
