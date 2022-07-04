using Crud.BackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.BackEnd.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FistName)
              .HasColumnType("varchar(50)")
              .HasMaxLength(50)
              .IsRequired();
            
            builder.Property(u => u.LastName)
              .HasColumnType("varchar(50)")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.Birthday)
                .IsRequired();
            
            builder.ToTable("Users");
        }
    }
}
