using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDKOLOS.Models;

public class Sale
{
    [Key]
    public int IdSale { get; set; }
        
    [Required]
    public int IdClient { get; set; }
        
    [Required]
    public int IdSubscription { get; set; }
        
    [Required]
    public DateTime CreatedAt { get; set; }
        
    [ForeignKey("IdClient")]
    public virtual Client Client { get; set; }
        
    [ForeignKey("IdSubscription")]
    public virtual Subscription Subscription { get; set; }
}