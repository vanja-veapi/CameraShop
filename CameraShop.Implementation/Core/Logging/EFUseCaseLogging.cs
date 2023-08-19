using CameraShop.Application.Core.Logging;
using CameraShop.Application.Dto.Logging;
using CameraShop.Domain;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Core.Logging
{
    public class EFUseCaseLogging : EFBaseUseCase, IUseCaseLogger
    {
        public EFUseCaseLogging(CameraShopDbContext context) : base(context)
        {
        }

        public void UseCaseLog(UseCaseLogDto log)
        {
            var useCaseId = this._context.UseCases.Where(x => x.UseCaseNumber == log.UseCaseIdentifier).Select(x => x.Id).First();
            var newUseCaseLog = new UseCaseLog()
            {
                UserId = log.UserId,
                UseCaseId = useCaseId,
                Data = log.Data,
                Duration = log.DurationTime
            };

            _context.UseCaseLogs.Add(newUseCaseLog);

            _context.SaveChanges();
        }
    }
}
