using Api.Data.Context;
using Api.Domain.Entities;
using Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class TechnicalVisitCrud : BaseTest, IClassFixture<DbTeste>
    {
        private readonly ServiceProvider _serviceProvider;

        public TechnicalVisitCrud(DbTeste dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Visit CRUD")]
        [Trait("CRUD", "Technical Visit")]
        public async Task Is_Possible_To_Crud_Visits()
        {
            using var context = _serviceProvider.GetService<MyContext>();
            TechnicalVisitRepository _repository = new(context);

            // Create operation

            #region CreatingPerson
            // Create Person
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

            // Assing Person role to dummyPerson
            var personRole = context.Roles.FirstOrDefault(r => r.Name == "Person");
            Assert.NotNull(personRole);

            var userRole = new IdentityUserRole<Guid>
            {
                RoleId = personRole.Id,
                UserId = dummyPersonId
            };

            context.UserRoles.Add(userRole);
            context.SaveChanges();

            var userRoleRetrieved = context.UserRoles.FirstOrDefault(ur => ur.UserId == dummyPersonId);
            Assert.NotNull(userRoleRetrieved);
            #endregion

            #region CreatingAgent
            // Create Agent
            var dummyAgentId = Guid.NewGuid();
            var dummyAgent = new User
            {
                Id = dummyAgentId,
                Birthday = DateTime.Now.AddDays(-30),
                Cpf = "22222222222",
                Email = "email@mail.com",
                Name = "Test",
                CreatedAt = DateTime.Now,
                PhoneNumber = "1234567890",
                UserName = "Test",
                Rg = "Test"
            };
            context.Users.Add(dummyAgent);
            await context.SaveChangesAsync();

            // Assing Agent role to dummyPerson
            var agentRole = context.Roles.FirstOrDefault(r => r.Name == "Agent");
            Assert.NotNull(agentRole);

            var agentUserRole = new IdentityUserRole<Guid>
            {
                RoleId = agentRole.Id,
                UserId = dummyAgentId
            };

            context.UserRoles.Add(agentUserRole);
            context.SaveChanges();

            var userRoleAgentRetrieved = context.UserRoles.FirstOrDefault(ur => ur.UserId == dummyPersonId);
            Assert.NotNull(userRoleAgentRetrieved);
            #endregion

            // Create Operation
            var dummyPropertyId = Guid.NewGuid();
            var dummyProperty = new ResidentialProperty
            {
                Id = dummyPropertyId,
                Cep = 11111111,
                Street = Faker.Address.StreetName(),
                City = Faker.Address.City(),
                Complement = "Teste",
                Neighborhood = "Teste",
                Number = Faker.RandomNumber.Next(),
                UF = "SP",
                Rgi = 1111111111,
                Hidrometer = 1111111111,
                PersonId = dummyPersonId
            };
            context.ResidencialProperties.Add(dummyProperty);
            await context.SaveChangesAsync();

            // Retrieving Statuses
            var statuses = context.VisitStatuses.ToList();

            // Creating - Person Requesting visit
            var dummyVisit = new TechnicalVisit
            {
                ResidencialPropertyId = dummyPropertyId,
                Homologated = false,
                StatusId = statuses.FirstOrDefault(s => s.Status == "Pending").Id,
                VisitDate = DateTime.Now.AddDays(5)
            };

            // Retrieving
            var createdVisit = await _repository.InsertAsync(dummyVisit);
            Assert.NotNull(createdVisit);
            // Retrieving Pending
            var pendingVisits = await _repository.SelectPendingVisits();
            Assert.NotNull(pendingVisits);

            // Updating - Agent accepting visit
            var acceptedVisit = _repository.AcceptVisit(createdVisit.Id, dummyAgentId);
            Assert.True(acceptedVisit);

            // Retrieving Agent visit
            var agentVisit = _repository.SelectAgentVisits(dummyAgentId);
            Assert.NotNull(agentVisit);

            // Updating - homologating visit
            var visitHomologated = _repository.UpdateVisitObservation(createdVisit.Id, "observação teste");
            Assert.True(visitHomologated);
            var homologatedVisit = await _repository.SelectAsync(createdVisit.Id);
            Assert.NotNull(homologatedVisit.Observation);

            // Returning visit status to Pending
            homologatedVisit.StatusId = context.VisitStatuses.FirstOrDefault(v => v.Status == "Pending").Id;
            await context.SaveChangesAsync();

            // Updating - Canceling visit
            var canceledVisit = await _repository.CancelVisit(homologatedVisit.Id);
            Assert.True(canceledVisit);
        }
    }
}
