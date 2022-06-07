namespace ResumePortofolio.Models
{
    public class WorkFlow
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SkillsId { get; set; }
        public Skills Skills { get; set; }


    }
}
