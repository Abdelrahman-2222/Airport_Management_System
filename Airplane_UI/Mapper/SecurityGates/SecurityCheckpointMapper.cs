using Airplane_UI.DTOs.SecurityGates.SecurityCheckpoint;
using Airplane_UI.Entities.SecurityGates;
using System;
using System.Linq;

namespace Airplane_UI.Mappers.SecurityGates
{
    public static class SecurityCheckpointMapper
    {
        public static GetSecurityCheckpointDto ToGetDto(this SecurityCheckpoint sc)
        {
            return new GetSecurityCheckpointDto
            {
                Id = sc.Id,
                Name = sc.Name,
                TerminalID = sc.TerminalID,
                Status = sc.Status
            };
        }

        public static SecurityCheckpoint ToEntity(this CreateSecurityCheckpointDto dto)
        {
            return new SecurityCheckpoint
            {
                Name = dto.Name,
                TerminalID = dto.TerminalID,
                Status = string.IsNullOrWhiteSpace(dto.Status) ? "Active" : dto.Status
            };
        }

        public static void UpdateEntity(this SecurityCheckpoint sc, UpdateSecurityCheckpointDto dto)
        {
            sc.Name = dto.Name;
            sc.Status = dto.Status;
        }

        public static GetSecurityCheckpointDetailsDto ToDetailsDto(this SecurityCheckpoint checkpoint)
        {
            var averageWaitTime = checkpoint.CheckpointLogs.Any()
                ? TimeSpan.FromTicks((long)checkpoint.CheckpointLogs.Average(cl => cl.ReportedWaitTime.Ticks))
                : (TimeSpan?)null;

            return new GetSecurityCheckpointDetailsDto
            {
                Id = checkpoint.Id,
                Name = checkpoint.Name,
                TerminalID = checkpoint.TerminalID,
                Status = checkpoint.Status,
                LogCount = checkpoint.CheckpointLogs.Count,
                ActiveShifts = checkpoint.AssignedShifts.Count(ss => ss.EndTime > DateTime.UtcNow),
                AverageWaitTime = averageWaitTime
            };
        }
    }
}
