using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSoft.Domain.Entity.iSoft.Master.master
{
  public class Status : CommonIdentity
  {

    [Required]
    [Column(Order = 2)]
    public string? Name { get; set; }

    [Required]
    [Column(Order = 3)]
    public string? Description { get; set; }

  }
}
