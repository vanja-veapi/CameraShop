using CameraShop.API.Core.UserTypes;
using CameraShop.API.DTO;
using CameraShop.Application.Core;
using CameraShop.Domain;
using CameraShop.EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CameraShop.API.JWT
{
    public class JwtManager
    {
        private readonly CameraShopDbContext _context;
        private readonly string _issuer;
        private readonly int _seconds;
        private readonly ITokenStorage _storage;
        private readonly string _secretKey;
        private readonly IStringEncryptor _stringEncryptor;

        public JwtManager(CameraShopDbContext context, ITokenStorage storage, AppSettings appSetting, IStringEncryptor stringEncryptor)
        {
            _context = context;
            _storage = storage;
            _issuer = appSetting.Jwt.Issuer;
            _secretKey = appSetting.Jwt.SecretKey;
            _seconds = appSetting.Jwt.DurationSeconds;
            _stringEncryptor = stringEncryptor;
        }

        public string MakeToken(string mixCredential, string password)
        {

            var encryptedPassword = this._stringEncryptor.EncryptString(password);

            var user = _context.Users.Where(x => (x.Email == mixCredential || x.UserName == mixCredential) && x.Password == encryptedPassword).Select(x => new JwtUser()
            {
                UseCaseIds = x.UserUseCases.Select(y => y.UseCase.UseCaseNumber).ToList(),
                Identity = x.FirstName + " " + x.LastName,
                Id = x.Id,
                Email = x.Email,
                Username = x.UserName,
                IsAccountActivated= x.IsAccountActivated
            }).FirstOrDefault();

            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found with the given credentials");
            }
            else if (!user.IsAccountActivated)
            {
                throw new UnauthorizedAccessException("Your account is not activated");
            }

            var tokenId = Guid.NewGuid().ToString();

            _storage.AddToken(tokenId);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, tokenId, ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iss, _issuer, ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _issuer),
                new Claim("Id", user.Id.ToString()),
                new Claim("Username", user.Username),
                new Claim("Identity", user.Identity),
                new Claim("Email", user.Email),
                new Claim("UseCases", JsonConvert.SerializeObject(user.UseCaseIds))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(_seconds),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
