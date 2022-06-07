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
    public class InterestController : Controller
    {
        private AppDbContext _context { get; }
        public InterestController(AppDbContext context)
        {

            _context=context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Interest interest)
        {
            if (!ModelState.IsValid) return View();
            bool IsExist = _context.interests.Any(opt => opt.Text.ToLower().Trim() == interest.Text.ToLower());
            if (IsExist) return View();
            await _context.interests.AddAsync(interest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task< IActionResult> Index()
        {
            List<Interest> interests = await _context.interests.ToListAsync();
            return View(interests);
        }
        public IActionResult Delete(int id)
        {
            Interest interest = _context.interests.Find(id);
            if (interest == null) return NotFound();
            _context.interests.Remove(interest);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Update(int id)
        {
            Interest interest = _context.interests.Find(id);
            if (interest == null) return NotFound();
            return View(interest);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Interest interest, int id)
        {
            if (interest.Id != id) return BadRequest();
            Interest interest1 = _context.interests.Find(id);
            if (interest1 == null) return NotFound();
            interest1.Text = interest.Text;           
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
