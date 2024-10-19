using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Service.Central_Phone.Models;



namespace Service.Central_Phone.Interfaces
{
    public interface IBaseService
    {
        Task<ApiResponse<T>> GetAsync<T>(string endpoint, Dictionary<string, string> queryParams) where T : class;
    }

}

