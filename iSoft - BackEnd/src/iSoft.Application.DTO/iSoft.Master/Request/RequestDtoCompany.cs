namespace iSoft.Application.DTO.iSoft.Master.Request
{

  public class RequestDtoCompany_Insert 
  {

    public string? KeyId { get; set; }
    public string? Ruc { get; set; }
    public string? Description { get; set; }
    public string? Observation { get; set; }
    public string? Address { get; set; }
    public string? Agent { get; set; }
    public string? Phone { get; set; }
    public string? EMail { get; set; }
    public string? Web { get; set; }
    public string? StateId { get; set; }
    public bool IsSystem { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }

  }

  public class RequestDtoCompany_Update
  {

    public string? KeyId { get; set; }
    public string? Ruc { get; set; }
    public string? Description { get; set; }
    public string? Observation { get; set; }
    public string? Address { get; set; }
    public string? Agent { get; set; }
    public string? Phone { get; set; }
    public string? EMail { get; set; }
    public string? Web { get; set; }
    public string? StateId { get; set; }
    public bool IsSystem { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }

  }

  public class RequestDtoCompany_Delete
  {
    public string? KeyId { get; set; }
  }

  public class RequestDtoCompany_GetById
  {
    public string? KeyId { get; set; }
  }

  public class RequestDtoCompany_ListWithPagination
  {
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
  }

}
