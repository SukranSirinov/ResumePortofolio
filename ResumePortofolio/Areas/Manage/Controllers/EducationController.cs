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
    public class EducationController : Controller
    {
        private AppDbContext _context { get; }
        public EducationController(AppDbContext context)
        {

           _context = context;  
        }
        public async Task<IActionResult> Index()
        {
            List<Education> educations= await _context.educations.ToListAsync();
            return View(educations);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Education education)
        {
            if (!ModelState.IsValid) return View();
            bool IsExist = _context.educations.Any(opt => opt.Title.ToLower().Trim() == education.Title.ToLower());
            if (IsExist) return View();
            await _context.educations.AddAsync(education);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Education education = _context.educations.Find(id);
            if (education == null) return NotFound();
            _context.educations.Remove(education);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Update(int id)
        {
            Education education = _context.educations.Find(id);
            if (education == null) return NotFound();
            return View(education);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Education education, int id)
        {
            if (education.Id != id) return BadRequest();
            Education education1= _context.educations.Find(id);
            if(education1==null) return NotFound();
            education1.SubTitle = education.SubTitle;
            education1.Title = education.Title;
            education1.Info = education.Info;
            education1.dateTime=education.dateTime;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
