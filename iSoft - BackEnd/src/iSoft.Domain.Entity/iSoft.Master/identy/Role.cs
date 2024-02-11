using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSoft.Domain.Entity.iSoft.Master.identy
{
  public class Role : CommonIdentity
  {

    [Required]
    [Column(Order = 2)]
    public string? Name { get; set; }

    [Required]
    [Column(Order = 3)]
    public string? Description { get; set; }

    [Column(Order = 4)]
    public string? Observation { get; set; }

  }
}
