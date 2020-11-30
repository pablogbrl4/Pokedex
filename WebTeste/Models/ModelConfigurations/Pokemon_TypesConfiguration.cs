using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTeste.Models.ModelConfigurations
{
    public class Pokemon_TypesConfiguration : BaseConfiguration<Pokemon_Types>
    {
        public override void Configure(EntityTypeBuilder<Pokemon_Types> builder)
        {
            base.Configure(builder);

            builder.ToTable("Pokemon_Types");

            builder.Property(prop => prop.Type_Id).HasMaxLength(36)
                .IsRequired();

            builder.Property(prop => prop.Pokemon_Id).HasMaxLength(36)
               .IsRequired();

            builder.HasOne(s => s._Pokemon_)
              .WithMany(c => c.Pokemon_Types)
              .HasForeignKey(s => s.Pokemon_Id)
              .HasPrincipalKey(c => c.Id);

            builder.HasOne(s => s.Types)
            .WithMany(c => c.Pokemon_Types)
            .HasForeignKey(s => s.Type_Id)
            .HasPrincipalKey(c => c.Id);

        }
    }
}
