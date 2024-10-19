using Service.WhatsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.WhatsAppServices
{
    public interface IUnOfficialIWhatsAppService
    {
        Task SendMessageAsync(WhatsAppMessageRequest request);
    }
}
