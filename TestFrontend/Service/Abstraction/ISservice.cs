using TestFrontend.Models;

namespace TestFrontend.Service.Abstraction
{
    public interface ISservice
    {
        Task<List<ServiceViewModel>> GetAllserviceAsync();
        Task<ServiceViewModel> GetServiceAsync(int id);
        Task AddserviceAsync(ServiceViewModel service);
        Task UpdateServiceAsync(ServiceViewModel service);
        Task DeleteServiceAync(int id);

        
    }
}
