using DVD_Rental_Application.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DVD_Rental_Application.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        internal User GetUserById(int UserNumber)
        {
            var appUser = _context.users.Find(UserNumber);
            return appUser;
        }

        internal bool TryValidateUser (string username, string password, out List<Claim> claims)
        {
            claims = new List<Claim>();
            var appUser = _context.users
                .Where(a => a.UserName == username)
                .Where(a => a.Password == password).FirstOrDefault();
            if (appUser is null)
            {
                return false;
            }
            else
            {
                claims.Add(new Claim("UserNumber", appUser.UserNumber.ToString()));
                claims.Add(new Claim("userName", appUser.UserName));
                claims.Add(new Claim("Password", appUser.Password));
            }
            return true;
        }
    }
}
