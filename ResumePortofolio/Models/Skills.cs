using System.Collections.Generic;

namespace ResumePortofolio.Models
{
    public class Skills
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<Detail> details { get;set; }
        public List<WorkFlow> workflows { get;set; }
    }
}
