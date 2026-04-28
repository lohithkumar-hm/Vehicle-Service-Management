using TestFrontend.Models;

namespace TestFrontend.Service.Abstraction
{
    public interface IService
    {
        Task<List<VehicleViewModel>> GetAllVehiclesAsync();
        Task<VehicleViewModel> GetVehicleAsync(string number);
        Task AddVehicleAsync(VehicleViewModel vehicle);
        Task UpdateVehicleAsync(VehicleViewModel vehicle);
        Task DeleteVehicleAync(string number);


        Task<List<ServiceViewModel>> GetAllserviceAsync();
        Task<ServiceViewModel> GetServiceAsync(int id);
        Task AddserviceAsync(ServiceViewModel service);
        Task UpdateServiceAsync(ServiceViewModel service);
        Task DeleteServiceAync(int id);

        Task<List<ServiveReportViewModel>> GetServiceReport();
    }
}
