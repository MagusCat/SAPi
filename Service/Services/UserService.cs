using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Models;
using Service.Services.Contract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly SapContext _context;
        private readonly IEncryptionService _encryption;

        public UserService(SapContext context, IEncryptionService encryption)
        {
            _context = context;
            _encryption = encryption;
        }

        public async Task<IEnumerable<User>> Filter(int? id_user, int? id_rol, string? user)
        {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            var arguments = new SqlParameter[]
            {
                new SqlParameter("@id_user", SqlDbType.Int) { Value = (object) id_user ?? DBNull.Value},
                new SqlParameter("@id_rol", SqlDbType.Int) { Value = (object) id_rol ?? DBNull.Value},
                new SqlParameter("@username", SqlDbType.Int) { Value = (object) user ?? DBNull.Value}
            };

            return await _context.Users.FromSqlRaw("EXEC Filter_User @id_user, @id_rol, @username", arguments).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.OrderBy(e => e.IdUser).ToListAsync();
        }

        public async Task<User?> GetByKeys(params object[] keys)
        {
            return await _context.Users.FindAsync(keys);
        }

        public async Task<User?> Authenticate(string username, string password) 
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Username == username);

            if (user == null)
            {
                return null;
            }

            if (_encryption.Decrypt(user.Password) == password) 
            {
                return user;
            }

            return null;
        }
    }
}
