using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurants.Users.Api.Models.EntityModels
{
    public class FileModel
    {
        [Key]
        public string Id { get; set; }

        public string FileExtension { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public string FilePath { get; set; } // Relative to appsettings.MediaBaseDir
        public string MimeType { get; set; }
        public string FileDescription { get; set; }

        public string CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public AppUserModel CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
