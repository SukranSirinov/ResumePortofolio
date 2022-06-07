using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResumePortofolio.DAL;
using ResumePortofolio.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ResumePortofolio.Controllers
{
    public class HomeController : Controller
    {
       private  AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {

            _context=context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                abouts = await _context.abouts.ToListAsync(),
                sosialMedias = await _context.sosialMedias.ToListAsync(),
                experiences = await _context.experiences.ToListAsync(),
                educations=await _context.educations.ToListAsync(),
                skills=await _context.skills.ToListAsync(),
                details=await _context.details.ToListAsync(),
                workFlows=await _context.workflows.ToListAsync(),
                interests=await _context.interests.ToListAsync(),
                awards=await _context.awards.ToListAsync(), 
                
                
            };
            return View(homeVM);
        }

        

       
    }
}
