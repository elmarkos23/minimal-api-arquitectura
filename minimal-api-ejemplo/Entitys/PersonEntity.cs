using minimal_api_ejemplo.Entitys.Audit;
using System.ComponentModel.DataAnnotations;

namespace minimal_api_ejemplo.Entitys
{
  public class PersonEntity : BaseEntity
  {
    [Key]
    public int Id { get; set; }
    public required string CardNumber { get; set; }
    public required string Name { get; set; }

    public string? Telephone { get; set; }
  }
}
