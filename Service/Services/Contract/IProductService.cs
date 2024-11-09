using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Contract
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> Filter(int? id_product, int? id_brand, int? id_category, string? name);
        public Task<IEnumerable<Product>> Get();
        public Task<Product?> GetByKeys(object[] keys);
        public Task<Product?> GetByName(string name);
        public Task<bool> Create(Product product);
        public Task<bool> Update(Product product);
        public Task<bool> Delete(int id);
    }
}
