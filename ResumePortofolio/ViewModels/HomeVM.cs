using ResumePortofolio.Models;
using System.Collections.Generic;

namespace ResumePortofolio.ViewModels
{
    public class HomeVM
    {
        public List<About> abouts { get; set; }
        public List<SosialMedia> sosialMedias { get; set; } 
        public List<Experience> experiences { get; set; }
        public List<Education> educations { get; set; }
        public List<Skills> skills { get; set; }
        public List<Detail> details { get; set; }
        public List<WorkFlow> workFlows { get; set; }
        public List<Interest> interests { get; set; }
        public List<Award> awards { get; set; }
    }
}
