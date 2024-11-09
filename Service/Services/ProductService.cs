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

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly SapContext _context;
        public ProductService(SapContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Filter(int? id_product, int? id_brand, int? id_category, string? name)
        {
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            var arguments = new SqlParameter[]
            {
                new SqlParameter("@id_product", SqlDbType.Int) { Value = (object)id_product ?? DBNull.Value},
                new SqlParameter("@id_brand", SqlDbType.Int) { Value = (object)id_brand ?? DBNull.Value},
                new SqlParameter("@id_category", SqlDbType.Int) { Value = (object)id_category ?? DBNull.Value},
                new SqlParameter("@name", SqlDbType.NVarChar) { Value = (object)name ?? DBNull.Value}
            };

            return await _context.Products
                .FromSqlRaw("EXEC Filter_Product @id_product, @id_brand, @id_category, @name", arguments)
                .ToListAsync();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.OrderBy(e => e.IdProduct).ToListAsync();
        }

        public async Task<Product?> GetByKeys(params object[] keys)
        {
            return await _context.Products.FindAsync(keys);
        }

        public async Task<Product?> GetByName(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<bool> Create(Product product)
        {
            var pro = await GetByName(product.Name);

            if (pro is not null) return false;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var pro = await GetByKeys(id);

            if (pro is null) return false;

            _context.Products.Remove(pro);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(Product product)
        {
            var pro = await GetByKeys(product.IdProduct);

            if (pro is null) return false;

            pro.Name = product.Name;
            pro.Price = product.Price;
            pro.IdCategory = product.IdCategory;
            pro.IdBrand = product.IdBrand;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
