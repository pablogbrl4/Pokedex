using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebTeste.Models.ModelConfigurations
{

    public class BaseConfiguration<T> : IEntityTypeConfiguration<T>
       where T : BaseModel
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder.Property(prop => prop.Id).HasMaxLength(36)
                .IsRequired();

            //builder
            //    .Property(c => c.Id)
            //    .ValueGeneratedOnAdd()
            //    .IsRequired()
            //    .HasColumnName("Id");
        }
    }
}
