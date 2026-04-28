using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TestFrontend.Models
{
    public class VehicleViewModel
    {
        [Required(ErrorMessage = "Vehicle Number Required")]
        [MaxLength(10, ErrorMessage = "Vehicle Number cannot exceeds 10 character")]
        public string VehicleNumber { get; set; }

        [Required(ErrorMessage = "Owner Name Required")]
        [MaxLength(50, ErrorMessage = "Owner Name cannot exceeds 50 character")]
        public string OwnerName { get; set; }


        [Required(ErrorMessage = "Vehicle Type Required")]
        [MaxLength(10, ErrorMessage = "Vehicle Type cannot exceeds 10 character")]
        public string Type { get; set; }
    }
}
