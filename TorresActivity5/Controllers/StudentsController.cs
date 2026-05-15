using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TorresActivity5.Data;
using TorresActivity5.Models;
using TorresActivity5.Models.Entities;

namespace TorresActivity5.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> List(string searchTerm)
        {
            var students = from s in dbContext.Students select s;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                students = students.Where(s => s.FirstName.Contains(searchTerm));
            }

            return View(await students.ToListAsync());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel); 
            }

            var student = new Student
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                MiddleInitial = viewModel.MiddleInitial,
                Suffix = viewModel.Suffix,
                Birthdate = viewModel.Birthdate,
                Gender = viewModel.Gender,
                Nationality = viewModel.Nationality,
                CivilStatus = viewModel.CivilStatus,
                Address = viewModel.Address,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                EmergencyContactFirstName = viewModel.EmergencyContactFirstName,
                EmergencyContactLastName = viewModel.EmergencyContactLastName,
                EmergencyContactRelationship = viewModel.EmergencyContactRelationship,
                EmergencyContactPhoneNumber = viewModel.EmergencyContactPhoneNumber
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Students");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var student = await dbContext.Students.FindAsync(viewModel.Id);

            if (student is not null)
            {
                student.FirstName = viewModel.FirstName;
                student.LastName = viewModel.LastName;
                student.MiddleInitial = viewModel.MiddleInitial;
                student.Suffix = viewModel.Suffix;
                student.Birthdate = viewModel.Birthdate;
                student.Gender = viewModel.Gender;
                student.Nationality = viewModel.Nationality;
                student.CivilStatus = viewModel.CivilStatus;
                student.Address = viewModel.Address;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.EmergencyContactFirstName = viewModel.EmergencyContactFirstName;
                student.EmergencyContactLastName = viewModel.EmergencyContactLastName;
                student.EmergencyContactRelationship = viewModel.EmergencyContactRelationship;
                student.EmergencyContactPhoneNumber = viewModel.EmergencyContactPhoneNumber;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (student is not null)
            {
                dbContext.Students.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }
    }
}