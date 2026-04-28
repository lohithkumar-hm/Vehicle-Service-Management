namespace TestBackend.Model.Entity
{
    public class Vehicle
    {
        public string VehicleNumber { get; set; }
        public string OwnerName { get; set; }
        //public VehicleType Type { get; set; }
        public string Type { get; set; }

        public IEnumerable<Service> Service { get; set; }
    }
}
