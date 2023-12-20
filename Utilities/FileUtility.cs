using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace LoveLink.Utilities
{
    public static class FileUtility
    {
        public static string SaveProfilePhoto(IFormFile profilePhoto)
        {

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

                var fileExtension = Path.GetExtension(profilePhoto.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return null;
                }

                var fileName = Guid.NewGuid().ToString() + fileExtension;
                var filePath = Path.Combine("C:\\Users\\markb\\workspace\\foundations\\exercises\\LoveLink\\public\\LoveLinkProfilePhotos\\", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    profilePhoto.CopyTo(fileStream);
                }

                using (var memoryStream = new MemoryStream())
                {
                    profilePhoto.CopyTo(memoryStream);
                    return fileName;
                }
        }
    }
}
