using PetAdminConnect.Shared.Responses;

namespace PetAdminConnect.Backend.Services
{
    public interface IApiService
    {
        Task<Response<T>> GetAsync<T>(string servicePrefix, string controller); 
    }
}
