using ImageMagick;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Restaurants.Users.Api.Helpers
{
    /// <summary>
    /// This helper demonstrates the basic usage of ImageMagick, a powerful Image manipulation library
    /// which works well on Windows and Linux.
    /// For more information, see https://github.com/dlemstra/Magick.NET
    /// </summary>
    public static class ImageHelper
    {
        private static int MAX_RESIZED_WIDTH => 512;

        public static string OrientCropAndSaveUploadedImage(IFormFile file, string directory)
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

                using (var image = new MagickImage(file.OpenReadStream()))
                {
                    image.AutoOrient();

                    int sideLength = image.Width < image.Height ? image.Width : image.Height;
                    image.Crop(sideLength, sideLength, Gravity.Center);

                    if (sideLength > MAX_RESIZED_WIDTH)
                    {
                        image.Resize(MAX_RESIZED_WIDTH, 0);
                    }

                    image.Write(directory + fileName);
                }

                return fileName;
            }
            catch
            {
                return null;
            }
        }

        public static string OrientCropAndSaveImage(string imageSource, string targetDirectory)
        {
            try
            {
                if (string.IsNullOrEmpty(imageSource) || !File.Exists(imageSource))
                {
                    return null;
                }

                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                var fileExtension = Path.GetExtension(imageSource).ToLower();
                var fileName = Path.ChangeExtension(Path.GetRandomFileName(), fileExtension);
                while (File.Exists(targetDirectory + fileName))
                {
                    fileName = Path.ChangeExtension(Path.GetRandomFileName(), fileExtension);
                }

                using (var image = new MagickImage(imageSource))
                {
                    image.AutoOrient();

                    int sideLength = image.Width < image.Height ? image.Width : image.Height;
                    image.Crop(sideLength, sideLength, Gravity.Center);

                    if (sideLength > MAX_RESIZED_WIDTH)
                    {
                        image.Resize(MAX_RESIZED_WIDTH, 0);
                    }

                    image.Write(targetDirectory + fileName);
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
