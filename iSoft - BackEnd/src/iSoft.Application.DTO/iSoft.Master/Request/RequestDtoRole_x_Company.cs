namespace iSoft.Application.DTO.iSoft.Master.Request
{

  public class RequestDtoRole_x_Company_Insert
  {
    public string? RoleId { get; set; }
    public string? CompanyId { get; set; }
    public string? StateId { get; set; }
    public bool IsSystem { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
  }

  public class RequestDtoRole_x_Company_Update
  {
    public string? RoleId { get; set; }
    public string? CompanyId { get; set; }
    public string? StateId { get; set; }
    public bool IsSystem { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
  }

  public class RequestDtoRole_x_Company_Delete
  {
    public string? RoleId { get; set; }
    public string? CompanyId { get; set; }
  }

  public class RequestDtoRole_x_Company_GetById
  {
    public string? RoleId { get; set; }
    public string? CompanyId { get; set; }
  }

  public class RequestDtoRole_x_Company_ListWithPagination
  {
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
  }

}
