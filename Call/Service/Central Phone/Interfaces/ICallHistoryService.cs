using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Service.Central_Phone.Models;
using Service.Central_Phone.Services;

namespace Service.Central_Phone.Interfaces
{
    public interface ICallHistoryService:IBaseService
    {
        Task<ApiResponse<GetCallHistory>> GetFieldOfCompletedCallAsync(string uniqueid);
        Task<ApiResponse<GetCallHistory>> GetArrayFieldsOfCompletedCallsAsync(DateTime start, DateTime end);
    }
}
