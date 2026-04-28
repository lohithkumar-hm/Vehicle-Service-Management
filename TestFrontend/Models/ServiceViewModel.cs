using System.ComponentModel.DataAnnotations;

namespace TestFrontend.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Service Date Required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Service Type Required")]
        [MaxLength(100, ErrorMessage = "Servive type exceeds 100 character")]
        public string Type { get; set; }



        [Required(ErrorMessage = "Service Cost Required")]
        public decimal Cost { get; set; }


        [Required(ErrorMessage = "Vehicle Number Required")]
        [MaxLength(10, ErrorMessage = "Vehicle Number cannot exceeds 10 character")]
        public string VehicleNumber { get; set; }
    }
}
