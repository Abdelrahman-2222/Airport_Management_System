using Airplane_API.Entities.Base;

namespace Airplane_API.Entities.AirlineCore
{
    public class Passenger : BaseEntity
    {
        public Passenger()
        {
            FlightManifests = new HashSet<FlightManifest>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }

        public virtual ICollection<FlightManifest> FlightManifests { get; set; }
    }
}
