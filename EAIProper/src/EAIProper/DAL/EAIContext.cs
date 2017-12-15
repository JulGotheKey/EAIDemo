using EAIProper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.DAL
{
    public class EAIContext : DbContext
    {
        public EAIContext(DbContextOptions<EAIContext> options)
            :base(options)
        { }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Equipments> Equipments { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<OperatingInformations> OperaOperatingInformations { get; set; }
        public DbSet<ElectricalDistributions> ElectricalDistributions { get; set; }
        public DbSet<PowerFeatures> PowerFeatures { get; set; }
        public DbSet<Cables> Cables { get; set; }
        public DbSet<ThermalDissipations> ThermalDissipations { get; set; }
        public DbSet<Groupes> Groupes { get; set; }
    }
}
