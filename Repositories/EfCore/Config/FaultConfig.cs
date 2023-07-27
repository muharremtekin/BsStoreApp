using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EfCore.Config
{
    public class FaultConfig : IEntityTypeConfiguration<Fault>
    {

        public void Configure(EntityTypeBuilder<Fault> builder)
        {
            builder.HasData(
                new Fault { Id = 1, ProductId = 2, Description = "Faulty product", ReportedAt = DateTime.Now, IsResolved = false },
                new Fault { Id = 2, ProductId = 1, Description = "Faulty product", ReportedAt = DateTime.Now, IsResolved = false }
            );
        }
    }
}
