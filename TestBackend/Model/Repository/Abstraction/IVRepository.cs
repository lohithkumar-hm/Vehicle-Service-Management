using TestBackend.DTOs;
using TestBackend.Model.Entity;

namespace TestBackend.Model.Repository.Abstraction
{
    public interface IVRepository
    {
        IEnumerable<VehicleDTO> GetAllVehicles();
        VehicleDTO? GetVehicle(string number);
        VehicleDTO AddVehicle(VehicleDTO data);
        VehicleDTO UpdateVehicle(string number, VehicleDTO data);
        VehicleDTO DeleteVehicle(string number);
    }
}
