using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleLease.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Required]
        public string VehicleMake { get; set; }
        [Required]
        public string VehicleModel { get; set; }
        [Required]
        public string VehicleMileage { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int DriverId { get; set; }
        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }


    }
}
