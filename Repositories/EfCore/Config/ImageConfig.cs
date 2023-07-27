using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EfCore.Config
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image { Id = 11, Name = "image_1", ImageData = new byte[] { 1, 2, 3, 5, 6, 3, 3, 2, 2, 2, 3, 4, 2 }, EntityId = 1 });
            builder.HasData(new Image { Id = 12, Name = "image_2", ImageData = new byte[] { 1, 2, 3, 5, 6, 3, 3, 2, 2, 2, 3, 4, 2 }, EntityId = 2 });
            builder.HasData(new Image { Id = 13, Name = "image_3", ImageData = new byte[] { 1, 2, 3, 5, 6, 3, 3, 2, 2, 2, 3, 4, 2 }, EntityId = 3 });
        }
    }
}
