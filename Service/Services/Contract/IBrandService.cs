using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Contract
{
    public interface IBrandService
    {
        public Task<IEnumerable<Brand>> Get();
        public Task<Brand?> GetByKeys(object[] keys);
        public Task<Brand?> GetByName(string name);
        public Task<bool> Create(Brand category);
        public Task<bool> Update(Brand category);
        public Task<bool> Delete(int id);
    }
}
