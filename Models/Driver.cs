using System.ComponentModel.DataAnnotations;

namespace VehicleLease.Models
{
    public class Driver
    {
        [Key]
        public int  DriverId { get; set; }
        public string DriverName { get; set; }
        public DateOnly DriverDateOfBirth { get; set; }
        public ICollection<Vehicle>  Vehicles { get; set; }

    }
}
