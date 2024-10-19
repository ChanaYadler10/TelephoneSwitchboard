using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Central_Phone.Models;
using Service.Central_Phone.Services;

namespace Service.Central_Phone.Interfaces
{
    public interface IRetrievingRecordingService:IBaseService
    {
        Task<ApiResponse<RetrievingRecording>> GetCallRecordingAsync(string recordGroup, string uniqueId, string recordId);
        Task<ApiResponse<RetrievingRecording>> GetAllRecordingsAsync(string recordgroup, string start, string end);
        Task<bool> DownloadAndConvertRecordingAsync(string recordGroup, string uniqueId, string recordId, string outputFilePath);
        string ExcludeBase64Audio(string jsonResponse);
    }
}
