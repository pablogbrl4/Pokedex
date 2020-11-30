using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTeste.Models.ModelConfigurations
{
    public class _Pokemon_Configuration : BaseConfiguration<_Pokemon_>
    {
        public override void Configure(EntityTypeBuilder<_Pokemon_> builder)
        {
            base.Configure(builder);

            builder.ToTable("_Pokemon_");

            builder.HasIndex(p => p.Pokedex_Index).IsUnique();

            builder.Property(prop => prop.Pokedex_Index)
               .IsRequired();

            builder.Property(prop => prop.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(prop => prop.Hp)
                .HasMaxLength(20).IsRequired();

            builder.Property(prop => prop.Attack)
                .HasMaxLength(190).IsRequired();

            builder.Property(prop => prop.Defense)
                .HasMaxLength(230).IsRequired();

            builder.Property(prop => prop.Special_attack)
                .HasMaxLength(194).IsRequired();

            builder.Property(prop => prop.Special_defense)
                .HasMaxLength(230).IsRequired();

            builder.Property(prop => prop.Speed)
               .HasMaxLength(180).IsRequired();

            builder.Property(prop => prop.Speed)
              .HasMaxLength(6).IsRequired();


        }
    }
}
