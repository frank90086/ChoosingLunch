using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoosingBot.Entitys
{
    public class EatedListMap : IEntityTypeConfiguration<EatedList>
    {
        public void Configure(EntityTypeBuilder<EatedList> builder)
        {
            builder.ToTable("EatedList");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(t => t.Restaurant)
                .HasColumnName("Restaurant")
                .IsRequired();
            builder.Property(t => t.WeekDay)
                    .HasColumnName("Day")
                    .IsRequired();
        }
    }
}