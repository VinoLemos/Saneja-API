using Api.Data.Context;
using Api.Domain.Entities;
using Data.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class PersonCrud : BaseTest, IClassFixture<DbTeste>
    {
        private readonly ServiceProvider _serviceProvider;

        public PersonCrud(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Person CRUD")]
        [Trait("CRUD", "Person")]
        public async Task Is_Possible_To_Crud_Users()
        {
            using var context = _serviceProvider.GetService<MyContext>();
            PersonRepository _repository = new(context);

            // Create Operation
            var newPerson = new User
            {
                Id = Guid.NewGuid(),
                UserName = "Test",
                Name = "Test",
                Email = "email@mail.com",
                EmailConfirmed = false,
                Birthday = DateTime.Now.AddDays(-30),
                Rg = "Test",
                Cpf = "11111111111",
                PhoneNumber = "1234567890"
            };

            // Insert operation
            var isCreated = await _repository.InsertAsync(newPerson);
            var personCreated = await _repository.SelectUserAsync(newPerson.Id);
            Assert.True(isCreated);
        }
    }
}
