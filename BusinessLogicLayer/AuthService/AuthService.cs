using BusinessLogicLayer.Models;
using DataAccessLayer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BusinessLogicLayer.AuthService
{
   public class AuthService: IAuthService
    {

        private readonly IApplicationDbContext _dbContext;
        public AuthService(IApplicationDbContext dbContext) // Здесь пройдет инициал. благодаря механизму адд скопе класса стартап
        {
            _dbContext = dbContext;
        }

        public bool UserIdentification(Login login)
        {
            var dbUser = _dbContext.Users.Select(u => new {u.NickName, u.Password }).FirstOrDefault(u =>  u.NickName == login.NickName && u.Password == login.Password);

            if (dbUser != null )
            {
                return true;
            }
            
            return false;
        }

        public string GetToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyHIUYM@12345678"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }

        public void AddUser(CheckIn checkIn)
        {
            var tempUser = new DataAccessLayer.Entities.User { FirstName = checkIn.FirstName, LastName = checkIn.LastName, NickName = checkIn.NickName, Password = checkIn.Password };
            if (tempUser != null)
            {
                _dbContext.Users.Add(tempUser);
                _dbContext.SaveChanges();
            }

        }
    }
}
