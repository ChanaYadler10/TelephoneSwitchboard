// Service / Interfaces / IRepresentativeService.cs
using Service.DTOs;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface IRepresentativeService
    {
        RepresentativeInfoDTO GetRepresentativeInfo(string representativeId);
        List<RepresentativeInfoDTO> GetAllRepresentativesWithRoleClaims();
        bool DeleteRepresentative(string representativeId);
        RepresentativeInfoDTO AddRepresentative(RepresentativeInfoDTO representative);
        List<string> GetAvailableRoles(); // Add this method
    }
}
