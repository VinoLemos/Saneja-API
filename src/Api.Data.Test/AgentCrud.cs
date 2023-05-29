using Api.Data.Context;
using Api.Domain.Entities;
using Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class AgentCrud : BaseTest, IClassFixture<DbTeste>
    {
        private readonly ServiceProvider _serviceProvider;

        public AgentCrud(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Agent CRUD")]
        [Trait("CRUD", "Agent")]
        public async Task Is_Possible_To_Crud_Users()
        {
            using var context = _serviceProvider.GetService<MyContext>();
            AgentRepository _repository = new(context);

            // Create Operation
            var newAgent = new User
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


            var agentCreated = await _repository.InsertAsync(newAgent);
            Assert.NotNull(agentCreated);

            // Read operation
            var agentId = agentCreated.Id;
            var agentRetrieved = await _repository.SelectUserAsync(agentId);
            Assert.NotNull(agentRetrieved);
            Assert.Equal(newAgent.UserName, agentCreated.UserName);
            Assert.Equal(newAgent.Name, agentCreated.Name);
            Assert.Equal(newAgent.Email, agentCreated.Email);
            Assert.Equal(newAgent.EmailConfirmed, agentCreated.EmailConfirmed);
            Assert.Equal(newAgent.Birthday, agentCreated.Birthday);
            Assert.Equal(newAgent.Rg, agentCreated.Rg);
            Assert.Equal(newAgent.Cpf, agentCreated.Cpf);
            Assert.Equal(newAgent.PhoneNumber, agentCreated.PhoneNumber);

            var role = context.Roles.FirstOrDefault(r => r.Name == "Agent");
            Assert.NotNull(role);

            // Assign role
            var userRole = new IdentityUserRole<Guid>
            {
                RoleId = role.Id,
                UserId = agentRetrieved.Id
            };

            context.UserRoles.Add(userRole);
            context.SaveChanges();

            var userRoleRetrieved = context.UserRoles.FirstOrDefault(ur => ur.UserId == agentRetrieved.Id);
            Assert.NotNull(userRoleRetrieved);

            // Update operation
            agentRetrieved.Name = "UpdatedName";
            _repository.UpdateAsync(agentRetrieved);

            // Retrieve the updated user
            var updatedUser = await _repository.SelectAsync(agentRetrieved.Id);
            Assert.NotNull(updatedUser);
            Assert.Equal(agentRetrieved.Name, updatedUser.Name);

            // Delete operation
            var isDeleted = await _repository.DeleteAsync(updatedUser.Id);

            var deletedUser = await _repository.SelectAsync(updatedUser.Id);
            Assert.True(isDeleted);
            Assert.Null(deletedUser);
        }
    }
}
