namespace BETShop.Application.Common.Interfaces.Services
{
    public interface ISessionService
    {
        void SetObjectAsJson(string key, object value);
        T GetObjectFromJson<T>(string key);
    }
}
