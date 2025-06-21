namespace KolosPoprawa.Models.Dtos;

public class CreateRecordDto
{
    public int LanguageId { get; set; }
    public int StudentId { get; set; }
    public TaskDto Task { get; set; }
    public float ExecutionTime { get; set; }
    public DateTime Created { get; set; }
}