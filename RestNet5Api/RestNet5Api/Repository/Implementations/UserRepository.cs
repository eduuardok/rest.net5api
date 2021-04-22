using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using RestNet5Api.Data.VO;
using RestNet5Api.Model;
using RestNet5Api.Model.Context;

namespace RestNet5Api.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());

            return _context.Users.FirstOrDefault(u => u.UserName == user.UserName && (u.Password.Equals(pass)));
        }

        private object ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public User RefreshUserInfo(User entity)
        {
            if(!_context.Users.Any(e => e.Id == entity.Id))
                return null;

            var result = _context.Users.SingleOrDefault(e => e.Id == entity.Id);

            if(result != null){
                try {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                    return entity;
                } catch(Exception ex) {
                    throw ex;
                }
            }
            return result;
        }
    }
}