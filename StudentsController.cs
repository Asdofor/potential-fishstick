using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducationalMonitoringSystem.Models;

namespace EducationalMonitoringSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchCard)
        {
            var query = _context.Students.Include(s => s.Group).AsQueryable();

            if (!string.IsNullOrEmpty(searchCard))
            {
                query = query.Where(s => s.StudentCardNumber.Contains(searchCard));
            }

            var students = await query.ToListAsync();
            return View(students);
        }
    }
}