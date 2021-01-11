using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Restaurants.Users.Api.Models.EntityModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Restaurants.Users.Api.Helpers
{
    public static class AvatarHelper
    {
        public static async Task<string> UploadAvatar(
            IFormFile file, AppUserModel userModel, AppDbContext dbContext, IConfiguration config
        )
        {
            // Do some basic validation based on file extension
            var extension = Path.GetExtension(file.FileName).ToLower();
            if (extension != ".png" && extension != ".jpg" && extension != ".jpeg")
            {
                throw new Exception($"{extension} is not a supported image format.");
            }

            var fileDir = config["MediaBaseDir"] + "avatar" + Path.DirectorySeparatorChar;
            var fileName = ImageHelper.OrientCropAndSaveUploadedImage(file, fileDir);
            if (fileName == null)
            {
                throw new Exception("Image upload failed.");
            }

            // We must replace the current avatar file if it already exists
            if (userModel.AvatarFile != null)
            {
                File.Delete(config["MediaBaseDir"] + userModel.AvatarFile.FilePath);
                dbContext.Files.Remove(userModel.AvatarFile);
            }

            userModel.AvatarFile = new FileModel
            {
                Id = Guid.NewGuid().ToString(),
                FileExtension = extension,
                FileName = fileName,
                OriginalFileName = file.FileName,
                FilePath = "avatar" + Path.DirectorySeparatorChar + fileName,
                MimeType = file.ContentType,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = userModel
            };

            dbContext.Users.Update(userModel);
            await dbContext.SaveChangesAsync();

            return userModel.AvatarFileId;
        }
    }
}
