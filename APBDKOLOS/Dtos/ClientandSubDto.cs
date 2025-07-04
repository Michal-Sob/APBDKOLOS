﻿namespace APBDKOLOS.Dtos;

public class ClientandSubDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    
    public List<ShortSubscriptionDto> Subscriptions { get; set; } = [];

}