﻿using System.ComponentModel.DataAnnotations;

namespace APBDKOLOS.Models;

public class Client
{
    [Key]
    public int IdClient { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
        
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
        
    [MaxLength(100)]
    public string Phone { get; set; }
        
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

}