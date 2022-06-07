using Microsoft.EntityFrameworkCore;
using ResumePortofolio.Models;

namespace ResumePortofolio.DAL
{
    public class AppDbContext:DbContext
    {
        
        public AppDbContext( DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<SosialMedia> sosialMedias { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<Experience> experiences { get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<Skills> skills { get; set; }
        public DbSet<Detail> details { get; set; }  
        public DbSet<WorkFlow> workflows { get; set; }  
        public DbSet<Interest> interests { get; set; }
        public DbSet<Award > awards { get; set; }

    }
}
