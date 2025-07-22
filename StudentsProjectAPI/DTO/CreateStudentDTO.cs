namespace StudentsProjectAPI.Models.DTO
{
    public class CreateStudentDTO  //User sends POST to create a new student.
    {
        public string? Name { get; set; } //create name for student 
        public int DepartmentId { get; set; } //Create his department id
    }
}