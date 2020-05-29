using Design.Patterns.Adapter.Adaptee.Request;
using Design.Patterns.Adapter.Model;

namespace Design.Patterns.Adapter.Interfaces
{
    public interface IEmailAdapter
    {
        void SendEmail(Email emailRequest);
    }
}
