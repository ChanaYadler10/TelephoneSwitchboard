// Repository / Interfaces / IRepresentativeRepository.cs
using Repository.Models;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IRepresentativeRepository
    {
        RepresentativeInfo GetRepresentativeInfo(string representativeId);
        List<RepresentativeInfo> GetAllRepresentativesWithRoleClaims();
        bool DeleteRepresentative(string representativeId);
        RepresentativeInfo AddRepresentative(RepresentativeInfo representative);
        List<string> GetAvailableRoles(); // Add this method
    }
}
