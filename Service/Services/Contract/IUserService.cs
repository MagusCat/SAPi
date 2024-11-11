using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Contract
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> Get();
        public Task<IEnumerable<User>> Filter(int? id_user, int? id_rol, string? user);
        public Task<User?> GetByKeys(object[] keys);
        public Task<User?> Authenticate(string username, string password);
        public Task<bool> SaveToken(string username, string token);
        public Task<bool> Authorize(int id, string token);
    }
}
