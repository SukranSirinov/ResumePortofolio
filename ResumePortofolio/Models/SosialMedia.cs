namespace ResumePortofolio.Models
{
    public class SosialMedia
    {
        public int Id { get; set; }
        public string Link { get; set; }

        public string Image { get; set; }

        public int AboutId { get; set; } 
        public bool IsActive { get; set; }  
        public About about { get; set; }


    }
}
