using Domain.StoreContext.Services;

namespace Testes.Mocks
{
    public class MockEmailService : IEmailService
    {
        public void SendEmail(string to, string from, string subject, string body) { }
    }
}