using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTarefas.Data
{
    public class Tarefas
    {
        [Table("Tarefas")]
        public record Tarefa(int Id, string Atividade, string Status);
    }
}
