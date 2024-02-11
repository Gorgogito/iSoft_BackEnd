namespace iSoft.Application.DTO.iSoft.Master.Request
{

  public class RequestDtoUser_Insert 
  {
    public string? KeyId { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Description { get; set; }
    public string? Observation { get; set; }
    public string? Names { get; set; }
    public string? Surnames { get; set; }
    public string? Phone { get; set; }
    public string? EMail { get; set; }
    public byte? Image { get; set; }
    public string? RoleId { get; set; }
    public string? StateId { get; set; }
    public bool IsSystem { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
  }

  public class RequestDtoUser_Update
  {
    public string? KeyId { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Description { get; set; }
    public string? Observation { get; set; }
    public string? Names { get; set; }
    public string? Surnames { get; set; }
    public string? Phone { get; set; }
    public string? EMail { get; set; }
    public byte? Image { get; set; }
    public string? RoleId { get; set; }
    public string? StateId { get; set; }
    public bool IsSystem { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
  }

  public class RequestDtoUser_Delete
  {
    public string? KeyId { get; set; }
  }

  public class RequestDtoUser_GetById
  {
    public string? KeyId { get; set; }
  }

  public class RequestDtoUser_ListWithPagination
  {
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
  }

}
