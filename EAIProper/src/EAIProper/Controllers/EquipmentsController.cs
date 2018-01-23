using EAIProper.DAL;
using EAIProper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using EAIProper.RequestModel;

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
        [HttpPost]
        public IActionResult CreateSpecificEquipment([FromBody] JObject item)
        {
            var equipment = new Equipments();

            //TODO CHANGE Equipment Id

            JObject dataObject = item;
            string dataObjectStr = dataObject.ToString();
            var equipmentData = JsonConvert.DeserializeObject<EquipmentDesc>(dataObjectStr);

            //Le groupe d'une equipment est facultatif
            if (equipmentData.Infos.GroupeId == 0)
            {
                equipment = new Equipments { IdtNumber = equipmentData.Infos.IdtNumber, Description = equipmentData.MotorizedEquipments.Description,
                    Revision = equipmentData.MotorizedEquipments.Revision, SuiviAsm = equipmentData.MotorizedEquipments.Revision,
                    GroupeId = null, ProjectId = equipmentData.Infos.ProjectId };
            }
            else
            {
                equipment = new Equipments { IdtNumber = equipmentData.Infos.IdtNumber, Description = equipmentData.MotorizedEquipments.Description,
                    Revision = equipmentData.MotorizedEquipments.Revision, SuiviAsm = equipmentData.MotorizedEquipments.SuiviAsm, GroupeId = equipmentData.Infos.GroupeId, ProjectId = equipmentData.Infos.ProjectId };
            }

            _context.Equipments.Add(equipment);
            _context.SaveChanges();
            var _equipmentId = equipment.Id;

            Areas area = equipmentData.Areas;
            area.EquipmentId = _equipmentId;

            OperatingInformations operatinInformation = equipmentData.OperatingInformations;
            operatinInformation.EquipmentId = _equipmentId;

            ElectricalDistributions electricalDistribution = equipmentData.ElectricalDistributions;
            electricalDistribution.EquipmentId = _equipmentId;

            PowerFeatures powerFeature = equipmentData.PowerFeatures;
            powerFeature.EquipmentId = _equipmentId;

            Cables cable = equipmentData.Cables;
            cable.EquipmentId = _equipmentId;

            ThermalDissipations thermalDissipation = equipmentData.ThermalDissipations;
            thermalDissipation.EquipmentId = _equipmentId;

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

        [AllowAnonymous]
        [HttpGet("projectId={params1}")]
        public string GetEquipmentsSpe(int params1)
        {
            var groupId = params1;
            List<Equipments> equip = _context.Equipments.
                Include(e => e.ThermalDissipations)
                .Include(e => e.Groupe)
                .Include(e => e.Cables)
                .Include(e => e.ElectricalDistributions)
                .Include(e => e.PowerFeatures)
                .Where(e => e.ProjectId.Equals(groupId)).ToList();

            return JsonConvert.SerializeObject(equip, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [AllowAnonymous]
        [HttpGet("projectId={params1}")]
        public string getWiringPower(int params1)
        {
            List<Cables> cables = new List<Cables>();
            List<Equipments> equipments = _context.Equipments
                .Include(e => e.Cables)
                .Where(e => e.ProjectId == params1).ToList();
            foreach(Equipments e in equipments)
            {
                cables.Add(e.Cables);
            }
            return JsonConvert.SerializeObject(cables, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
