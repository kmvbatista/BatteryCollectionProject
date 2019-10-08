
using DataTypeObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Mappings
{
  public class DicardMapConfig : IEntityTypeConfiguration<Discard>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Discard> builder)
    {
    }
  }    
}
