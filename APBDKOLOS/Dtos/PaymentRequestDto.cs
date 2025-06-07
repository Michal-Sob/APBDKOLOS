using System.ComponentModel.DataAnnotations;

namespace APBDKOLOS.Dtos;

public class PaymentRequestDto
{
    [Required]
    public int IdClient { get; set; }
        
    [Required]
    public int IdSubscription { get; set; }
        
    [Required]
    public decimal Payment { get; set; }
}