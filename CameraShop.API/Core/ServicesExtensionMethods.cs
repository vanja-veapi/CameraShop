using CameraShop.API.Core.UserTypes;
using CameraShop.API.DTO;
using CameraShop.API.JWT;
using CameraShop.Application.Core;
using CameraShop.Application.UseCases.BrandUseCases;
using CameraShop.Application.UseCases.CameraUseCases;
using CameraShop.Application.UseCases.CartUseCases;
using CameraShop.Application.UseCases.SensorTypeUseCases;
using CameraShop.Application.UseCases.StocksUseCases;
using CameraShop.Application.UseCases.UserUseCases;
using CameraShop.Implementation.UseCases.Commands.Brands;
using CameraShop.Implementation.UseCases.Commands.Cameras;
using CameraShop.Implementation.UseCases.Commands.Carts;
using CameraShop.Implementation.UseCases.Commands.SensorTypes;
using CameraShop.Implementation.UseCases.Commands.Stocks;
using CameraShop.Implementation.UseCases.Commands.Users;
using CameraShop.Implementation.UseCases.Queries.Brands;
using CameraShop.Implementation.UseCases.Queries.Cameras;
using CameraShop.Implementation.UseCases.Queries.Carts;
using CameraShop.Implementation.UseCases.Queries.SensorTypes;
using CameraShop.Implementation.UseCases.Queries.Stocks;
using CameraShop.Implementation.UseCases.Queries.User;
using CameraShop.Implementation.Validators;
using CameraShop.Implementation.Validators.Brand;
using CameraShop.Implementation.Validators.Camera;
using CameraShop.Implementation.Validators.Cart;
using CameraShop.Implementation.Validators.SensorType;
using CameraShop.Implementation.Validators.Stock;
using CameraShop.Implementation.Validators.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.API.Core
{
    public static class ServicesExtensionMethods
    {
        public static void AddJwt(this IServiceCollection services,AppSettings settings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.Jwt.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                cfg.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var header = context.Request.Headers["Authorization"];
                        var token = header.ToString().Split("Bearer ")[1];
                        var handler = new JwtSecurityTokenHandler();
                        var tokenObj = handler.ReadJwtToken(token);
                        string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;

                        ITokenStorage storage = context.HttpContext.RequestServices.GetService<ITokenStorage>();

                        bool isValid = storage.TokenExists(jti);

                        if (!isValid)
                        {
                            context.Fail("Token is not valid.");
                        }

                        return Task.CompletedTask;
                    }
                };
            });
        }
    
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CameraShop", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    },
                    new string[] {}
                    }
                });
            });
        }

        public static void AddAppActor(this IServiceCollection services)
        {
            //Za testiranje se moze koristiti ovaj korisnik
            //services.AddTransient<IApplicationUser, DummyActor>();

            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("Id") == null)
                {
                    return new AnonimousUser();
                }

                return new JwtUser()
                {
                    Id = Int32.Parse(claims.FindFirst("Id").Value),
                    Email = claims.FindFirst("Email").Value,
                    Username = claims.FindFirst("Username").Value,
                    Identity = claims.FindFirst("Identity").Value,
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };
            });
        }

        public static void AddQueryUseCases(this IServiceCollection services)
        {
            services.AddTransient<ISelectStocks, SelectStocks>();
            services.AddTransient<ISelectStockPlaces, SelectStockPlaces>();
            services.AddTransient<ISelectAllBrands, SelectAllBrands>();
            services.AddTransient<ISelectCameras, SelectCameras>();
            services.AddTransient<ISelectAllSensorType, SelectAllSensorType>();
            services.AddTransient<ISelectUseCases, SelectUseCases>();
            services.AddTransient<IUserSelection, UserSelection>();
            services.AddTransient<IViewCart, ViewCart>();
        }
        public static void AddCommandUseCases(this IServiceCollection services)
        {
            services.AddTransient<IUpdateCameraBrand, UpdateCameraBrand>();
            services.AddTransient<IRemoveBrand, RemoveBrand>();
            services.AddTransient<INewCameraBrand, NewCameraBrand>();
            services.AddTransient<INewCamera, NewCamera>();
            services.AddTransient<IAddCameraDiscount, AddCameraDiscount>();
            services.AddTransient<IRemoveCamera, RemoveCamera>();
            services.AddTransient<IRemoveCameraDiscount, RemoveCameraDiscount>();
            services.AddTransient<IUpdateCamera, UpdateCamera>();
            services.AddTransient<INewSensorType, NewSensorType>();
            services.AddTransient<IRemoveSensorType, RemoveSensorType>();
            services.AddTransient<IUpdateSensorType, UpdateSensorType>();
            services.AddTransient<INewStockPlace, NewStockPlace>();
            services.AddTransient<IPlaceStocks, PlaceStock>();
            services.AddTransient<IRemoveStock, RemoveStock>();
            services.AddTransient<IRemoveStockPlace, RemoveStockPlace>();
            services.AddTransient<IUpdateStockPlace, UpdateStockPlace>();
            services.AddTransient<IActivateUserAccount, ActivateUserAccount>();
            services.AddTransient<ICreateNewUser, CreateNewUser>();
            services.AddTransient<IMenageUserPriviledges, MenageUserPriviledges>();
            services.AddTransient<IUpdateUserInfo, UpdateUserInfo>();
            services.AddTransient<IPutItemInCart, PutItemInCart>();
            services.AddTransient<IRemoveitemFromCart, RemoveitemFromCart>();
            services.AddTransient<IPlaceOrder, PlaceOrder>();
            services.AddTransient<ICompleteOrder, CompleteOrder>();
            services.AddTransient<IAddUseCasesToApplication, AddUseCasesToApplication>();

            
        }
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<NewCameraBrandValidator>();
            services.AddTransient<RemoveBrandValidator>();
            services.AddTransient<UpdateCameraBrandValidator>();
            services.AddTransient<NewCameraValidator>();
            services.AddTransient<ImageValidator>();
            services.AddTransient<AddCameraDiscountValidator>();
            services.AddTransient<RemoveCameraDiscountValidator>();
            services.AddTransient<RemoveCameraValidator>();
            services.AddTransient<UpdateCameraValidator>();
            services.AddTransient<NewSensorTypeValidator>();
            services.AddTransient<RemoveSensorTypeValidator>();
            services.AddTransient<UpdateSensorTypeValidator>();
            services.AddTransient<NewStockPlaceValidator>();
            services.AddTransient<InStockMiniValidator>();
            services.AddTransient<PlaceStockValidator>();
            services.AddTransient<RemoveStockPlaceValidator>();
            services.AddTransient<RemoveStockValidator>();
            services.AddTransient<UpdateStockPlaceValidator>();
            services.AddTransient<ActivateUserAccountValidator>();
            services.AddTransient<CreateNewUserValidator>();
            services.AddTransient<MenageUserPriviledgesValidator>();
            services.AddTransient<UpdateUserInfoValidator>();
            services.AddTransient<PutItemInCartValidator>();
            services.AddTransient<RemoveItemFromCartValidator>();
            services.AddTransient<PlaceOrderValidator>();
            services.AddTransient<CompleteOrderValidator>();
        }
    }
}
