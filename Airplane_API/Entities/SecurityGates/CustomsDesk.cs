using Airplane_API.Entities.Base;
using Airplane_API.Entities.GateAssignment;
using Airport.Models.Security_Services;
namespace Airplane_API.Entities.Security_Services;

    /// <summary>
    /// Represents a specific customs and immigration counter location within an airport terminal.
    /// </summary>
    public class CustomsDesk : BaseEntity
    {
        /// <summary>
        /// The identifier of the terminal to which this customs desk belongs.
        /// </summary>
        public int TerminalID { get; set; }

        /// <summary>
        /// The unique number assigned to this customs desk.
        /// </summary>
        public string DeskNumber { get; set; }

        /// <summary>
        /// The current operational status of the customs desk (e.g., "Open", "Closed").
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The terminal associated with this customs desk.
        /// </summary>
        public Terminal Terminal { get; set; }

        /// <summary>
        /// The collection of staff shifts assigned to this customs desk.
        /// </summary>
        public ICollection<StaffShift> AssignedShifts { get; set; } = new List<StaffShift>();
    }

