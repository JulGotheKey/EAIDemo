using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.Models
{
    [Table("ElectricalDistributions")]
    public class ElectricalDistributions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Transfo { get; set; }
        public string TgbtLocation { get; set; }
        public string MccLocation { get; set; }
        public int DepartType { get; set; }
        public int AlimentationElectrique { get; set; }
        public int Intensite { get; set; }
        public int CosPhi { get; set; }
        public int EquipmentId { get; set; }
        public virtual Equipments Equipment { get; set; }
    }
}
