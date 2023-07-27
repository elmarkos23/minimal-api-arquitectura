namespace minimal_api_ejemplo.Entitys.Audit
{
  public class BaseEntity
  {
    public DateTime Created { get; set; }
    public bool IsDeleted { get; set; }
  }
}
