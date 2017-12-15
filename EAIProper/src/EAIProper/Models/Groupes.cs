using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.Models
{
    [Table("Groupes")]
    public class Groupes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GroupSupId { get; set; }
        public string Name { get; set; }
        public List<Equipments> Equipments = new List<Equipments>();
        public int ProjectId { get; set; }
        public virtual Projects Project { get; set; }
        [Column("children")]
        public List<Groupes> SousGroupes = new List<Groupes>();
    }
}
