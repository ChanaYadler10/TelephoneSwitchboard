using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Service.Central_Phone.Services;
using System.Text.Json;
using Service.Central_Phone.Models;

namespace Service.Central_Phone.Interfaces
{
    public interface IIvrService: IBaseService
    {
        Task<ApiResponse<Ivr>> GetIvrListAsync();
        Task<ApiResponse<Ivr>> GetIvrDestinationAsync(int ivr, string name);
    }
}
