using Model.Data;

namespace Proyecto_SAPi.Extensions
{
    public static class Extensions
    {
        public static void ConfigureContext(this IServiceCollection services, string? connection)
        {
            if(connection is null) throw new ArgumentNullException(nameof(connection));

            services.AddSqlServer<SapContext>(connection);
        }
    }
}
