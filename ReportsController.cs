using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducationalMonitoringSystem.Models;

namespace EducationalMonitoringSystem.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .Include(s => s.Group)
                .ToListAsync();

            var grades = await _context.Grades.ToListAsync();
            ViewBag.Grades = grades;

            return View(students);
        }
    }
}