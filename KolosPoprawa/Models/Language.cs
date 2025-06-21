using System.ComponentModel.DataAnnotations;

namespace KolosPoprawa.Models;

public class Language
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    
    public ICollection<Record> Records { get; set; }
}