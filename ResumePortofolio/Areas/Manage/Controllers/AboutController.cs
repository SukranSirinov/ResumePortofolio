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
    public class AboutController : Controller
    {
        private AppDbContext _context { get; }
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<About> abouts = await _context.abouts.ToListAsync();
            return View(abouts);
        }
      public IActionResult Update(int id)
        {
            About about = _context.abouts.Find(id);
            if (about == null) return NotFound();
            return View(about);
        }
       
        public IActionResult Delete(int id)
        {
            About about =  _context.abouts.Find(id);
            if(about == null) return NotFound();
            _context.abouts.Remove(about);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, About about)
        {
            if(about.Id !=id) return BadRequest();
            About about1 = _context.abouts.Find(id);
            if (about1 == null) return NotFound();
            about1.FirstName = about.FirstName;
            about1.LastName=about.LastName;
            about1.Adress=about.Adress;
            about1.PhoneNumber=about.PhoneNumber;
            about1.Email = about.Email;
            about1.Title=about.Title;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));


        }
    }
}
