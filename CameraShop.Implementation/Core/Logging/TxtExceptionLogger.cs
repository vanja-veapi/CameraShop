using CameraShop.Application.Core;
using CameraShop.Application.Core.Logging;
using CameraShop.Application.UseCases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Core.Logging
{
    public class TxtExceptionLogger : IExceptionLogger
    {
        private IApplicationUser _actor;
        public TxtExceptionLogger(IApplicationUser actor)
        {
            this._actor = actor;
        }

        public void ExceptionLog(Exception ex, IUseCase useCase, object objInput)
        {
            string fileName = DateTime.Now.ToString("d-M-yyyy") + "_ExceptinoLogs.txt";
            var putanja = Path.Combine("wwwroot", "Logs", fileName);

            var textUpis = $"{ex.Message}|||{DateTime.Now}|||{_actor.Identity}|||{useCase.Name}|||{useCase.Id}|||{JsonConvert.SerializeObject(objInput)}";

            if (!File.Exists(putanja))
            {
                using (StreamWriter sw = File.CreateText(putanja))
                {
                    sw.WriteLine(textUpis);
                }
            }
            else
            {
                using(StreamWriter sw = File.AppendText(putanja))
                {
                    sw.WriteLine(textUpis);
                }
            }

            //var putanja = Path.Combine("wwwroot", "Logs", fileName);
            //using var fs = File.AppendText(putanja);
            //fs.WriteLine(textUpis);
        }
    }
}
