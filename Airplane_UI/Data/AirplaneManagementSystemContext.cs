using Airplane_API.Entities.AirlineCore;
using Airplane_API.Entities.GateAssignments;
using Airplane_API.Entities.LuggageMaintnance;
using Airplane_API.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Airplane_UI.Data
{
    public class AirplaneManagementSystemContext : DbContext
    {
        public AirplaneManagementSystemContext(DbContextOptions<AirplaneManagementSystemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region AirlineCore
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightManifest> FlightManifests { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        #endregion

        #region GateAssignments
        public DbSet<Gate> Gates { get; set; }
        public DbSet<GateAssignment> GateAssignments { get; set; }
        public DbSet<GroundCrewTeam> GroundCrewTeams { get; set; }
        public DbSet<Runway> Runways { get; set; }
        public DbSet<RunwaySchedule> RunwaySchedules { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        #endregion


        #region LuggageMaintnance
        public DbSet<BaggageClaim> BaggageClaims { get; set; }
        public DbSet<CateringFacilities> CateringFacilities { get; set; }
        public DbSet<CateringOrder> CateringOrders { get; set; }
        public DbSet<LostAndFound> LostAndFounds { get; set; }
        public DbSet<MaintenanceLog> MaintenanceLogs { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
        #endregion

        #region SecurityGates
        public DbSet<AirportStaff> AirportStaffs { get; set; }
        public DbSet<CheckpointLog> CheckpointLogs { get; set; }
        public DbSet<CustomsDesk> CustomsDesks { get; set; }
        public DbSet<SecurityCheckpoint> SecurityCheckpoints { get; set; }
        public DbSet<SecurityIncident> SecurityIncidents { get; set; }
        public DbSet<StaffShift> StaffShifts { get; set; } 
        #endregion




    }
}
