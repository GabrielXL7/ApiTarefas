using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ApiTarefas.Data
{
    public class TarefaContext
    {

        public delegate Task<IDbConnection> GetConnection();

    }
}
