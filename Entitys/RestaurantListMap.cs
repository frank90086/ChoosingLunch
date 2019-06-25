using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChoosingBot.Entitys
{
    public class RestaurantListMap : IEntityTypeConfiguration<RestaurantList>
    {
        public void Configure(EntityTypeBuilder<RestaurantList> builder)
        {
            builder.ToTable("RestaurantList");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                    .HasColumnName("Id")
                    .ValueGeneratedOnAdd()
                    .IsRequired();

            builder.Property(t => t.RestaurantName)
                    .HasColumnName("RestaurantName")
                    .IsRequired();

            builder.Property(t => t.Area)
                    .HasColumnName("Area")
                    .IsRequired();
        }
    }
}