using System.Threading.Tasks;
using BETShop.Application.Common.Interfaces.Services;
using BETShop.Domain.Models;

namespace BETShop.Application.Tests.Initialize
{
    internal class TestEmailService : IEmailService
    {
        public async Task SendEmail(Mail mail)
        {
            return;
        }
    }
}