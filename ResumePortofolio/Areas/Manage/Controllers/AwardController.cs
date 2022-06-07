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
    public class AwardController : Controller
    {
        private AppDbContext _context { get; }
        public AwardController(AppDbContext context)
        {
            _context=context;
        }
        public async Task<IActionResult> Index()
        {
            List<Award> awards = await _context.awards.ToListAsync();
            return View(awards);
        }
        public IActionResult Delete(int id)
        {
            Award award = _context.awards.Find(id);
            if (award == null) return NotFound();
            _context.awards.Remove(award);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Update(int id)
        {
            Award award = _context.awards.Find(id);
            if (award == null) return NotFound();
            return View(award);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Award award, int id)
        {
            if (award.Id != id) return BadRequest();
            Award award1 = _context.awards.Find(id);
            if (award1 == null) return NotFound();
            award1.Text = award.Text;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Award award)
        {
            if (!ModelState.IsValid) return View();
            bool IsExist = _context.awards.Any(opt => opt.Text.ToLower().Trim() == award.Text.ToLower());
            if (IsExist) return View();
            await _context.awards.AddAsync(award);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
