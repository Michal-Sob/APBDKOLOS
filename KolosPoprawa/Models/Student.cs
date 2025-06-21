using System.ComponentModel.DataAnnotations;

namespace KolosPoprawa.Models;

public class Student
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    [MaxLength(250)]
    public string Email { get; set; }
    
    public ICollection<Record> Records { get; set; }
}