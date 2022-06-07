using System.Collections.Generic;

namespace ResumePortofolio.Models
{
    public class About
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }   
       public List<SosialMedia> sosialMedias { get; set; }

    }
}
