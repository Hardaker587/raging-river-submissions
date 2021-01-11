using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurants.Users.Api.Helpers;
using Restaurants.Users.Api.Models.EntityModels;

namespace Restaurants.Users.Api.Controllers
{
    [ApiController, Authorize, Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _appConfig;

        public FilesController(AppDbContext appDbContext, IConfiguration appConfig)
        {
            _appDbContext = appDbContext;
            _appConfig = appConfig;
        }

        [HttpPost("")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var user = await AuthHelper.GetCurrentUserAsync(_appDbContext, HttpContext);
            if (user == null)
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "Unknown user account - Invalid JWT.", ModelState));
            }

            var extension = Path.GetExtension(file.FileName).ToLower();
            var fileDir = _appConfig["MediaBaseDir"] + "files" + Path.DirectorySeparatorChar;
            var fileName = await FileHelper.MoveUploadedFileAsync(file, fileDir);
            if (fileName == null)
            {
                return BadRequest(ErrorHelper.AddErrorToModelState("err", "File upload failed.", ModelState));
            }

            var newFile = new FileModel
            {
                Id = Guid.NewGuid().ToString(),
                FileExtension = extension,
                FileName = fileName,
                OriginalFileName = file.FileName,
                FilePath = "files" + Path.DirectorySeparatorChar + fileName,
                MimeType = file.ContentType,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = user
            };

            _appDbContext.Files.Add(newFile);
            await _appDbContext.SaveChangesAsync();

            return Ok(new { FileId = newFile.Id });
        }

        [HttpGet("{fileId}")]
        public async Task<IActionResult> GetFile(string fileId)
        {
            var file = await _appDbContext.Files.SingleOrDefaultAsync(f => f.Id == fileId);
            if (file == null)
            {
                return NotFound();
            }

            var fileStream = System.IO.File.OpenRead(_appConfig["MediaBaseDir"] + file.FilePath);

            return File(fileStream, file.MimeType);
        }
    }
}