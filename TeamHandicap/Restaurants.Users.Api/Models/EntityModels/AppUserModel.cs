using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurants.Users.Api.Models.EntityModels
{
    /// <summary>
    /// Extend the IdentityUser class with profile fields pertaining to all App users.
    /// </summary>
    public class AppUserModel : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string AvatarFileId { get; set; }
        [ForeignKey(nameof(AvatarFileId))]
        public FileModel AvatarFile { get; set; }

        [InverseProperty(nameof(UserFavouriteModel.User))]
        public ICollection<UserFavouriteModel> Favourites { get; set; }

        // This property must be added to avoid one-to-one binding between this.AvatarFile and FileModel.CreatedBy
        [InverseProperty(nameof(FileModel.CreatedBy))]
        public ICollection<FileModel> FilesCreated { get; set; }

        /******************************************************************************************
         * Reset Password Management
         ******************************************************************************************/

        public string ResetPwdToken { get; set; } // The password reset token.
        public short ResetPwdSentCount { get; set; } // Can be used to keep track of how many times a reset password has been emailed or SMS'ed.
        public DateTime ResetPwdExpDate { get; set; } // The time after which the token should be considered invalid.

        /******************************************************************************************
         * Audit tracking
         ******************************************************************************************/

        public DateTime LastLoggedInAt { get; set; }
    }
}
