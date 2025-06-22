using System;
using System.Collections.Generic;

namespace App.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = "cash";
    public decimal Balance { get; set; } = 0;
    public string Status { get; set; } = "active";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
