using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumePortofolio.DAL;
using ResumePortofolio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumePortofolio.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ExperienceController : Controller
    {
        private AppDbContext _context { get; }
        public ExperienceController(AppDbContext context)
        {
            _context=context;
        }
        public async Task<IActionResult> Index()
        {
            List<Experience> experiences = await _context.experiences.ToListAsync();
            return View(experiences);
        }
        public IActionResult Delete(int id)
        {
            Experience experience    = _context.experiences.Find(id);
            if (experience == null) return NotFound();
            _context.experiences.Remove(experience);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Experience experience)
        {
            if (!ModelState.IsValid) return View();
            bool IsExist=_context.experiences.Any(opt=>opt.Title.ToLower().Trim()==experience.Title.ToLower());
            if (IsExist) return View();
            await _context.experiences.AddAsync(experience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            Experience experience = _context.experiences.Find(id);
            if (experience == null) return NotFound();
            return View(experience);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public  IActionResult Update(Experience experience,int id)
        {
            if(experience.Id!=id) return BadRequest();
            Experience experience1=_context.experiences.Find(id);
            if(experience1==null) return NotFound();
            experience1.SubTitle=experience.SubTitle;
            experience1.Title=experience.Title;
            experience1.Info=experience.Info;
            experience1.dateTime=experience.dateTime;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
