using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.Models
{
    [Table("PowerFeatures")]
    public class PowerFeatures
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NominalInstalledPower { get; set; }
        public int MechanicalPowerDemand { get; set; }
        public int MotorEfficiency { get; set; }
        public string MotorEfficiencyClass { get; set; }
        public int InstalledAbsorbedPowerDp { get; set; }
        public int DutyAbsorbedPower { get; set; }
        public int EquipmentId { get; set; }
        public virtual Equipments Equipment { get; set; }
    }
}
