using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Contract
{
    public interface ILoggerService
    {
        public Task Log(int user, string message, LogLevel level = LogLevel.Information);
    }
}
