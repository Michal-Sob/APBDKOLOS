namespace KolosPoprawa.Models;

public class Record
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public int TaskId { get; set; }
    public int StudentId { get; set; }
    public float ExecutionTime { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Language Language { get; set; }
    public Task Task { get; set; }
    public Student Student { get; set; }
}