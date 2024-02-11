using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSoft.Domain.Entity.iSoft.Master.identy
{
  public class User : CommonIdentity
  {

    [Required]
    [Column(Order = 2)]
    public string? UserName { get; set; }

    [Required]
    [Column(Order = 3)]
    public string? Password { get; set; }

    [Required]
    [Column(Order = 4)]
    public string? Description { get; set; }

    [Column(Order = 5)]
    public string? Observation { get; set; }

    [Column(Order = 6)]
    public string? Names { get; set; }

    [Column(Order = 7)]
    public string? Surnames { get; set; }

    [Column(Order = 8)]
    public string? Phone { get; set; }

    [Column(Order = 9)]
    public string? EMail { get; set; }

    [Column(Order = 10)]
    public byte[]? Image { get; set; }

    [Column(Order = 11)]
    public string? Token { get; set; }

    [Required]
    [Column(Order = 12)]
    public string? RoleId { get; set; }

  }
}
