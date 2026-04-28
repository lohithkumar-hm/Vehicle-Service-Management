namespace TestBackend.Model.Entity
{
    public class Service
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public string VehicleNumber { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
