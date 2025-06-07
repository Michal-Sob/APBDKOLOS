using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBDKOLOS.Models;

public class Subscription
{
    [Key]
    public int IdSubscription { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
        
    [Required]
    public int RenewalPeriod { get; set; }
        
    public DateTime? EndTime { get; set; }
        
    [Column(TypeName = "money")]
    public decimal Price { get; set; }
        
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
}