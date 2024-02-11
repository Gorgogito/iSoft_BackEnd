using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSoft.Domain.Entity.iSoft.Master.master
{
  public class Company : CommonIdentity
  {

    [Required]
    [Column(Order = 2)]
    public string? Ruc { get; set; }

    [Required]
    [Column(Order = 3)]
    public string? Description { get; set; }

    [Column(Order = 4)]
    public string? Observation { get; set; }

    [Column(Order = 5)]
    public string? Address { get; set; }

    [Column(Order = 6)]
    public string? Agent { get; set; }

    [Column(Order = 7)]
    public string? Phone { get; set; }

    [Column(Order = 8)]
    public string? EMail { get; set; }

    [Column(Order = 9)]
    public string? Web { get; set; }

  }
}
