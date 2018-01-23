using EAIProper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.RequestModel
{
    public class EquipmentDesc
    {
        public OperatingInformations OperatingInformations { get; set; }
        public ElectricalDistributions ElectricalDistributions { get; set; }
        public Areas Areas { get; set; }
        public PowerFeatures PowerFeatures { get; set; }
        public MotorizedEquipments MotorizedEquipments { get; set; }
        public Cables Cables { get; set; }
        public ThermalDissipations ThermalDissipations { get; set; }
        public Infos Infos { get; set; }
    }
}
