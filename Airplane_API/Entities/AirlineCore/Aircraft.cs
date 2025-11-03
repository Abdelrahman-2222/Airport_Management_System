using Airplane_API.Entities.Base;

namespace Airplane_API.Entities.AirlineCore
{
    public class Aircraft : BaseEntity
    {
        public Aircraft()
        {
            Flights = new HashSet<Flight>();
            MaintenanceLogs = new HashSet<MaintenanceLog>();
        }
        public string TailNumber { get; set; }
        public string Model { get; set; }

        public int AirlineId { get; set; }
        public virtual Airline Airline { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; }
    }
}
