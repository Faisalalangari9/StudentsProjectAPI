namespace StudentsProjectAPI.Models
{
    public class Department
    {
        public int Id { get; set; }  //Primary key in database 
        public string Name { get; set; } //Department name ex COS , ISY


        //  Navigation property (One-to-Many)
        public ICollection<Student> Students { get; set; }  //list of all students in this department 
    }
}