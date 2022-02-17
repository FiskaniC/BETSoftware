using System.Text.Json;
using BETShop.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace BETShop.Infrastructure.Services
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContext;
        public SessionService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void SetObjectAsJson(string key, object value)
        {
            _httpContext.HttpContext.Session.SetString(key, JsonSerializer.Serialize(value));
        }

        public T GetObjectFromJson<T>(string key)
        {
            var value = _httpContext.HttpContext.Session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
