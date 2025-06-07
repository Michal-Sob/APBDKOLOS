using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDKOLOS.Models;

public class Payment
{
    [Key]
    public int IdPayment { get; set; }
        
    [Required]
    public DateTime Date { get; set; }
        
    [Required]
    public int IdClient { get; set; }
        
    [Required]
    public int IdSubscription { get; set; }
        
    [Column(TypeName = "money")]
    public decimal Amount { get; set; }
        
    [ForeignKey("IdClient")]
    public virtual Client Client { get; set; }
        
    [ForeignKey("IdSubscription")]
    public virtual Subscription Subscription { get; set; }
}