using AutoMapper;
using TestBackend.DTOs;
using TestBackend.Model.Context;
using TestBackend.Model.Entity;
using TestBackend.Model.Repository.Abstraction;

namespace TestBackend.Model.Repository.Implementation
{
    public class VehicleRepository(AppDbContext db, IMapper mapper) : IVRepository
    {
        public VehicleDTO AddVehicle(VehicleDTO data)
        {
            var all = db.Vehicles;
            var entity = mapper.Map<Vehicle>(data);
            if(all.Any(v => v.VehicleNumber == data.VehicleNumber))
            {
                throw new Exception("This Vehicle Number is Already Exists!");
            }
            all.Add(entity);
            db.SaveChanges();
            return data;

        }

        public VehicleDTO DeleteVehicle(string number)
        {
            var found = db.Vehicles.Find(number);
            if(found != null)
            {
                db.Vehicles.Remove(found);
                db.SaveChanges();
                return mapper.Map<VehicleDTO>(found);
            }
            else
            {
                throw new Exception($"Vehicle with this number : {number} doesn't Exists!");
            }
        }

        public IEnumerable<VehicleDTO> GetAllVehicles()
        {
            var all = db.Vehicles.ToList();
            return mapper.Map<IEnumerable<VehicleDTO>>(all);
            
        }

        public VehicleDTO? GetVehicle(string number)
        {
            return mapper.Map<VehicleDTO>(db.Vehicles.Find(number));
        }

        public VehicleDTO UpdateVehicle(string number, VehicleDTO data)
        {
            var found = db.Vehicles.Find(number);
            if(found != null)
            {
                found.OwnerName = data.OwnerName;
                found.Type = data.Type;
                db.SaveChanges();
                data.VehicleNumber = found.VehicleNumber;
                return data;
            }
            else
            {
                throw new Exception($"Vehicle with this number : {number} doesn't Exists!");
            }
        }
    }
}
