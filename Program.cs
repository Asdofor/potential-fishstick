using Microsoft.EntityFrameworkCore;
using EducationalMonitoringSystem.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();

    if (!dbContext.Groups.Any())
    {
        var realGroup = new Group { Name = "оБ-531-ПИ", Course = 3, Specialty = "Программная инженерия" };
        dbContext.Groups.Add(realGroup);
        dbContext.SaveChanges();

        var teacher1 = new Teacher { LastName = "Иванов", FirstName = "Иван", MiddleName = "Иванович", Position = "Доцент", Email = "ivanov@mail.ru" };
        dbContext.Teachers.Add(teacher1);
        dbContext.SaveChanges();

        var subject1 = new Subject { Name = "Проектирование ИС", Semester = 5, Hours = 72, TeacherId = teacher1.Id };
        dbContext.Subjects.Add(subject1);
        dbContext.SaveChanges();

        var studentsFromVed = new List<Student>
        {
            new Student { LastName = "Иванов", FirstName = "Даниил", MiddleName = "Алексеевич", StudentCardNumber = "2023ПИО-20", EnrollmentDate = DateTime.Now.AddYears(-2), GroupId = realGroup.Id },
            new Student { LastName = "Петров", FirstName = "Кирилл", MiddleName = "Сергеевич", StudentCardNumber = "2023ПИО-124", EnrollmentDate = DateTime.Now.AddYears(-2), GroupId = realGroup.Id },
            new Student { LastName = "Смирнова", FirstName = "Анна", MiddleName = "Дмитриевна", StudentCardNumber = "052400002", EnrollmentDate = DateTime.Now.AddYears(-2), GroupId = realGroup.Id },
            new Student { LastName = "Кузнецов", FirstName = "Максим", MiddleName = "Игоревич", StudentCardNumber = "2023ПИО-155", EnrollmentDate = DateTime.Now.AddYears(-2), GroupId = realGroup.Id },
            new Student { LastName = "Попова", FirstName = "Мария", MiddleName = "Владимировна", StudentCardNumber = "2023ПИО-37", EnrollmentDate = DateTime.Now.AddYears(-2), GroupId = realGroup.Id }
        };

        dbContext.Grades.AddRange(
            new Grade { Value = 5, Date = DateTime.Now.AddDays(-2), StudentId = studentsFromVed[0].Id, SubjectId = subject1.Id },
            new Grade { Value = 4, Date = DateTime.Now.AddDays(-1), StudentId = studentsFromVed[1].Id, SubjectId = subject1.Id }
        );

        dbContext.Attendances.AddRange(
            new Attendance { Date = DateTime.Now.AddDays(-2), IsPresent = true, StudentId = studentsFromVed[0].Id, SubjectId = subject1.Id },
            new Attendance { Date = DateTime.Now.AddDays(-2), IsPresent = false, StudentId = studentsFromVed[1].Id, SubjectId = subject1.Id }
        );

        dbContext.SaveChanges();

    }
}


app.Run();