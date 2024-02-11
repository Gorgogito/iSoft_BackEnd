using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iSoft.Domain.Entity
{
  public class CommonIdentity
  {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    [Key]
    [Required]
    public string? KeyId { get; set; }

    [Required]
    public string? StateId { get; set; }

    [Required]
    public bool IsSystem { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public string? CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public string? LastModifiedBy { get; set; }

  }
}
