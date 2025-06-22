using System;
using System.Collections.Generic;

namespace App.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
}
