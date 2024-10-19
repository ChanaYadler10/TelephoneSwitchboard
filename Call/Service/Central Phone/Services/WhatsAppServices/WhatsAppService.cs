using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Service.WhatsAppModels;
using Service.WhatsAppServices;


namespace Service.WhatsAppServices
{
    public class WhatsAppService : IWhatsAppService
    {
        public readonly string accountSid = "AC99b09e68e5277d268dec8d943b6ed40e";
        public readonly string authToken = "790ddb4779a9f512532d416d93bf7a38";
        public readonly string fromWhatsAppNumber = "whatsapp:+14155238886";

        public WhatsAppService()
        {
            TwilioClient.Init(accountSid, authToken);
            
        }

        public async Task<string> SendMessageAsync(WhatsAppMessageRequest request)
        {
            var message = await MessageResource.CreateAsync(
                to: new PhoneNumber($"whatsapp:{request.PhoneNumber}"),
                from: new PhoneNumber(fromWhatsAppNumber),
                body: request.Body);

            return message.Sid;
        }
        

    }
}
