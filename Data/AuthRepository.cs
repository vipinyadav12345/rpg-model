using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public   async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>(); 
            var user = await _context.users
            .FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(username.ToLower()));

            if(user == null)
            {
                response.success = false;
                response.Message = "User not found. ";

            }
            else if(!VerifyPasswordHash(password , user.PasswordHash , user.PasswordSalt)) 
            {
                response.success = false;
                response.Message = "Wrong Password. ";
            }
            else
            {
                response.Data = CreateToken(user);
            }

            return response ;

        }
          public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserExists(user.UserName))
            {
                response.success = false;
                response.Message = "User already exists.";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.users.Add(user);
            await _context.SaveChangesAsync();

            response.Data = user.Id;
           
            return response;
        }

        public  async Task<bool> UserExists(string username)
        {
        if(await _context.users.AnyAsync(u => u.UserName.ToLower() ==  username.ToLower()))
        {
            return true;
        }
         return false;

        }
        private void CreatePasswordHash( string password , out byte[] passwordHash , out byte[] passwordSalt){
        using (var hmac = new System.Security.Cryptography.HMACSHA512()){
            passwordSalt = hmac.Key ;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            
        }

        }
        private bool VerifyPasswordHash(string password , byte[]passwordHash ,byte[]passwordSalt){
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return ComputeHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user){

          
            return string.Empty; //Token
        }

    }
}