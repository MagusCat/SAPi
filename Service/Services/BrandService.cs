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
    public class BrandService : IBrandService
    {
        private readonly SapContext _context;

        public BrandService(SapContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Brand>> Get()
        {
            return await _context.Brands.OrderBy(e => e.IdBrand).ToListAsync();
        }

        public async Task<Brand?> GetByKeys(params object[] keys)
        {
            return await _context.Brands.FindAsync(keys);
        }

        public async Task<Brand?> GetByName(string name)
        {
            return await _context.Brands.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<bool> Create(Brand brand)
        {
            var bra = await GetByName(brand.Name);

            if (bra is not null) return false;

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var bra = await GetByKeys(id);

            if (bra is null) return false;

            _context.Brands.Remove(bra);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(Brand brand)
        {
            var bra = await GetByKeys(brand.IdBrand);

            if (bra is null) return false;

            bra.Name = brand.Name;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
