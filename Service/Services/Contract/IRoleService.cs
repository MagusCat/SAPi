using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Contract
{
    public interface IRoleService
    {
        public Task<IEnumerable<Role>> Get();

        public Task<Role?> GetByKeys(object[] keys);
    }
}
