using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Central_Phone.Models;
using Service.Central_Phone.Services;

namespace Service.Central_Phone.Interfaces
{
    public interface IActivecall:IBaseService
    {
        Task<ApiResponse<Activecall>> GetActiveCallsAsync();
        Task<ApiResponse<Activecall>> MakeCallAsync(string stype, string snumber, string ctype, string cnumber, int? wait = null);
    }
}
