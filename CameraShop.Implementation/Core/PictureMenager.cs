using CameraShop.Application.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Core
{
    public class PictureMenager : IPictureMenager
    {
        public string movePicture(IFormFile picture)
        {
            var time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            var exstension = Path.GetExtension(picture.FileName);
            var newName = time + exstension;
            var path = Path.Combine("wwwroot", "Images", newName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                picture.CopyTo(stream);
            }
            return newName;
        }
        public void destroyPicture(string pathPic)
        {
            var putanja = Path.Combine("wwwroot", "Images", pathPic);
            File.Delete(putanja);
        }
    }
}
