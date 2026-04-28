using AutoMapper;
using TestBackend.DTOs;
using TestBackend.Model.Context;
using TestBackend.Model.Entity;
using TestBackend.Model.Repository.Abstraction;
using static System.Net.Mime.MediaTypeNames;

namespace TestBackend.Model.Repository.Implementation
{
    public class ServiceVRepository(AppDbContext db, IMapper mapper) : ISRepository
    {
        public ServiceDTO AddService(ServiceDTO data)
        {
            var all = db.Services;
            var entity = mapper.Map<Service>(data);
            if (entity.Date > DateTime.UtcNow)
            {
                throw new Exception("You cannot assign future date");
            }
            all.Add(entity);
            db.SaveChanges();
            return data;
        }

        public ServiceDTO DeleteService(int number)
        {
            var found = db.Services.Find(number);
            if (found != null)
            {
                db.Services.Remove(found);
                db.SaveChanges();
                return mapper.Map<ServiceDTO>(found);
            }
            else
            {
                throw new Exception($"Service with this number : {number} doesn't Exists!");
            }
        }

        public IEnumerable<ServiceDTO> GetAllServices()
        {
            var all = db.Services.ToList();
            return mapper.Map<IEnumerable<ServiceDTO>>(all);
        }

        public ServiceDTO? GetService(int number)
        {
            return mapper.Map<ServiceDTO>(db.Services.Find(number));
        }

        public List<ServiceReportDTO> GetServiceReport()
        {
            var res = db.Vehicles
                .GroupJoin(
                    db.Services,
                    v => v.VehicleNumber,
                    s => s.VehicleNumber,
                    (v, services) => new ServiceReportDTO
                    {
                        VehicleNumber = v.VehicleNumber,
                        TotalCost = services.Sum(s => (decimal?)s.Cost) ?? 0
                    }
                ).ToList();

            return res;
        }

        public ServiceDTO UpdateService(int number, ServiceDTO data)
        {
            if(data.Date > DateTime.UtcNow)
            {
                throw new Exception("You cannot assign future date");
            }
            var found = db.Services.Find(number);
            if (found != null)
            {
                found.Date = data.Date;
                found.Type = data.Type;
                found.Cost = data.Cost;
                found.VehicleNumber = data.VehicleNumber;
                db.SaveChanges();
                data.Id = found.Id;
                return data;
            }
            else
            {
                throw new Exception($"Service with this number : {number} doesn't Exists!");
            }
        }
    }
}
