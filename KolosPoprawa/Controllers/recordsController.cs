using KolosPoprawa.Models;
using KolosPoprawa.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KolosPoprawa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class recordsController : ControllerBase
    {
        private readonly ApiContext _context;

        public recordsController(ApiContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecordsListDto>>> GetRecords(
            DateTime? createdAt = null, 
            int? languageId = null, 
            int? taskId = null)
        {
            var query = _context.Records
                .Include(r => r.Language)
                .Include(r => r.Task)
                .Include(r => r.Student)
                .AsQueryable();
                
            if (createdAt.HasValue)
                query = query.Where(r => r.CreatedAt.Date == createdAt.Value.Date);
            if (languageId.HasValue)
                query = query.Where(r => r.LanguageId == languageId.Value);
            if (taskId.HasValue)
                query = query.Where(r => r.TaskId == taskId.Value);
                
            var records = await query
                .OrderByDescending(r => r.CreatedAt)
                .ThenBy(r => r.Student.LastName)
                .Select(r => new RecordsListDto
                {
                    Id = r.Id,
                    LanguageName = r.Language.Name,
                    TaskName = r.Task.Name,
                    StudentFirstName = r.Student.FirstName,
                    StudentLastName = r.Student.LastName,
                    ExecutionTime = r.ExecutionTime,
                    CreatedAt = r.CreatedAt
                })
                .ToListAsync();
                
            return Ok(records);
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateRecord(CreateRecordDto dto)
        {
            var student = await _context.Students.FindAsync(dto.StudentId);
            var language = await _context.Languages.FindAsync(dto.LanguageId);
            int taskId;

            if (dto.ExecutionTime <= 0)
                return BadRequest();
            if (language == null || student == null)
                return NotFound();
                
            if (dto.Task.Id.HasValue && dto.Task.Id.Value > 0)
            {
                var existingTask = await _context.Tasks.FindAsync(dto.Task.Id.Value);
                if (existingTask == null)
                    return NotFound();
                taskId = dto.Task.Id.Value;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(dto.Task.Name) || string.IsNullOrWhiteSpace(dto.Task.Description))
                    return BadRequest();
                    
                var newTask = new Models.Task
                {
                    Name = dto.Task.Name,
                    Description = dto.Task.Description
                };
                
                _context.Tasks.Add(newTask);
                await _context.SaveChangesAsync();
                taskId = newTask.Id;
            }
            
            var record = new Record
            {
                LanguageId = dto.LanguageId,
                TaskId = taskId,
                StudentId = dto.StudentId,
                ExecutionTime = dto.ExecutionTime,
                CreatedAt = dto.Created
            };
            
            _context.Records.Add(record);
            await _context.SaveChangesAsync();
            
            return StatusCode(201);
        }
    }
}