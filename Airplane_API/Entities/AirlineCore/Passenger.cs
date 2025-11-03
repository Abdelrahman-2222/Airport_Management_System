using Airplane_API.Entities.Base;
using System.Collections.Generic;

namespace Airplane_API.Entities.AirlineCore
{
    /// <summary>
    /// Represents a passenger who travels on one or more flights within the system.
    /// </summary>
    public class Passenger : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the Passenger class.
        /// The constructor initializes the FlightManifests collection 
        /// to prevent null reference issues when adding related flight records.
        /// </summary>
        public Passenger()
        {
            FlightManifests = new HashSet<FlightManifest>();
        }

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
        public virtual ICollection<FlightManifest> FlightManifests { get; set; }
    }
}
