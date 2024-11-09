using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Contract
{
    public interface IRecordService
    {
        public Task<IEnumerable<Record>> GetExits();
        public Task<IEnumerable<Record>> GetEntries();
        public Task<IEnumerable<Record>> Get();
    }
}
