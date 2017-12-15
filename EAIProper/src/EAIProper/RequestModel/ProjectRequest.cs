using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAIProper.RequestModel
{
    public class ProjectRequest
    {
        //public ProjectRequest(string projectName, string projectDescritption)
        //{
        //    this.projectName = projectName;
        //    this.projectName = projectDescritption;
        //}
        public string projectName { get; set; }
        public string projectDescription { get; set; }
    }
}
