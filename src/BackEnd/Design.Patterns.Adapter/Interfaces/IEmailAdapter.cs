using Design.Patterns.Adapter.Client.Request;
using Design.Patterns.Adapter.Model;

namespace Design.Patterns.Adapter.Interfaces
{
    public interface IEmailAdapter
    {
        EmailClientRequest GetEmailRequest(Email emailRequest);
    }
}
