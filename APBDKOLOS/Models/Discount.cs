using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDKOLOS.Models;

public class Discount
{
    [Key]
    public int IdDiscount { get; set; }
        
    [Required]
    public int Value { get; set; }
        
    [Required]
    public int IdSubscription { get; set; }
        
    [Required]
    public DateTime DateFrom { get; set; }
        
    [Required]
    public DateTime DateTo { get; set; }
        
    [ForeignKey("IdSubscription")]
    public virtual Subscription Subscription { get; set; }
}