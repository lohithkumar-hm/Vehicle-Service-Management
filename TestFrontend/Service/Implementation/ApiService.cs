using TestFrontend.Models;
using TestFrontend.Service.Abstraction;
using static System.Net.Mime.MediaTypeNames;

namespace TestFrontend.Service.Implementation
{
    public class ApiService : IService
    {
        private readonly HttpClient client;
        public ApiService(HttpClient client)
        {
            this.client = client;
            client.BaseAddress = new Uri("https://localhost:7280/api/");
        }

        public async Task AddserviceAsync(ServiceViewModel service)
        {
            await client.PostAsJsonAsync<ServiceViewModel>("Service/add", service);
        }

        public async Task AddVehicleAsync(VehicleViewModel vehicle)
        {
            await client.PostAsJsonAsync<VehicleViewModel>("Vehicle/add", vehicle);
        }

        public async Task DeleteServiceAync(int id)
        {
            await client.DeleteAsync($"Service/delete/{id}");
        }

        public async Task DeleteVehicleAync(string number)
        {
            var uri = $"Vehicle/delete/{Uri.EscapeDataString(number)}";
            await client.DeleteAsync(uri);
        }

        public async Task<List<ServiceViewModel>> GetAllserviceAsync()
        {
            return await client.GetFromJsonAsync<List<ServiceViewModel>>("Service/all");
        }

        public async Task<List<VehicleViewModel>> GetAllVehiclesAsync()
        {
            return await client.GetFromJsonAsync<List<VehicleViewModel>>("Vehicle/all");
        }

        public async Task<ServiceViewModel> GetServiceAsync(int id)
        {
            return await client.GetFromJsonAsync<ServiceViewModel>($"Service/{id}");
        }

        public async Task<List<ServiveReportViewModel>> GetServiceReport()
        {
            var response = await client
                    .GetFromJsonAsync<List<ServiveReportViewModel>>($"Service/report");
            return response ?? new List<ServiveReportViewModel>();
        }

        public async Task<VehicleViewModel> GetVehicleAsync(string number)
        {
            return await client.GetFromJsonAsync<VehicleViewModel>($"Vehicle/{number}");
        }

        public async Task UpdateServiceAsync(ServiceViewModel service)
        {
            var url = $"Service/edit/{service.Id}";
            var res = await client.PutAsJsonAsync<ServiceViewModel>(url, service);
        }

        public async Task UpdateVehicleAsync(VehicleViewModel vehicle)
        {
            var url = $"Vehicle/edit/{Uri.EscapeDataString(vehicle.VehicleNumber)}";

            await client.PutAsJsonAsync<VehicleViewModel>(url, vehicle);
        }
    }
}
