using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EfCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "George Orwell - 1984", Price = 20 },
                new Book { Id = 2, Title = "Tolstoy - İnsan ne ile yaşar?", Price = 50 },
                new Book { Id = 3, Title = "Fahrenheit 451", Price = 40 }
            );
        }
    }
}
