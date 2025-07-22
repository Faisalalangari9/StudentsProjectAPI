namespace StudentsProjectAPI.Models.DTO
{
    public class UpdateStudentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
    }
}