
using DataTypeObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Mappings
{
  public class DicardMapConfig : IEntityTypeConfiguration<Discard>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Discard> builder)
    {
      builder.HasOne(c=> c.Material).WithOne(c=> c.Discard).HasForeignKey<Discard>(c => c.MaterialId);
      builder.HasOne(c=> c.Place).WithOne(c=> c.Discard).HasForeignKey<Discard>(c => c.PlaceId);
      builder.HasOne(c=> c.User).WithOne(c=> c.Discard).HasForeignKey<Discard>(c => c.UserId);
    }
  }    
}
