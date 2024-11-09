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
    public class UnitService : IUnitService
    {
        private readonly SapContext _context;

        public UnitService(SapContext context)
        {
            _context = context;
        }
            
        public async Task<IEnumerable<Unit>> Get()
        {
            return await _context.Units.OrderBy(e => e.IdUnit).ToListAsync();  
        }

        public async Task<IEnumerable<Unit>> Get(int id_base)
        {
            return await _context.Units.Where(e => e.ConversionIdBaseNavigations.Any(j => j.IdBase == id_base && j.IdFactor == e.IdUnit)).OrderBy(e => e.IdUnit).ToListAsync();
        }

        public async Task<Unit?> GetByKeys(object[] keys)
        {
            return await _context.Units.FindAsync(keys);
        }

        public async Task<double?> Convert(double quantity, int id_from, int id_to)
        {
            var convert = await _context.Conversions.FirstOrDefaultAsync(e => e.IdBase == id_from && e.IdFactor == id_to);

            if (convert == null || convert.Factor == null)
            {
                return null;
            }

            return quantity * convert.Factor;
        }
    }
}
