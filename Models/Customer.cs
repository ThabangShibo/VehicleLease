using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleLease.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public int NumberOfVehiclesLeased { get; set; }

        public int CompanyBranchId { get; set; }
        [ForeignKey("CompanyBranchId")]
        public CompanyBranch CompanyBranch { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
