using CameraShop.Application.Dto;
using CameraShop.Application.UseCases.UseCaseHandlers;
using CameraShop.Application.UseCases.UserUseCases;
using CameraShop.Domain;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.UseCases;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;


namespace CameraShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulateDataController : ControllerBase
    {
        private CameraShopDbContext _context;
        private readonly IUseCaseHandler _useCaseHandler;

        public PopulateDataController(CameraShopDbContext context, IUseCaseHandler useCaseHandler)
        {
            this._context = context; 
            this._useCaseHandler = useCaseHandler;
        }

        [HttpPost]
        public IActionResult Post()
        {

            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Regular user"
                },
                new Role()
                {
                    Name = "Admin user"
                }
            };

            var listOfUseCases = new List<UseCase>();

            foreach (var item in Enum.GetValues(typeof(UseCaseEnum)))
            {
                listOfUseCases.Add(new UseCase()
                {
                    UseCaseNumber = (int)item,
                    Name = Enum.GetName(typeof(UseCaseEnum), (int)item)
                });
            }

            var users = new List<User>()
            {
                new User(){
                    UserName ="KorisnikPera",
                    Password = "bb21a26301198c657a25e72f7b0f5149",
                    Email = "korisnik.pera@gmail.com",
                    FirstName = "Pera",
                    LastName = "Korisnik",
                    Address = "Peksonova 21",
                    PhoneNumber = "+381641111111",
                    IsAccountActivated = true,
                    UniqueActivisonCode= "asd",
                    Role = roles[0]
                },
                 new User(){
                    UserName ="AdminPera",
                    Password = "bb21a26301198c657a25e72f7b0f5149",
                    Email = "admin.pera@gmail.com",
                    FirstName = "Pera",
                    LastName = "Admin",
                    Address = "Peronsonova 18",
                    PhoneNumber = "+381641111112",
                    IsAccountActivated = true,
                    UniqueActivisonCode= "asd",

                    Role = roles[1]
                }
            };

            var userUseCases = new List<UserUseCase>();

            userUseCases.Add(new UserUseCase()
            {
                User = users[0],
                UseCase = listOfUseCases.Find(x => x.UseCaseNumber == (int)UseCaseEnum.SelectStockUseCase)
            });
            userUseCases.Add(new UserUseCase()
            {
                User = users[0],
                UseCase = listOfUseCases.Find(x => x.UseCaseNumber == (int)UseCaseEnum.SelectStockPlacesUseCase)
            });
            userUseCases.Add(new UserUseCase()
            {
                User = users[0],
                UseCase = listOfUseCases.Find(x => x.UseCaseNumber == (int)UseCaseEnum.SelectAllBrandsUseCase)
            });
            userUseCases.Add(new UserUseCase()
            {
                User = users[0],
                UseCase = listOfUseCases.Find(x => x.UseCaseNumber == (int)UseCaseEnum.SelectCamerasUseCase)
            });
            userUseCases.Add(new UserUseCase()
            {
                User = users[0],
                UseCase = listOfUseCases.Find(x => x.UseCaseNumber == (int)UseCaseEnum.SelectSensorTypeUseCase)
            });
            userUseCases.Add(new UserUseCase()
            {
                User = users[0],
                UseCase = listOfUseCases.Find(x => x.UseCaseNumber == (int)UseCaseEnum.UpdateUserInfoUseCase)
            });
            userUseCases.Add(new UserUseCase()
            {
                User = users[0],
                UseCase = listOfUseCases.Find(x => x.UseCaseNumber == (int)UseCaseEnum.PutItemInCartUseCase)
            });
            userUseCases.Add(new UserUseCase()
            {
                User = users[0],
                UseCase = listOfUseCases.Find(x => x.UseCaseNumber == (int)UseCaseEnum.ViewCartUseCase)
            });
             userUseCases.Add(new UserUseCase()
            {
                User = users[0],
                UseCase = listOfUseCases.Find(x => x.UseCaseNumber == (int)UseCaseEnum.RemoveItemFromCartUseCase)
            });
             userUseCases.Add(new UserUseCase()
            {
                User = users[0],
                UseCase = listOfUseCases.Find(x => x.UseCaseNumber == (int)UseCaseEnum.PlaceOrderUseCase)
            });
             userUseCases.Add(new UserUseCase()
            {
                User = users[0],
                UseCase = listOfUseCases.Find(x => x.UseCaseNumber == (int)UseCaseEnum.CompleteOrderUseCase)
            });

            foreach (var item in listOfUseCases)
            {
                userUseCases.Add(new UserUseCase()
                {
                    User = users[1],
                    UseCase = item
                });
            }


            var brands = new List<Brand>()
            {
                new Brand()
                {
                    BrandName = "Panasonic"
                },
                new Brand()
                {
                    BrandName = "Fox"
                },
                new Brand()
                {
                    BrandName = "Canon"
                }
            };

            var sensorTypes = new List<SensorType>()
            {
                new SensorType()
                {
                     Type = "CCD"
                },
                new SensorType()
                {
                     Type = "EMCCD"
                },
                new SensorType()
                {
                     Type = "CMOS"
                }
            };

            var cameras = new List<Camera>()
            {
                new Camera()
                {
                    Name="Test 1",
                    Description="Test 1",
                    Megapixels =12.4,
                    ISO = "Test 1",
                    VideoResolution ="100x100",
                    WifiSupport=true,
                    BluetoothSupport=true,
                    LensMount=true,
                    Price=100,

                    Brand = brands[0],
                    SensorType = sensorTypes[0],

                },
                new Camera()
                {
                    Name="Test 2",
                    Description="Test 2",
                    Megapixels =12.4,
                    ISO = "Test 2",
                    VideoResolution ="100x100",
                    WifiSupport=true,
                    BluetoothSupport=true,
                     LensMount=true,
                    Price=150,

                    Brand = brands[1],
                    SensorType = sensorTypes[1],

                },
                 new Camera()
                {
                    Name="Test 3",
                    Description="Test 3",
                    Megapixels =12.4,
                    ISO = "Test 3",
                    VideoResolution ="2400x600",
                    WifiSupport=true,
                    BluetoothSupport=true,
                     LensMount=true,
                    Price=123,

                    Brand = brands[0],
                    SensorType = sensorTypes[2],

                },
                new Camera()
                {
                    Name = "Test 4",
                    Description= "Test 4",
                    Megapixels = 12.4,
                    ISO = "Test 4",
                    VideoResolution = "1280x800",
                    WifiSupport = true,
                    BluetoothSupport = true,
                     LensMount=true,
                    Price = 123,

                    Brand = brands[2],
                    SensorType = sensorTypes[2],

                }
            };

            var cameraImages = new List<CameraImage>()
            {
                new CameraImage()
                {
                    IsPrimary=true,
                    ImagePath = "/cameraOnline-123.jpg",

                    Camera = cameras[0]
                },
                new CameraImage()
                {
                    IsPrimary = false,
                    ImagePath = "/cameraOnline1234.jpg",

                    Camera = cameras[0]
                }
            };

            var stockPlaces = new List<StockPlace>()
            {
                new StockPlace()
                {
                    Name = "London",
                    Longitude = 51.509865M,
                    latitude = -0.118092M,
                },
                new StockPlace()
                {
                    Name = "Belgrade",
                    Longitude = 44.787197M,
                    latitude = 20.457273M,
                }
            };

            var stocks = new List<Stock>()
            {
                new Stock()
                {
                     Quantity = 100,

                     Camera = cameras[0],
                     StockPlace = stockPlaces[0]
                },
                new Stock()
                {
                     Quantity = 30,

                     Camera = cameras[0],
                     StockPlace = stockPlaces[1]
                },
                new Stock()
                {
                     Quantity = 130,

                     Camera = cameras[1],
                     StockPlace = stockPlaces[0]
                },
            };

            var discounts = new List<Discount>()
            {
                new Discount()
                {
                     DiscountPercentage = 5,
                     StartDate = System.DateTime.UtcNow,
                     EndDate = System.DateTime.UtcNow.AddMonths(2),
                     Camera = cameras[0],
                },
                new Discount()
                {
                     DiscountPercentage = 5,
                     StartDate = System.DateTime.UtcNow,
                     EndDate = System.DateTime.UtcNow.AddMonths(2),
                     Camera = cameras[2],
                },
            };


            _context.Roles.AddRange(roles);
            _context.UseCases.AddRange(listOfUseCases);
            _context.Users.AddRange(users);
            _context.UserUseCases.AddRange(userUseCases);
            _context.Brands.AddRange(brands);
            _context.SensorTypes.AddRange(sensorTypes);
            _context.Cameras.AddRange(cameras);
            _context.CameraImages.AddRange(cameraImages);
            _context.StockPlaces.AddRange(stockPlaces);
            _context.Stocks.AddRange(stocks);
            _context.Discounts.AddRange(discounts);


            this._context.SaveChanges();

            return StatusCode(201);
        }

        //[HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //public IActionResult PopulateUseCases([FromQuery] EmptyDto action, [FromServices] IAddUseCasesToApplication command)
        //{
        //    this._useCaseHandler.HandleCommand(command, action);
        //    return NoContent();
        //}
    }
}
