namespace iSoft.Application.DTO.iSoft.Master.Request
{

  public class RequestDtoRole_Insert
  {
    public string? KeyId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Observation { get; set; }
    public string? StateId { get; set; }
    public bool IsSystem { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
  }

  public class RequestDtoRole_Update
  {
    public string? KeyId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Observation { get; set; }
    public string? StateId { get; set; }
    public bool IsSystem { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
  }

  public class RequestDtoRole_Delete
  {
    public string? KeyId { get; set; }
  }

  public class RequestDtoRole_GetById
  {
    public string? KeyId { get; set; }
  }

  public class RequestDtoRole_ListWithPagination
  {
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
  }

}
