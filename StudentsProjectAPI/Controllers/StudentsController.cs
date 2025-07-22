using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsProjectAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsProjectAPI.Models.DTO;


namespace StudentsProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentsController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }
        [HttpPut]
        public IActionResult UpdateStudent(UpdateStudentDTO request)
        {
            // 1. Find student by ID
            var existingStudent = _studentDbContext.Students
                .FirstOrDefault(s => s.Id == request.Id);

            if (existingStudent == null)
            {
                return NotFound($"Student with ID {request.Id} not found.");
            }

            // 2. Update fields
            existingStudent.Name = request.Name;
            existingStudent.DepartmentId = request.DepartmentId;

            // 3. Save changes
            _studentDbContext.SaveChanges();

            return Ok($"Student with ID {request.Id} updated successfully.");
        }

        [HttpPost] //1- Accepts JSON with name & departmentId. 2- Converts it into a Student entity. 3-Saves it to the database
        public IActionResult CreateStudent(CreateStudentDTO request)
        {
            Student student = new Student();
            student.Name = request.Name;
            student.DepartmentId = request.DepartmentId;

            _studentDbContext.Students.Add(student);
            _studentDbContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetStudentById(int id)  //Loads student with department using .Include(). + Converts to DTO and returns it.
        {
            Student student = _studentDbContext.Students.Include(s => s.Department).FirstOrDefault(std => std.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                GetStudentByIdDTO returnedStudent = new GetStudentByIdDTO();
                returnedStudent.Id = student.Id;
                returnedStudent.Name = student.Name;
                returnedStudent.DepartmentId = student.DepartmentId;
                returnedStudent.DepartmentName = student.Department.Name;
                return Ok(returnedStudent);
            }
        }

        [HttpGet]  //Returns all students, with department info. + Uses projection to convert to GetAllStudentsDTO.
        public IActionResult GetAllStudents()
        {
            var students = _studentDbContext.Students
                .Include(s => s.Department)
                .Select(s => new GetStudentByIdDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    DepartmentId = s.DepartmentId,
                    DepartmentName = s.Department.Name
                })
                .ToList();

            return Ok(students);
        }




    }
}