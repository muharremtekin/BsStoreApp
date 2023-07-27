using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EfCore.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
             new Product { Id = 1, Name = "Laptop", Category = "Electronic", Model = "Asus ZendBook", Price = 999 },
             new Product { Id = 2, Name = "Phone", Category = "Electronic", Model = "IPhone 14 Pro", Price = 999 },
             new Product { Id = 3, Name = "Laptop", Category = "Book", Model = "Clean Code", Price = 100 }
            );
        }
    }
}
