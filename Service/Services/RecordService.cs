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
    public class RecordService : IRecordService
    {
        private readonly SapContext _context;

        public RecordService(SapContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Record>> Get()
        {
            return await _context.Records.OrderBy(e => e.Date).ToListAsync();
        }

        public async Task<IEnumerable<Record>> GetEntries()
        {
            return await _context.Records.Where(e => e.Entry).OrderBy(e => e.Date).ToListAsync();
        }

        public async Task<IEnumerable<Record>> GetExits()
        {
            return await _context.Records.Where(e => !e.Entry).OrderBy(e => e.Date).ToListAsync();
        }
    }
}
