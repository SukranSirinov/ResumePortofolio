namespace ResumePortofolio.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public int SkillsId { get; set; }    
        public Skills Skills { get; set; }
    }
}
