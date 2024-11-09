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
    public class InventoryService : IInventoryService
    {
        private readonly SapContext _context;

        public InventoryService(SapContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> Get()
        {
            return await _context.Inventories.OrderBy(e => e.IdInventory).ToListAsync();
        }

        public async Task<IEnumerable<Inventory>> Get(int id_product)
        {
            return await _context.Inventories.Where(e => e.IdProduct == id_product).OrderBy(e => e.IdInventory).ToListAsync();
        }

        public async Task<double> Stock(int id_product)
        {
            return await _context.Inventories.Where(e => e.IdProduct == id_product).SumAsync(e => e.Quantity);
        }
    }
}
