using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Contract
{
    public interface IInventoryService
    {
        public Task<IEnumerable<Inventory>> Get();
        public Task<IEnumerable<Inventory>> Get(int id_product);
        public Task<double> Stock(int id_product);
    }
}
