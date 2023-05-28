using Api.Data.Context;
using Api.Domain.Entities;
using Data.Repository;
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
                Name = "Test",
                Email = "email@mail.com",
                UserName = "email@mail.com",
                EmailConfirmed = false,
                Birthday = DateTime.Now.AddDays(-30),
                Rg = "Test",
                Cpf = "11111111111",
                PhoneNumber = "1234567890"
            };

            var personCreated = await _repository.InsertAsync(newPerson);
            Assert.NotNull(personCreated);

            // Read operation
            var personId = personCreated.Id;
            var personRetrieved = await _repository.SelectUserAsync(personId);
            Assert.NotNull(personRetrieved);
            Assert.Equal(newPerson.UserName, personCreated.UserName);
            Assert.Equal(newPerson.Name, personCreated.Name);
            Assert.Equal(newPerson.Email, personCreated.Email);
            Assert.Equal(newPerson.EmailConfirmed, personCreated.EmailConfirmed);
            Assert.Equal(newPerson.Birthday, personCreated.Birthday);
            Assert.Equal(newPerson.Rg, personCreated.Rg);
            Assert.Equal(newPerson.Cpf, personCreated.Cpf);
            Assert.Equal(newPerson.PhoneNumber, personCreated.PhoneNumber);

            // Update operation
            personRetrieved.Name = "UpdatedName";
            _repository.UpdateAsync(personRetrieved);

            // Retrieve the updated user
            var updatedUser = await _repository.SelectUserAsync(personRetrieved.Id);
            Assert.NotNull(updatedUser);
            Assert.Equal(personRetrieved.Name, updatedUser.Name);

            // Delete operation
            var isDeleted = await _repository.DeleteUserAsync(updatedUser.Id);

            var deletedUser = await _repository.SelectUserAsync(updatedUser.Id);
            Assert.True(isDeleted);
            Assert.Null(deletedUser);
        }
    }
}
