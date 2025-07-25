﻿namespace StudentsProjectAPI.Models.DTO
{
    public class GetStudentByIdDTO //Returning full details of one student and their department.
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}