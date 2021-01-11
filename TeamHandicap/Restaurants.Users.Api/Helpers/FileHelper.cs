using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Restaurants.Users.Api.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// This method moves an in-memory IFormFile instance to persistent storage.
        /// </summary>
        /// <param name="file">An in-memory IFormFile instance.</param>
        /// <param name="directory">The target directory on persistent storage.</param>
        /// <returns>The unique file name under which the file was stored.</returns>
        public static async Task<string> MoveUploadedFileAsync(IFormFile file, string directory)
        {
            try
            {
                if (file == null || file.Length <= 0)
                {
                    return null;
                }

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var fileExtension = Path.GetExtension(file.FileName).ToLower();
                var fileName = Path.ChangeExtension(Path.GetRandomFileName(), fileExtension);
                while (File.Exists(directory + fileName))
                {
                    fileName = Path.ChangeExtension(Path.GetRandomFileName(), fileExtension);
                }

                using (var stream = new FileStream(directory + fileName, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return fileName;
            }
            catch
            {
                return null;
            }
        }
    }
}
