using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.Interfaces;

namespace P03_SalesDatabase.Seeding
{
    public class SaleSeeder : ISeeder<Sale>
    {
        public void Seed(EntityTypeBuilder<Sale> builder)
        {
            var id = 1;

            var faker = new Faker<Sale>()
                .RuleFor(e => e.SaleID, f => id++)
                .RuleFor(e => e.Date, f => f.Date.Past())
                .RuleFor(e => e.CustomerID, f => f.Random.Number(1, 10))
                .RuleFor(e => e.ProductID, f => f.Random.Number(1, 10))
                .RuleFor(e => e.StoreID, f => f.Random.Number(1, 10));

            var s = faker.Generate(10);
            builder.HasData(s);
        }
    }
}
