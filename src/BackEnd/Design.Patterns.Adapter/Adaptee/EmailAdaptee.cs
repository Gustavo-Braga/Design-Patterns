using Design.Patterns.Adapter.Adaptee.Request;
using System;

namespace Design.Patterns.Adapter.Adaptee
{
    public class EmailAdaptee
    {
        public void SendEmail(EmailAdapteeRequest emailRequest)
        {
            Console.WriteLine(emailRequest.Email);
            Console.WriteLine(emailRequest.BodyJson);
        }

    }
}
