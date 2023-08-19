using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Core
{
    public interface IPictureMenager
    {
        public string movePicture(IFormFile picture);
        public void destroyPicture(string pictureName);
       
    }
}
