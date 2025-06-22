using System;

namespace App.Domain.Entities;

public class Budget
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public decimal Amount { get; set; }
    public string Period { get; set; } = null!; // "monthly", "weekly", "yearly"
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
