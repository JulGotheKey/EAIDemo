using EAIProper.DAL;
using EAIProper.Models;
using EAIProper.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class ProjectsController : Controller
    {
        private readonly EAIContext _context;
   
        public ProjectsController(EAIContext context)
        {
            _context = context;
        }

        // On crée le groupe principal par défaut
        public int CreateInitialGroupe(int projectIdIn)
        {
            Groupes groupe = new Groupes { GroupSupId = 0, Name = "SuperGroupe", ProjectId = projectIdIn };
            _context.Groupes.Add(groupe);
            _context.SaveChanges();
            return groupe.Id;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateProjectPost([FromBody]ProjectRequest model)
        {
            var projectName = model.projectName;
            var projectDescription = model.projectDescription;
            var projectDate = DateTime.Now;
            Projects project = new Projects { Name = projectName, CreationDate = projectDate, Description = projectDescription };
            _context.Projects.Add(project);
            _context.SaveChanges();
            CreateInitialGroupe(project.Id);
            return StatusCode(201);
        }

        [HttpGet]
        public IEnumerable<Projects> Get()
        {
            return _context.Projects.ToList();
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetAllProjects()
        {
            return Json(_context.Projects.ToList());
        }

        [AllowAnonymous]
        [HttpGet("projectId={params1}")]
        public JsonResult GetProject(int params1)
        {
            var projectId = params1;
            Projects project = _context.Projects.First(p => p.Id.Equals(projectId));
            return Json(project);
        }
    }
}
