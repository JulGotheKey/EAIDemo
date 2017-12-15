using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.Models
{
    [Table("Areas")]
    public class Areas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PIDReference { get; set; }
        public string NumeroZone { get; set; }
        public string File { get; set; }
        public int test { get; set; }
        public string ZoneProcess { get; set; }
        public string Atelier { get; set; }
        public string SousAtelier { get; set; }
        public int EquipmentId { get; set; }
        public virtual Equipments Equipment { get; set; }
    }
}
