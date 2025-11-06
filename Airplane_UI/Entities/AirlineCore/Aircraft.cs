using Airplane_UI.Entities.Base;
using Airplane_UI.Entities.LuggageMaintnance;

namespace Airplane_UI.Entities.AirlineCore
{
    /// <summary>
    /// Represents an airport entity within the system.
    /// This entity implements the IBaseEntity interface, which including an identifier
    /// </summary>
    public class Aircraft : IBaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the airport.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique tail number of the aircraft.
        /// </summary>
        public string TailNumber { get; set; }

        /// <summary>
        /// Gets or sets the aircraft model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the foreign key referencing the airline that owns or operates this aircraft.
        /// </summary>
        public int AirlineId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property to the airline associated with this aircraft.
        /// </summary>
        public virtual Airline Airline { get; set; }

        /// <summary>
        /// Gets or sets the collection of flights that this aircraft is assigned to.
        /// </summary>
        public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

        /// <summary>
        /// Gets or sets the collection of maintenance logs associated with this aircraft.
        /// </summary>
        public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; } = new HashSet<MaintenanceLog>();
    }
}
