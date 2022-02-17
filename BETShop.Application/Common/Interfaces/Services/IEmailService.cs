using System.Threading.Tasks;
using BETShop.Domain.Models;

namespace BETShop.Application.Common.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmail(Mail mail);
    }
}
