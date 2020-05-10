using System;
using System.Collections.Generic;
using System.Text;

namespace Design.Patterns.Adapter.Model
{
    public class Email
    {
        public Email(string address, BodyEmail body)
        {
            Address = address;
            Body = body;
        }

        public string Address { get; set; }
        public BodyEmail Body { get; set; }

    }
    public class BodyEmail
    {
        public BodyEmail(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }

        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
