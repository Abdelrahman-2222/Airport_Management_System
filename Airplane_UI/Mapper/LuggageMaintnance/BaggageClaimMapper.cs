using Airplane_UI.DTOs.LuggageMaintnance.BaggageClaim;
using Airplane_UI.Entities.LuggageMaintnance;

namespace Airplane_UI.Mapper.LuggageMaintnance
{
    /// <summary>
    /// Provides mapping methods between BaggageClaim entities and their corresponding DTOs.
    /// </summary>
    public static class BaggageClaimMapper
    {
        /// <summary>
        /// Converts a BaggageClaim entity to a GetBaggageClaimDto.
        /// </summary>
        /// <param name="claims">The BaggageClaim entity instance to map.</param>
        /// <returns>
        /// A GetBaggageClaimDto representing the mapped data of the specified BaggageClaim entity.
        /// </returns>
        public static GetBaggageClaimDto ToDto(this BaggageClaim claims)
        {
            var result = new GetBaggageClaimDto
            {
                Id = claims.Id,
                CarouselNumber = claims.CarouselNumber,
                Status = claims.Status.ToString(),
                TerminalName = claims.Terminal?.Name
            };
            return result;
        }

        /// <summary>
        /// Maps a CreateAndUpdateBaggageClaimDto to a new BaggageClaim entity.
        /// </summary>
        /// <param name="dto">The DTO containing data for creating or updating a baggage claim record.</param>
        /// <returns>
        /// A new BaggageClaim entity populated with values from the specified DTO.
        /// </returns>
        public static BaggageClaim ToEntity(this CreateAndUpdateBaggageClaimDto dto)
        {
            return new BaggageClaim
            {
                CarouselNumber = dto.CarouselNumber,
                Status = dto.Status,
                TerminalId = dto.TerminalId
            };
        }

        /// <summary>
        /// Updates an existing BaggageClaim entity with data from a CreateAndUpdateBaggageClaimDto.
        /// </summary>
        /// <param name="dto">The DTO containing the updated baggage claim data.</param>
        /// <param name="entity">The existing BaggageClaim entity to be updated.</param>
        public static void UpdateEntity(this CreateAndUpdateBaggageClaimDto dto, BaggageClaim entity)
        {
            if (entity == null || dto == null) return;

            entity.CarouselNumber = dto.CarouselNumber;
            entity.Status = dto.Status;
            entity.TerminalId = dto.TerminalId;
        }
    }
}
