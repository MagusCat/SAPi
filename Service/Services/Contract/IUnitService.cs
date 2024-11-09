using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Contract
{
    public interface IUnitService
    {
        public Task<IEnumerable<Unit>> Get();

        public Task<IEnumerable<Unit>> Get(int id_base);

        public Task<Unit?> GetByKeys(object[] keys);

        public Task<double?> Convert(double quantity, int id_from, int id_to);
    }
}
