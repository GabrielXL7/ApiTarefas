using System.Data.SqlClient;
using static ApiTarefas.Data.TarefaContext;

namespace ApiTarefas.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<GetConnection>(sp =>
             async () =>
             {
                 string connectionString = sp.GetService<IConfiguration>()["ConnectionString"];
                 var connection = new SqlConnection(connectionString);
                 await connection.OpenAsync();
                 return connection;
             });

            return builder;
        }
    }
}
