using Microsoft.EntityFrameworkCore;
using Model.Data;
using Model.Models;
using Service.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly SapContext _context;

        public RoleService(SapContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> Get()
        {
            return await _context.Roles.OrderBy(e => e.IdRole).ToListAsync();
        }

        public async Task<Role?> GetByKeys(params object[] keys)
        {
            return await _context.Roles.FindAsync(keys);
        }
    }
}
