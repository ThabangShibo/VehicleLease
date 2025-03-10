using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleLease.Models
{
    public class CompanyBranch
    {
        [Key]
        public int CompanyBranchId { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string BranchLocation { get; set; }
        [Required]
        public int NumberOfVehiclesOwned { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
