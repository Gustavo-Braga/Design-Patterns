using Design.Patterns.Adapter.Client.Request;
using Design.Patterns.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design.Patterns.Adapter.Client
{
   public class EmailClient
    {
        public void SendEmail(EmailClientRequest emailRequest)
        {
            Console.WriteLine(emailRequest.Email);
            Console.WriteLine(emailRequest.BodyJson);
        }

    }
}
