using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.Models
{
    [Table("ThermalDissipations")]
    public class ThermalDissipations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int HeatDissipation { get; set; }
        public int HVAC { get; set; }
        public int EquipmentId { get; set; }
        public virtual Equipments Equipment { get; set; }
    }
}
