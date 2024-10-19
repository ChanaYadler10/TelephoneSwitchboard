using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.WhatsAppModels;
using Service.WhatsAppServices;

namespace Service.WhatsAppServices
{
    public interface IWhatsAppService
    {
        Task<string> SendMessageAsync(WhatsAppMessageRequest request);
    }
}
