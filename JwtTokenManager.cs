﻿using ExchangeWebApi.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System;

namespace ExchangeWebApi
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IConfiguration _configuration;
        ExchangeOfficeContext context = new ExchangeOfficeContext();
        public JwtTokenManager(IConfiguration configuration)
        {
            _configuration = configuration; 
        }
        public string Authenticate(string userName, string password)
        {
            if(!context.Accounts.Any(x => x.UserName.Equals(userName)&& x.Password.Equals(password)))
            {
                return null;
            }
            var key = _configuration.GetValue<string>("JwtConfig:Key");
            var keyBytes = Encoding.ASCII.GetBytes(key);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
