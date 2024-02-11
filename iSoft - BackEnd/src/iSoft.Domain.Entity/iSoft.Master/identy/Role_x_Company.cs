using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace iSoft.Domain.Entity.iSoft.Master.identy
{
  public class Role_x_Company //: CommonIdentity
  {

    [Required]
    [Column(Order = 1)]
    public string? RoleId { get; set; }

    [Required]
    [Column(Order = 2)]
    public string? CompanyId { get; set; }

    [Required]
    [Column(Order = 3)]
    public string? StateId { get; set; }

    [Required]
    [Column(Order = 4)]
    public bool IsSystem { get; set; }

    [Required]
    [Column(Order = 5)]
    public DateTime CreatedDate { get; set; }

    [Required]
    [Column(Order = 6)]
    public string? CreatedBy { get; set; }

    [Column(Order = 7)]
    public DateTime LastModifiedDate { get; set; }

    [Column(Order = 8)]
    public string? LastModifiedBy { get; set; }

  }
}
