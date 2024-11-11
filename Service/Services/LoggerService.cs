using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Data;
using Service.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly SapContext _context;


        private static Dictionary<LogLevel, string> logs = new Dictionary<LogLevel, string>()
        {
            {LogLevel.Error, "[ERROR]" },
            {LogLevel.Trace, "[TRACE]" },
            {LogLevel.Warning, "[WARN]" },
            {LogLevel.Information, "[INFO]" }
        };
        public LoggerService(SapContext context)
        {
            _context = context;
        }

        public async Task Log(int user, string message, LogLevel level = LogLevel.Information)
        {
            if (user == 0|| string.IsNullOrEmpty(message) || !(await _context.Users.AnyAsync(e => e.IdUser == user)))
            {
                return;
            }

            _context.Logs.Add(new Model.Models.Log()
            {
                IdUser = user,
                Action = $"{logs[level]} - {message}"
            });

            await _context.SaveChangesAsync();
        }
    }
}
