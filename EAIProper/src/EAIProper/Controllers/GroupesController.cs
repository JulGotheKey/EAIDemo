using EAIProper.DAL;
using EAIProper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EAIProper.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class GroupesController : Controller
    {
        private readonly EAIContext _context;

        public GroupesController(EAIContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("projectId={params1}")]
        public JsonResult GetGroups(int params1)
        {
            List<Groupes> groupes = _context.Groupes.Where(g => g.ProjectId == params1).ToList();
            return Json(groupes);
        }

        [AllowAnonymous]
        [HttpGet("groupId={params1}")]
        public JsonResult GetGroup(int params1)
        {
            Groupes groupe = _context.Groupes.Where(g => g.Id == params1).FirstOrDefault();
            return Json(groupe);
        }

        [AllowAnonymous]
        [HttpGet("groupName={params1}&groupSupId={params2}&groupProjectId={params3}")]
        public IActionResult InsertGroup(string params1, int params2, int params3)
        {
            var groupName = params1;
            var groupSupId = params2;
            var groupProjectId = params3;
            Groupes groupe = new Groupes { Name = groupName, GroupSupId = groupSupId, ProjectId = groupProjectId };
            _context.Groupes.Add(groupe);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [AllowAnonymous]
        [HttpGet("groupId={params1}&groupNewName={params2}")]
        public IActionResult UpdateGroupName(int params1, string params2)
        {
            var groupId = params1;
            var groupNewName = params2;
            _context.Groupes.Where(g => g.Id == groupId).FirstOrDefault().Name = groupNewName;
            _context.SaveChanges();
            return StatusCode(201);
        }

        [AllowAnonymous]
        [HttpGet("groupId={params1}")]
        public IActionResult RemoveGroup(int params1)
        {
            var groupId = params1;
            Groupes group = _context.Groupes.Where(g => g.Id == groupId).FirstOrDefault();
            _context.Groupes.Remove(group);
            _context.SaveChanges();
            return StatusCode(201);
        }



        [AllowAnonymous]
        [HttpGet("projectId={params1}")]
        public ActionResult SortSchemGroup(int params1)
        {
            List<Groupes> groupes = new List<Groupes>();
            List<List<Groupes>> groupesProper = new List<List<Groupes>>();
            List<Groupes> groupesFind = new List<Groupes>();
            groupes = _context.Groupes.Where(g=> g.ProjectId == params1).ToList();

            //boucle element par element
            for (int i = 0; i < groupes.Count; i++)
            {
                groupes[i].SousGroupes = groupes.FindAll(g => g.GroupSupId == groupes[i].Id);
                groupes[i].Equipments = _context.Equipments.Where(e => e.GroupeId == groupes[i].Id).ToList();
            }

            //On reboucle avec les nouvelles valeurs
            for (int i = groupes.Count -1; i > 0; i--)
            {
                groupes[i].SousGroupes = groupes.FindAll(g => g.GroupSupId == groupes[i].Id);
            }
            var JsonGroup = Newtonsoft.Json.JsonConvert.SerializeObject(groupes[0], new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            return Json(JsonGroup);
        }

    }
}
