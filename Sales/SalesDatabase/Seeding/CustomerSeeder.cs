using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.Interfaces;

namespace P03_SalesDatabase.Seeding
{
    public class CustomerSeeder : ISeeder<Customer>
    {
        public void Seed(EntityTypeBuilder<Customer> builder)
        {
            var id = 1;

            var faker = new Faker<Customer>()
                .RuleFor(e => e.CustomerID, f => id++)
                .RuleFor(e => e.Name, f => f.Name.FirstName())
                .RuleFor(e => e.Email, f => f.Internet.Email())
                .RuleFor(e => e.CreditCardNumber, f => f.Finance.CreditCardNumber());

            var c = faker.Generate(10);
            builder.HasData(c);
        }
    }
}
