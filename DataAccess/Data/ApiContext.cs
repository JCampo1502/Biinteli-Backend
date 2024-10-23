using System.Reflection;
using Bussines.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;

public class ApiContext(DbContextOptions<ApiContext> opts) : DbContext(opts)
{
    
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Journey> Journeys { get; set; }
    public DbSet<Transport> Transports { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Configuración de la relación entre Flight y Transport
        modelBuilder.Entity<Transport>()
            .HasOne(t => t.Flight)
            .WithMany(f => f.Transports)
            .HasForeignKey(t => t.FlightId);

        // Configuración de la relación entre Flight y Journey
        modelBuilder.Entity<Flight>()
            .HasOne(f => f.Journey)
            .WithMany(j => j.Flights)
            .HasForeignKey(f => f.JourneyId);

        // Data seeding unificado
        modelBuilder.Entity<Journey>().HasData(
            new Journey { Id = "9c9b5d14-e22b-4a4d-9792-f28e255e2a0d", Origin = "BGA", Destination = "BTA", Price = 1000.0f },
            new Journey { Id = "f0ebc49f-8e0a-4a3b-b3ed-7e14285be7a3", Origin = "BTA", Destination = "CTG", Price = 2000.0f },
            new Journey { Id = "49f733c5-4b65-4390-bc60-ec7c3471e028", Origin = "CAL", Destination = "MED", Price = 1500.0f },
            new Journey { Id = "b6ec5b59-2c9a-4df8-9072-1a9e23d9a1c5", Origin = "MED", Destination = "STA", Price = 4000.0f },
            new Journey { Id = "d5a6a21c-023d-42ed-b98b-22d3a728f226", Origin = "BGA", Destination = "MED", Price = 1000.0f }
        );

        modelBuilder.Entity<Flight>().HasData(
            new Flight { Id = "770202d7-08ba-49e8-ab66-8855be4007e9", Origin = "BGA", Destination = "BTA", Price = 1000.0f, JourneyId = "9c9b5d14-e22b-4a4d-9792-f28e255e2a0d" },
            new Flight { Id = "5d1391ea-faf9-4663-b74d-94e54843d52d", Origin = "BTA", Destination = "CTG", Price = 2000.0f, JourneyId = "f0ebc49f-8e0a-4a3b-b3ed-7e14285be7a3" },
            new Flight { Id = "e4efad61-b061-4fbf-aec8-4cd623536f95", Origin = "CAL", Destination = "MED", Price = 1500.0f, JourneyId = "49f733c5-4b65-4390-bc60-ec7c3471e028" },
            new Flight { Id = "0e8677a0-04ae-4fb3-9765-309a71c7624c", Origin = "MED", Destination = "STA", Price = 4000.0f, JourneyId = "b6ec5b59-2c9a-4df8-9072-1a9e23d9a1c5" },
            new Flight { Id = "a24a3289-30a5-4ec8-bd07-034051c76259", Origin = "BGA", Destination = "MED", Price = 1000.0f, JourneyId = "d5a6a21c-023d-42ed-b98b-22d3a728f226" },
            new Flight { Id = "097577c4-db87-4e10-a794-8382f2ed0484", Origin = "MED", Destination = "CTG", Price = 1000.0f, JourneyId = "9c9b5d14-e22b-4a4d-9792-f28e255e2a0d" },
            new Flight { Id = "b179ec78-f0cf-4bed-9139-7027300d72bf", Origin = "CAL", Destination = "CTG", Price = 1000.0f, JourneyId = "f0ebc49f-8e0a-4a3b-b3ed-7e14285be7a3" },
            new Flight { Id = "a73e31d5-7516-4374-968c-c69ccaf00ee9", Origin = "BTA", Destination = "MED", Price = 1000.0f, JourneyId = "49f733c5-4b65-4390-bc60-ec7c3471e028" }
        );

        modelBuilder.Entity<Transport>().HasData(
            new Transport { Id = "7d838ddc-1873-4697-92c9-79f13da906bd", FlightCarrier = "AV", FlightNumber = "8020", FlightId = "770202d7-08ba-49e8-ab66-8855be4007e9" },
            new Transport { Id = "0c5e7a1f-29c8-4340-832e-a1b277433f8c", FlightCarrier = "AV", FlightNumber = "8030", FlightId = "5d1391ea-faf9-4663-b74d-94e54843d52d" },
            new Transport { Id = "b02120b6-651d-4084-aa1c-47c86aed61c5", FlightCarrier = "AV", FlightNumber = "8040", FlightId = "e4efad61-b061-4fbf-aec8-4cd623536f95" },
            new Transport { Id = "e966a315-594e-41da-a00f-67c8fe48a906", FlightCarrier = "AV", FlightNumber = "8050", FlightId = "0e8677a0-04ae-4fb3-9765-309a71c7624c" },
            new Transport { Id = "46753d9b-2560-4b13-a51a-f6aa2ab8c732", FlightCarrier = "AV", FlightNumber = "8060", FlightId = "a24a3289-30a5-4ec8-bd07-034051c76259" },
            new Transport { Id = "41936778-333e-443f-b260-002577b8e467", FlightCarrier = "AV", FlightNumber = "8070", FlightId = "770202d7-08ba-49e8-ab66-8855be4007e9" },
            new Transport { Id = "a2d1de37-cfde-4b0b-989a-6c772d7452e2", FlightCarrier = "AV", FlightNumber = "8080", FlightId = "5d1391ea-faf9-4663-b74d-94e54843d52d" },
            new Transport { Id = "0b4a1620-3827-45fb-b621-dd3a8116550b", FlightCarrier = "AV", FlightNumber = "8090", FlightId = "e4efad61-b061-4fbf-aec8-4cd623536f95" }
        );
    }
}
