using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LINQ_2020_03_31.Models.WW
{
    public partial class VehicleTemperatures1
    {
        [Column("VehicleTemperatureID")]
        public long VehicleTemperatureId { get; set; }
        [Required]
        [StringLength(20)]
        public string VehicleRegistration { get; set; }
        public int ChillerSensorNumber { get; set; }
        public DateTime RecordedWhen { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Temperature { get; set; }
        [StringLength(1000)]
        public string FullSensorData { get; set; }
    }
}
