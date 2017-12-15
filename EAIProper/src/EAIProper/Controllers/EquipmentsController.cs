using EAIProper.DAL;
using EAIProper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EquipmentsController : Controller
    {
        private readonly EAIContext _context;
        public EquipmentsController(EAIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CreateInitialEquipment()
        {
            var equipment = new Equipments { IdtNumber = "A0002", Description = "Une simple Description 2", Revision = "Revision B", SuiviAsm = "Ajout", ProjectId = 7 };
            _context.Equipments.Add(equipment);
            _context.SaveChanges();

            
            var _equipmentId = equipment.Id;

            var area = new Areas { PIDReference = "Initial Reference 2", NumeroZone = "Initial Zone", File = " ", ZoneProcess = " ", Atelier = "Initial Atelier", SousAtelier = "Initial Sous Atelier", EquipmentId = _equipmentId };
            var operatinInformation = new OperatingInformations { MoteurImerge = false, Atex = "2", Package = false, BackupGenset = false, Vfd = false, BackupInverter = false, Etat = "En cours", PackageTypique = "Initial Package Typique", EquipmentId = _equipmentId };
            var electricalDistribution = new ElectricalDistributions { Transfo = "Initial Transfo 2", TgbtLocation = "Initial TgbtLocation", MccLocation = "Initial MccLocation", DepartType = 1, AlimentationElectrique = 1, Intensite = 1, CosPhi = 1, EquipmentId = _equipmentId };
            var powerFeature = new PowerFeatures { NominalInstalledPower = 1, MechanicalPowerDemand = 1, MotorEfficiency = 1, MotorEfficiencyClass = "E1", InstalledAbsorbedPowerDp = 1, DutyAbsorbedPower = 1, EquipmentId = _equipmentId };
            var cable = new Cables { TypeCablePuissance = "Initial Type Cable Puissance 2", SectionCable = 1, NombreCable = 1, TypeProtection = "Initial TypeProtection", TypeCableProtection = "Initial Type Cable Protection", TypeCableCommande = "Initial Type Cable commande", LongueurCable = 1, EquipmentId = _equipmentId };
            var thermalDissipation = new ThermalDissipations { HeatDissipation = 2, HVAC = 1, EquipmentId = _equipmentId };

            _context.Areas.Add(area);
            _context.OperaOperatingInformations.Add(operatinInformation);
            _context.ElectricalDistributions.Add(electricalDistribution);
            _context.PowerFeatures.Add(powerFeature);
            _context.Cables.Add(cable);
            _context.ThermalDissipations.Add(thermalDissipation);

            _context.SaveChanges();

            return StatusCode(201);
        }

        //A mettre sur post !!
        [AllowAnonymous]
        [HttpGet("equipmentIdtNumber={params1}&groupeId={params2}&projectId={params3}")]
        public IActionResult CreateSpecificEquipment(string params1, int params2, int params3)
        {
            var equipment = new Equipments();

            //Un equipment peut ne pas avoir de groupe
            if (params2 == 0)
            {
                equipment = new Equipments { IdtNumber = params1, Description = "Une simple Description 2", Revision = "Revision B", SuiviAsm = "Ajout", GroupeId = null, ProjectId = params3 };
            }else
            {
                equipment = new Equipments { IdtNumber = params1, Description = "Une simple Description 2", Revision = "Revision B", SuiviAsm = "Ajout", GroupeId = params2, ProjectId = params3 };
            }
            
            _context.Equipments.Add(equipment);
            _context.SaveChanges();
            var _equipmentId = equipment.Id;

            var area = new Areas { PIDReference = "Initial Reference 2", NumeroZone = "Initial Zone", File = " ", ZoneProcess = " ", Atelier = "Initial Atelier", SousAtelier = "Initial Sous Atelier", EquipmentId = _equipmentId };
            var operatinInformation = new OperatingInformations { MoteurImerge = false, Atex = "2", Package = false, BackupGenset = false, Vfd = false, BackupInverter = false, Etat = "En cours", PackageTypique = "Initial Package Typique", EquipmentId = _equipmentId };
            var electricalDistribution = new ElectricalDistributions { Transfo = "Initial Transfo 2", TgbtLocation = "Initial TgbtLocation", MccLocation = "Initial MccLocation", DepartType = 1, AlimentationElectrique = 1, Intensite = 1, CosPhi = 1, EquipmentId = _equipmentId };
            var powerFeature = new PowerFeatures { NominalInstalledPower = 1, MechanicalPowerDemand = 1, MotorEfficiency = 1, MotorEfficiencyClass = "E1", InstalledAbsorbedPowerDp = 1, DutyAbsorbedPower = 1, EquipmentId = _equipmentId };
            var cable = new Cables { TypeCablePuissance = "Initial Type Cable Puissance 2", SectionCable = 1, NombreCable = 1, TypeProtection = "Initial TypeProtection", TypeCableProtection = "Initial Type Cable Protection", TypeCableCommande = "Initial Type Cable commande", LongueurCable = 1, EquipmentId = _equipmentId };
            var thermalDissipation = new ThermalDissipations { HeatDissipation = 2, HVAC = 1, EquipmentId = _equipmentId };

            _context.Areas.Add(area);
            _context.OperaOperatingInformations.Add(operatinInformation);
            _context.ElectricalDistributions.Add(electricalDistribution);
            _context.PowerFeatures.Add(powerFeature);
            _context.Cables.Add(cable);
            _context.ThermalDissipations.Add(thermalDissipation);

            _context.SaveChanges();

            return StatusCode(201);
        }

        [AllowAnonymous]
        [HttpGet("projectId={params1}")]
        public JsonResult GetEquipments(int params1)
        {
            var projectId = params1;
            List<Equipments> projects = _context.Equipments.Where(e => e.ProjectId == projectId).ToList();
            return Json(projects);
        }

        [AllowAnonymous]
        [HttpGet("equipmentId={params1}")]
        public JsonResult GetEquipment(int params1)
        {
            var projectId = params1;
            Equipments equipment = _context.Equipments.First(e => e.Id == projectId);
            return Json(equipment);
        }

        [AllowAnonymous]
        [HttpGet("equipmentId={projectId}")]
        public string GetEquipmentSpe(int projectId)
        {

            //Areas area = _context.Areas.First(e => e.EquipmentId == projectId);
            //OperatingInformations operatingInformation = _context.OperaOperatingInformations.First(e => e.EquipmentId == projectId);
            //ElectricalDistributions electricalDistribution = _context.ElectricalDistributions.First(e => e.EquipmentId == projectId);
            //PowerFeatures powerFeature = _context.PowerFeatures.First(e => e.EquipmentId == projectId);
            //Cables cable = _context.Cables.First(e => e.EquipmentId == projectId);
            //ThermalDissipations thermalDissipations = _context.ThermalDissipations.First(e => e.EquipmentId == projectId);

            List<Equipments> equip = _context.Equipments.Include(equipment => equipment.Area)
                .Include(e => e.OperatingInformations)
                .Include(e => e.Cables)
                .Include(e => e.ElectricalDistributions)
                .Include(e => e.PowerFeatures)
                .Include(e => e.ThermalDissipations).Where(e => e.Id == projectId).ToList();

            //return Json(equip);
            return JsonConvert.SerializeObject(equip, Formatting.None, new JsonSerializerSettings() {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
