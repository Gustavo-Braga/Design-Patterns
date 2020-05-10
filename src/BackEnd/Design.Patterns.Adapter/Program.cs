using Design.Patterns.Adapter.Adapter;
using Design.Patterns.Adapter.Client;
using Design.Patterns.Adapter.Model;
using System;

namespace Design.Patterns.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = new Email("gustavo.braga10@outlook.com", new BodyEmail("teste adapter", "corpo do email"));
            var emailAdapter = new EmailAdapter();
            var emailCliente = new EmailClient();
            emailCliente.SendEmail(emailAdapter.GetEmailRequest(email));
            Console.ReadKey();
        }
    }
}
