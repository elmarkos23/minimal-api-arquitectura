using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using minimal_api_ejemplo.Context;
using minimal_api_ejemplo.Entitys;
using minimal_api_ejemplo.Models.Request;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace minimal_api_ejemplo.EndPoints
{
  public static class PersonEndPoint
  {
    public static RouteGroupBuilder MapPersonEndPoint(this RouteGroupBuilder group)
    {
      group.MapGet("/", GetAllTodos);
      group.MapGet("/{id}", GetTodo);
      group.MapPost("/", CreateTodo)
          .AddEndpointFilter(async (efiContext, next) =>
          {
            var param = efiContext.GetArgument<PersonRequest>(0);

            return await next(efiContext);
          });

      group.MapPut("/{id}", UpdateTodo);
      group.MapDelete("/{id}", DeleteTodo);

      return group;
    }

    // get all todos
    // <snippet_1>
    public static async Task<Ok<PersonEntity[]>> GetAllTodos(PersonDb database)
    {
      var todos = await database.Todos.ToArrayAsync();
      return null;
    }
    // </snippet_1>

    // get todo by id
    public static async Task<Results<Ok<PersonEntity>, NotFound>> GetTodo(int id, PersonDb database)
    {
      var todo = await database.Todos.FindAsync(id);

      if (todo != null)
      {
        return TypedResults.Ok(todo);
      }

      return TypedResults.NotFound();
    }

    // create todo
    public static async Task<Created<PersonEntity>> CreateTodo(PersonRequest todo, PersonDb database)
    {
      var newTodo = new PersonEntity
      {
        Id = 0,
        CardNumber = todo.CardNumber,
        Name = todo.Name,
        Telephone = todo.Telephone,
        Created = DateTime.Now,
        IsDeleted = false
      };

      //await database.Todos.AddAsync(newTodo);
      await database.SaveChangesAsync();

      return TypedResults.Created($"/todos/v1/{newTodo.Id}", newTodo);
    }

    // update todo
    public static async Task<Results<Created<PersonEntity>, NotFound>> UpdateTodo(PersonEntity todo, PersonDb database)
    {
      var existingTodo = await database.Todos.FindAsync(todo.Id);

      if (existingTodo != null)
      {
        existingTodo.Id = todo.Id;
        existingTodo.CardNumber = todo.CardNumber;
        existingTodo.Name = todo.Name;
        existingTodo.Created = existingTodo.Created;
        existingTodo.IsDeleted = existingTodo.IsDeleted;

        await database.SaveChangesAsync();

        return TypedResults.Created($"/todos/v1/{existingTodo.Id}", existingTodo);
      }

      return TypedResults.NotFound();
    }

    // delete todo
    public static async Task<Results<NoContent, NotFound>> DeleteTodo(int id, PersonDb database)
    {
      var todo = await database.Todos.FindAsync(id);

      if (todo != null)
      {
        database.Todos.Remove(todo);
        await database.SaveChangesAsync();

        return TypedResults.NoContent();
      }

      return TypedResults.NotFound();
    }
  }
}
