using minimal_api_ejemplo.Context;
using minimal_api_ejemplo.Entitys;

namespace minimal_api_ejemplo.Services
{
  public class PersonService : IPersonService
  {
    private readonly PersonDb _dbContext;
    //private readonly IEmailService _emailService;
    public Task Add(PersonEntity todo)
    {
      throw new NotImplementedException();
    }

    public ValueTask<PersonEntity?> Find(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<PersonEntity>> GetAll()
    {
      throw new NotImplementedException();
    }

    public Task<List<PersonEntity>> GetIncompleteTodos()
    {
      throw new NotImplementedException();
    }

    public Task Remove(PersonEntity todo)
    {
      throw new NotImplementedException();
    }

    public Task Update(PersonEntity todo)
    {
      throw new NotImplementedException();
    }
  }
}
