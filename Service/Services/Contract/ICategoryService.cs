using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Contract
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> Get();
        public Task<Category?> GetByKeys(object[] keys);
        public Task<Category?> GetByName(string name);
        public Task<bool> Create(Category category);
        public Task<bool> Update(Category category);
        public Task<bool> Delete(int id);
    }
}
