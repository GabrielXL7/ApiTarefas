using ApiTarefas.Data;
using Dapper.Contrib.Extensions;
using static ApiTarefas.Data.TarefaContext;

namespace ApiTarefas.EndPoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => "Mini Tarefas API");

            app.MapGet("/tarefas", async (GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                return con.GetAll<Tarefas>().ToList();
            });

            app.MapGet("/tarefas/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                return con.Get<Tarefas>(id);
            });



            app.MapPost("/tarefas", async (GetConnection connectionGetter, Tarefas Tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Insert(Tarefa);
                return Results.Created($"/tarefas/{id}", Tarefa);
            });

            app.MapPut("/tarefas", async (GetConnection connectionGetter, Tarefas Tarefa) =>
            {
                using var con = await connectionGetter();
                var id = con.Update(Tarefa);
                return Results.Ok();
            });

        }
    }
}
