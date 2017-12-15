using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.Models
{
    [Table("Cables")]
    public class Cables
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TypeCablePuissance { get; set; }
        public int SectionCable { get; set; }
        public int NombreCable { get; set; }
        public string TypeProtection { get; set; }
        public string TypeCableProtection { get; set; }
        public string TypeCableCommande { get; set; }
        public int LongueurCable { get; set; }
        public int EquipmentId { get; set; }
        public virtual Equipments Equipment { get; set; }
    }
}
