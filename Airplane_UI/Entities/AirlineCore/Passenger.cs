using Airplane_UI.Entities.Base;
using System.Collections.Generic;

namespace Airplane_UI.Entities.AirlineCore
{
    /// <summary>
    /// Represents a passenger who travels on one or more flights within the system.
    /// </summary>
    public class Passenger : IBaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the passenger.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the passenger.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the passenger.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the passport number of the passenger.
        /// </summary>
        public string PassportNumber { get; set; }

        /// <summary>
        /// Gets or sets the collection of flight manifests associated with this passenger.
        /// </summary>
        public virtual ICollection<FlightManifest> FlightManifests { get; set; } = new HashSet<FlightManifest>();
    }
}
