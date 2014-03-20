using System;
using System.Collections.Generic;
using DBTest.Models;

namespace DBTest.DataAccessLayer
{
    public class ServerDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ServerContext>
    {
        protected override void Seed(ServerContext context)
        {
            var users = new List<User>
            {
                new User{ FirstName = "Emil", LastName = "Thorenfeldt", Email = "emildinho@gmail.com", Confirmed = true, CredentialLevel = CredentialLevel.Administrator, UserId = 1},
                new User{ FirstName = "Anton Kjær", LastName = "Hansen", Email = "antonkjaerhansen@gmail.com", Confirmed = true, CredentialLevel = CredentialLevel.Administrator, UserId = 2},
                new User{ FirstName = "Ny", LastName = "Bruger", Email = "enmailadresse@gmail.com", Confirmed = false, CredentialLevel = CredentialLevel.User, UserId = 3}

            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var hostServers = new List<HostServer>
            {
                new HostServer {Name = "Server 1", ServerStatus = ServerStatus.Running, Specs = "3Ghz, 16GB RAM", HostServerId = 1},
                new HostServer {Name = "Server 2", ServerStatus = ServerStatus.Inactive, Specs = "2Ghz, 8GB RAM", HostServerId = 2}
            };

            hostServers.ForEach(s => context.HostServers.Add(s));

            var serverTypes = new List<ServerType>
            {
                new ServerType
                {
                    OperatingSystem = "Windows",
                    CpuSpeedInMhz = 3000,
                    DiskSpaceInMb = 300,
                    MemoryInMb = 1024,
                    AdditionalServices = "PhpMyAdmin",
                    ServerTypeId = 1
                }
            };

            serverTypes.ForEach(s => context.ServerTypes.Add(s));

            var rentals = new List<Rental>
            {
                new Rental
                {
                    Status = Status.Active,
                    StartDate = new DateTime(2014, 3, 15),
                    DurationInDays = 90,
                    Comments = "Test",
                    ConfirmedByUserId = 1,
                    UserId = 2,
                    RentalId = 1,
                    
                }
            };

            rentals.ForEach(r => context.Rentals.Add(r));

            context.SaveChanges();

        }
        
    }
}