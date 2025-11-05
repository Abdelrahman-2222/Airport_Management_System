using Airplane_UI.Contracts.SecurityGates;
using Airplane_UI.Data;
using Airplane_UI.DTOs.SecurityGates.StaffShift;
using Airplane_UI.Entities.SecurityGates;
using Microsoft.EntityFrameworkCore;
using System;

namespace Airplane_UI.Services.SecurityGates;

///
/// Provides implementation for Staff Shift service operations such as retrieving,
/// creating, updating, and deleting staff shifts.
///
public class StaffShiftService : IStaffShiftService
{
    ///
    /// The database context used for accessing Staff Shift data.
    ///
    private readonly AirplaneManagementSystemContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="StaffShiftService"/> class.
    /// </summary>
    /// <param name="context">The database context for the airplane management system.</param>
    public StaffShiftService(AirplaneManagementSystemContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all staff shifts asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation that returns a list of staff shift DTOs.</returns>
    public async Task<List<GetStaffShiftDto>> GetAllAsync()
    {
        return await _context.StaffShifts
            .Select(ss => new GetStaffShiftDto
            {
                Id = ss.Id,
                StaffID = ss.StaffID,
                AssignedCheckpointID = ss.AssignedCheckpointID,
                AssignedDeskID = ss.AssignedDeskID,
                StartTime = ss.StartTime,
                EndTime = ss.EndTime
            })
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves a staff shift by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the staff shift.</param>
    /// <returns>The staff shift DTO if found; otherwise, null.</returns>
    public async Task<GetStaffShiftDto?> GetByIdAsync(int id)
    {
        var shift = await _context.StaffShifts.FirstOrDefaultAsync(s => s.Id == id);
        if (shift == null) return null;

        return new GetStaffShiftDto
        {
            Id = shift.Id,
            StaffID = shift.StaffID,
            AssignedCheckpointID = shift.AssignedCheckpointID,
            AssignedDeskID = shift.AssignedDeskID,
            StartTime = shift.StartTime,
            EndTime = shift.EndTime
        };
    }

    /// <summary>
    /// Creates a new staff shift asynchronously.
    /// </summary>
    /// <param name="createDto">The data transfer object containing details for the new staff shift.</param>
    /// <returns>The created staff shift DTO.</returns>
    public async Task<GetStaffShiftDto> CreateAsync(CreateStaffShiftDto createDto)
    {
        var shift = new StaffShift
        {
            StaffID = createDto.StaffID,
            AssignedCheckpointID = createDto.AssignedCheckpointID,
            AssignedDeskID = createDto.AssignedDeskID,
            StartTime = createDto.StartTime,
            EndTime = createDto.EndTime
        };

        await _context.StaffShifts.AddAsync(shift);
        await _context.SaveChangesAsync();

        return new GetStaffShiftDto
        {
            Id = shift.Id,
            StaffID = shift.StaffID,
            AssignedCheckpointID = shift.AssignedCheckpointID,
            AssignedDeskID = shift.AssignedDeskID,
            StartTime = shift.StartTime,
            EndTime = shift.EndTime
        };
    }

    /// <summary>
    /// Updates an existing staff shift asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the staff shift to update.</param>
    /// <param name="updateDto">The data transfer object containing updated staff shift details.</param>
    /// <returns>The updated staff shift DTO if successful; otherwise, null.</returns>
    public async Task<GetStaffShiftDto?> UpdateAsync(int id, UpdateStaffShiftDto updateDto)
    {
        var existingShift = await _context.StaffShifts.FindAsync(id);
        if (existingShift == null) return null;

        existingShift.AssignedCheckpointID = updateDto.AssignedCheckpointID;
        existingShift.AssignedDeskID = updateDto.AssignedDeskID;
        existingShift.StartTime = updateDto.StartTime;
        existingShift.EndTime = updateDto.EndTime;

        await _context.SaveChangesAsync();

        return new GetStaffShiftDto
        {
            Id = existingShift.Id,
            StaffID = existingShift.StaffID,
            AssignedCheckpointID = existingShift.AssignedCheckpointID,
            AssignedDeskID = existingShift.AssignedDeskID,
            StartTime = existingShift.StartTime,
            EndTime = existingShift.EndTime
        };
    }

    /// <summary>
    /// Deletes a staff shift asynchronously by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the staff shift to delete.</param>
    /// <returns>A task representing the asynchronous operation that returns a message confirming deletion or a failure message.</returns>
    public async Task<string> DeleteAsync(int id)
    {
        var shift = await _context.StaffShifts.FindAsync(id);
        if (shift == null) return "Shift not found";

        _context.StaffShifts.Remove(shift);
        await _context.SaveChangesAsync();

        return $"{id} deleted successfully";
    }

}