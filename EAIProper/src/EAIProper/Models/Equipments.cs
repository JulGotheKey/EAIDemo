using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.Models
{
    [Table("Equipments")]
    public class Equipments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string IdtNumber { get; set; }
        public string Description { get; set; }
        public string Revision { get; set; }
        public string SuiviAsm { get; set; }
        public int? GroupeId { get; set; }
        public virtual Groupes Groupe { get; set; }
        public int ProjectId { get; set; }
        public virtual Projects Project { get; set; }
        public virtual Areas Area { get; set; }
        public virtual OperatingInformations OperatingInformations { get; set; }
        public virtual ElectricalDistributions ElectricalDistributions { get; set; }
        public virtual PowerFeatures PowerFeatures { get; set; }
        public virtual Cables Cables { get; set; }
        public virtual ThermalDissipations ThermalDissipations { get; set; }
    }
}
