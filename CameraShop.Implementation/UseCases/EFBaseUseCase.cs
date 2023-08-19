using CameraShop.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases
{
    public abstract class EFBaseUseCase
    {
        protected CameraShopDbContext _context { get; }
        public EFBaseUseCase(CameraShopDbContext context)
        {
            _context = context;
        }
    }
}
