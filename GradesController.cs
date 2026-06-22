using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducationalMonitoringSystem.Models;

namespace EducationalMonitoringSystem.Controllers
{
    public class GradesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var grades = await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .ToListAsync();
            return View(grades);
        }
    }
}