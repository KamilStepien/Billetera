using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FullRESTAPI.Context;
using FullRESTAPI.Models.EFModels;
using FullRESTAPI.Models.Users;
using Microsoft.IdentityModel.Tokens;

namespace FullRESTAPI.Services
{
    public interface IUserService
    {
        UserModel Authenticate(string name, string password);
        UserModel Create(UserModel user, string password);
        UserModel GetById(int id);
        void Edit(UserEditModel model);

    }
    public class UserService : IUserService
    {

        private ApplicationDBContex _applicationDBContex;

        public UserService(ApplicationDBContex applicationDBContex)
        {
            _applicationDBContex = applicationDBContex;
        }



        public UserModel Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = _applicationDBContex.Users.SingleOrDefault(x => x.Email == email);


            if (user == null || user.Password != password)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, user.ID.ToString())
               }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(new byte[1941411]), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Token = tokenHandler.WriteToken(token);

            _applicationDBContex.SaveChanges();

            return new UserModel { AvatarLink = user.AvatarLink , Email = user.Email , FirstName = user.FirstName , LastName = user.LastName , Id = user.ID, Token = user.Token};
           
        }

        public UserModel Create(UserModel user, string password)
        {
            

            if (_applicationDBContex.Users.Any(x => x.Email == user.Email))
                throw new ArgumentException($"Email {user.Email} is already in app");

            EmailValidation(user.Email);
            PasswordValidation(password);
            var efUser = new EFUser { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Password = password, AvatarLink = "../../../../assets/images/Avatars/1.jpg" };
            _applicationDBContex.Users.Add(efUser);
            _applicationDBContex.SaveChanges();

            return new UserModel
            {
                Id = efUser.ID,
                AvatarLink = efUser.AvatarLink,
                Email = efUser.Email,
                FirstName = efUser.FirstName,
                LastName = efUser.LastName,
                Token = efUser.Token         
            };
        }

        public void Edit(UserEditModel model)
        {

            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.Id && x.Password == model.ActuallPassword);

            if (user == null)
            {
                throw new ArgumentException("Password is incorrect");
            }
            else
            {
                PasswordValidation(model.NewPassword);

                user.AvatarLink = model.AvatarLink;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Password = model.NewPassword;
            }

            _applicationDBContex.SaveChanges();
        }

        private ArgumentException PasswordValidation (string password)
        {
            
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
           
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required");
            if (!hasNumber.IsMatch(password))
                throw new ArgumentException("Password don't have number");
            if (!hasUpperChar.IsMatch(password))
                throw new ArgumentException("Password don't have UpperChar");
            if (!hasMinimum8Chars.IsMatch(password))
                throw new ArgumentException("Password is shorten then 8 char");
            
            return null;
        }

        public ArgumentException EmailValidation(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (!regex.IsMatch(email))
                throw new ArgumentException("Email is not valid");

            return null;
        }

        public UserModel GetById(int id)
        {
        
            var user = _applicationDBContex.Users.SingleOrDefault(x => x.ID == id);

            if (user == null)
                return null;

            return new UserModel { AvatarLink = user.AvatarLink, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, Id = user.ID };
            

            
        }
    }
}
