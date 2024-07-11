using CarteAPI.Data;
using CarteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace CarteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _environment;

        public FileUploadController(DataContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { error = "No file uploaded or file is empty." });
            }

            var uploadsFolderPath = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var filePath = Path.Combine(uploadsFolderPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();

                var fileModel = new ReferenceFile
                {
                    FileName = file.FileName,
                    FilePath = filePath,
                    FileData = fileBytes
                };

                _context.ReferenceFiles.Add(fileModel);
                await _context.SaveChangesAsync();

                return Ok(new { FileName = file.FileName, FileSize = file.Length, FilePath = filePath });
            }
        }

        [HttpGet("references")]
        public async Task<IActionResult> GetReferences()
        {
            var references = await _context.ReferenceFiles.Select(r => r.FileName).ToListAsync();
            return Ok(references);
        }
    }
}
