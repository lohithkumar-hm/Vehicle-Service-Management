namespace TestBackend.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public string VehicleNumber { get; set; }
    }
}
