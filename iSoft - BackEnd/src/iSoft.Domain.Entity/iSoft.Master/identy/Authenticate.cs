using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace iSoft.Domain.Entity.iSoft.Master.identy
{
  public  class Authenticate
  {

    [Column(Order = 1)]
    public string? KeyId { get; set; }

    [Required]
    [Column(Order = 2)]
    public string? UserName { get; set; }

    [Required]
    [Column(Order = 3)]
    public string? Password { get; set; }

    [Column(Order = 4)]
    public string? Description { get; set; }

    [Column(Order = 5)]
    public string? Names { get; set; }

    [Column(Order = 6)]
    public string? Surnames { get; set; }

    [Column(Order = 7)]
    public string? Phone { get; set; }

    [Column(Order = 8)]
    public string? EMail { get; set; }

    [Column(Order = 9)]
    public byte Image { get; set; }

    [Column(Order = 10)]
    public string? Token { get; set; }

    [Column(Order = 11)]
    public string? RoleId { get; set; }

    [Column(Order = 12)]
    public string? StateId { get; set; }

    [Column(Order = 13)]
    public bool? IsSystem { get; set; }

  }
}
