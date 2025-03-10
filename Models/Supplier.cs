using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleLease.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierLocation { get; set; }
        public int CompanyBranchId { get; set; }
        [ForeignKey("CompanyBranchId")]
        public CompanyBranch CompanyBranch { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
