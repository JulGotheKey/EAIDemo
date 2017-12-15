using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.Models
{
    [Table("OperatingInformations")]
    public class OperatingInformations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool MoteurImerge { get; set; }
        public string Atex  { get; set; }
        public bool Package { get; set; }
        public bool BackupGenset { get; set; }
        public bool Vfd { get; set; }
        public bool BackupInverter { get; set; }
        public string Etat { get; set; }
        public string PackageTypique { get; set; }
        public int EquipmentId { get; set; }
        public virtual Equipments Equipment { get; set; }
    }
}
