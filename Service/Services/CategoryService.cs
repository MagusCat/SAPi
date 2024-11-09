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
    public class CategoryService : ICategoryService
    {
        private readonly SapContext _context;

        public CategoryService(SapContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories.OrderBy(e => e.IdCategory).ToListAsync();
        }

        public async Task<Category?> GetByKeys(params object[] keys) 
        {
            return await _context.Categories.FindAsync(keys);
        }

        public async Task<Category?> GetByName(string name) 
        {
            return await _context.Categories.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<bool> Create(Category category)
        {
            var cat = await GetByName(category.Name);

            if (cat is not null) return false;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(Category category)
        {
            var cat = await GetByKeys(category.IdCategory);

            if (cat is null) return false;

            cat.Name = category.Name;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var cat = await GetByKeys(id);

            if (cat is null) return false;

            _context.Categories.Remove(cat);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
