using Design.Patterns.Adapter.Client.Request;
using Design.Patterns.Adapter.Interfaces;
using Design.Patterns.Adapter.Model;
using Newtonsoft.Json;

namespace Design.Patterns.Adapter.Adapter
{
    public class EmailAdapter: IEmailAdapter
    {
        public EmailClientRequest GetEmailRequest(Email emailRequest)
        {
            return new EmailClientRequest(emailRequest.Address, JsonConvert.SerializeObject(emailRequest.Body));
        }
    }
}
