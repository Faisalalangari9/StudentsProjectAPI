﻿namespace StudentsProjectAPI.Models.DTO
{

    public class GetAllStudentsDTO  //Returning a list of all students with their department names.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }


}