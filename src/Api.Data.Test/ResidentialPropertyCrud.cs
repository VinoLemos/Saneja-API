using Api.Data.Context;
using Api.Domain.Entities;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class ResidentialPropertyCrud : BaseTest, IClassFixture<DbTeste>
    {
        private readonly ServiceProvider _serviceProvider;

        public ResidentialPropertyCrud(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Crud residential properties")]
        [Trait("CRUD", "ResidentialPropertyEntity")]
        public async Task Is_Possible_To_Crud_Property()
        {
            using var context = _serviceProvider.GetService<MyContext>();
            ResidentialPropertyRepository _repository = new(context);

            // Create operation
            var dummyPersonId = Guid.NewGuid();
            var dummyPerson = new User
            {
                Id = dummyPersonId,
                Birthday = DateTime.Now.AddDays(-30),
                Cpf = "11111111111",
                Email = "email@mail.com",
                Name = "Test",
                CreatedAt = DateTime.Now,
                PhoneNumber = "1234567890",
                UserName = "Test",
                Rg = "Test"
            };
            context.Users.Add(dummyPerson);
            await context.SaveChangesAsync();

            var property = new ResidentialProperty
            {
                Id = Guid.NewGuid(),
                Street = "Street",
                Number = 123,
                Complement = "Complement",
                Neighborhood = "Neighborhood",
                Cep = 11713300,
                City = "City",
                UF = "SP",
                Rgi = "321425678",
                Hidrometer = 21345678
            };

            var isCreated = await _repository.InsertAsync(property, dummyPerson.Id);
            var propertyCreated = await _repository.SelectAsync(property.Id);
            Assert.NotNull(isCreated);
            Assert.Equal(propertyCreated.Id, property.Id);
            Assert.Equal(propertyCreated.Street, property.Street);
            Assert.Equal(propertyCreated.Number, property.Number);
            Assert.Equal(propertyCreated.Neighborhood, property.Neighborhood);
            Assert.Equal(propertyCreated.Cep, property.Cep);
            Assert.Equal(propertyCreated.City, property.City);
            Assert.Equal(propertyCreated.UF, property.UF);
            Assert.Equal(propertyCreated.Rgi, property.Rgi);
            Assert.Equal(propertyCreated.Hidrometer, property.Hidrometer);
            Assert.Equal(propertyCreated.PersonId, property.PersonId);

            // Update operation
            propertyCreated.Street = "Updated Street";
            propertyCreated.Number = 1234;
            propertyCreated.Complement = "Updated complement";
            propertyCreated.Neighborhood = "Updated neighborhood";
            propertyCreated.Cep = 11111111;
            propertyCreated.City = "Updated City";
            propertyCreated.UF = "AA";
            propertyCreated.Rgi = "321425679";
            propertyCreated.Hidrometer = 21345678;
            _repository.UpdateAsync(propertyCreated);
            var propertyUpdated = await _repository.SelectAsync(property.Id);
            Assert.Equal("Updated Street", propertyUpdated.Street);

            // Retrieve operation
            var returned = await _repository.SelectAsync(propertyCreated.Id);
            Assert.NotNull(returned);

            // Retrieve User Properties
            var properties = await _repository.SelectUserProperties(dummyPerson.Id);
            Assert.NotNull(properties);

            // Delete operation
            //await _repository.DeleteAsync(propertyUpdated.Id); // Not implemented
            //var propertyDeleted = await _repository.SelectAsync(propertyUpdated.Id);
            //Assert.Null(propertyDeleted);
        }
    }
}
