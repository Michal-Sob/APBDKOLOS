namespace KolosPoprawa.Models.Dtos;

public class RecordsListDto
{
  public int Id { get; set; }
  public string LanguageName { get; set; }
  public string TaskName { get; set; }
  public string StudentFirstName { get; set; }
  public string StudentLastName { get; set; }
  public float ExecutionTime { get; set; }
  public DateTime CreatedAt { get; set; }
}
/*
 * [
  {
    "id": 1,
    "language": {
      "id": 1,
      "name": "C#"
    },
    "task": {
      "id": 1,
      "name": "Fizz-Buzz",
      "description": "Test description"
    },
    "student": {
      "id": 1,
      "firstName": "Adam",
      "lastName": "Miller",
      "email": "adam.miller@mail.com"
    },
    "executionTime": 1233,
    "created": "05/29/2015 05:50:06"
  }
]
 */