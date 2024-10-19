using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Central_Phone.Models;
using Service.Central_Phone.Services;

namespace Service.Central_Phone.Interfaces
{
    public interface ITelephoneExtensionService:IBaseService
    {
        Task<ApiResponse<TelephoneExtension>> GetTelephoneLines(string authUsername, string authPassword);
        Task<bool> DeleteTelephoneLine(string authUsername, string authPassword, string name);
        Task<ApiResponse<TelephoneExtension>> GetTelephoneLineFields(string authUsername, string authPassword, long name);
        Task<int?> CountTelephoneLinesWithSameHardwareAddress(string authUsername, string authPassword, string address);
        Task<ApiResponse<TelephoneExtension>> GetLightweightTelephoneLinesList(string authUsername, string authPassword);
        Task<bool> RebootHandset(string authUsername, string authPassword, string name);
        Task<ApiResponse<TelephoneExtension>> GetSipRegistrations(string authUsername, string authPassword, string name);
        Task<ApiResponse<TelephoneExtension>> GetAllTelephoneLines(string authUsername, string authPassword);
        Task<bool> UnlockTelephoneLine(string authUsername, string authPassword, string name);
        Task<bool> UnregisterTelephoneLine(string authUsername, string authPassword, string name);
        Task<ApiResponse<TelephoneExtension>> GetNextAvailableTelephoneLine(string authUsername, string authPassword);
        Task<bool> UpdateTelephoneLine(string authUsername, string authPassword, string name, string description);
    }
}
