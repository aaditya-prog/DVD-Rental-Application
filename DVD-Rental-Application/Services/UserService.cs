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

        internal User GetUserById(int id)
        {
            var appUser = _context.users.Find(id);
            return appUser;
        }

        internal bool TryValidateUser(string name, string type, out List<Claim> claims)
        {
            claims = new List<Claim>();
            var appUser = _context.users
                .Where(a => a.UserName == name)
                .Where(a => a.UserType == type).FirstOrDefault();
            if (appUser is null)
            {
                return false;
            }
            else
            {
                claims.Add(new Claim("id", appUser.UserNumber.ToString()));
                claims.Add(new Claim("name", appUser.UserName));
                claims.Add(new Claim("usertype", appUser.UserType));
                claims.Add(new Claim("password", appUser.Password));
            }
            return true;
        }
    }
}
