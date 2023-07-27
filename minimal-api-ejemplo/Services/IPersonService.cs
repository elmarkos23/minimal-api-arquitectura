using minimal_api_ejemplo.Entitys;

namespace minimal_api_ejemplo.Services
{
  public interface IPersonService
  {
    Task<List<PersonEntity>> GetAll();

    Task<List<PersonEntity>> GetIncompleteTodos();

    ValueTask<PersonEntity?> Find(int id);

    Task Add(PersonEntity todo);

    Task Update(PersonEntity todo);

    Task Remove(PersonEntity todo);
  }
}
