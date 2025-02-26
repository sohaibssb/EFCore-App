using EF_Test.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;  
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; }
    public int Grade { get; set; }
    public DateTime Birthdate { get; set; }
    public Grade? grade { get; set; }

    [ForeignKey("department")]
    public int departmentId { get; set; }
    public Department? department { get; set; }

    public ICollection<StudentBook> books { get; set; } = new List<StudentBook>(); 
    public ICollection<Attendance> attendances { get; set; } = new List<Attendance>();
    public ICollection<Address> addresses { get; set; } = new List<Address>();

    
    public Student()
    {
        books = new List<StudentBook>();
        attendances = new List<Attendance>();
        addresses = new List<Address>();
    }
}
