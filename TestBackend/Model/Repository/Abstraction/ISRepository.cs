using TestBackend.DTOs;

namespace TestBackend.Model.Repository.Abstraction
{
    public interface ISRepository
    {
        IEnumerable<ServiceDTO> GetAllServices();
        ServiceDTO? GetService(int number);
        ServiceDTO AddService(ServiceDTO data);
        ServiceDTO UpdateService(int number, ServiceDTO data);
        ServiceDTO DeleteService(int number);

        List<ServiceReportDTO> GetServiceReport();
    }
}
