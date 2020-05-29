using Design.Patterns.Adapter.Adaptee;
using Design.Patterns.Adapter.Adaptee.Request;
using Design.Patterns.Adapter.Interfaces;
using Design.Patterns.Adapter.Model;
using Newtonsoft.Json;

namespace Design.Patterns.Adapter.Adapter
{
    public class EmailAdapter : EmailAdaptee, IEmailAdapter
    {
        public void SendEmail(Email email)
        {
            var emailRequest = new EmailAdapteeRequest(email.Address, JsonConvert.SerializeObject(email.Body));
            base.SendEmail(emailRequest);
        }
    }
}
