namespace StudentsProjectAPI.Models
{
    public class Student
    {
        public int Id { get; set; }  //Student's unique ID.
        public string? Name { get; set; } // Nullable name of student.

        public int DepartmentId { get; set; } //Foreign KEy
        public Department Department { get; set; } //  Navigation to the Department
    }
}