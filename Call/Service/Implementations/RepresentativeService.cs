using System.Collections.Generic;
using Repository.Interfaces;
using Service.DTOs;
using Service.Interfaces;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace Service.Implementations
{
    public class RepresentativeService : IRepresentativeService
    {
        private readonly IRepresentativeRepository _representativeRepository;
        private readonly ILogger<RepresentativeService> _logger;

        public RepresentativeService(IRepresentativeRepository representativeRepository, ILogger<RepresentativeService> logger)
        {
            _representativeRepository = representativeRepository;
            _logger = logger;
        }

        public RepresentativeInfoDTO GetRepresentativeInfo(string representativeId)
        {
            var representative = _representativeRepository.GetRepresentativeInfo(representativeId);
            if (representative == null)
            {
                return null;
            }

            return new RepresentativeInfoDTO
            {
                
                Name = representative.Name,
                Email = representative.Email,
                RoleClaims = representative.RoleClaims
            };
        }

        public List<RepresentativeInfoDTO> GetAllRepresentativesWithRoleClaims()
        {
            var representatives = _representativeRepository.GetAllRepresentativesWithRoleClaims();
            return representatives.Select(r => new RepresentativeInfoDTO
            {

                Name = r.Name,
                Email = r.Email,
                RoleClaims = r.RoleClaims
            }).ToList();
        }

        public bool DeleteRepresentative(string representativeId)
        {
            return _representativeRepository.DeleteRepresentative(representativeId);
        }

        public RepresentativeInfoDTO AddRepresentative(RepresentativeInfoDTO representative)
        {
            // Get available roles from the repository
            var availableRoles = _representativeRepository.GetAvailableRoles();

            // Debug logging
            _logger.LogInformation($"Available roles: {string.Join(", ", availableRoles)}");
            _logger.LogInformation($"Requested roles: {string.Join(", ", representative.RoleClaims)}");

            // Validate roles
            var invalidRoles = representative.RoleClaims.Except(availableRoles).ToList();
            if (invalidRoles.Any())
            {
                var errorMessage = $"The following roles are invalid: {string.Join(", ", invalidRoles)}";
                _logger.LogError(errorMessage);
                throw new ArgumentException(errorMessage);
            }

            var representativeEntity = new RepresentativeInfo
            {
                Name = representative.Name,
                Email = representative.Email,
                RoleClaims = representative.RoleClaims ?? new List<string>() // Ensure RoleClaims is not null
            };

            var addedRepresentative = _representativeRepository.AddRepresentative(representativeEntity);
            return new RepresentativeInfoDTO
            {
               
                Name = addedRepresentative.Name,
                Email = addedRepresentative.Email,
                RoleClaims = addedRepresentative.RoleClaims
            };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public List<string> GetAvailableRoles()
        {
            return _representativeRepository.GetAvailableRoles();
        }
    }
}
