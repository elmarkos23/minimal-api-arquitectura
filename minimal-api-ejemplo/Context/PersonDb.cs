using Microsoft.EntityFrameworkCore;
using minimal_api_ejemplo.Entitys;

namespace minimal_api_ejemplo.Context
{
  public class PersonDb : DbContext
  {
    public PersonDb(DbContextOptions<PersonDb> options)
        : base(options)
    {

    }

    public DbSet<PersonEntity> Todos => Set<PersonEntity>();
  }
}