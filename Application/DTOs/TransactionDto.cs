using System;

namespace App.Application.DTOs;

public class TransactionDto
{
    public int Id { get; set; }
    public string Type { get; set; } = null!; // "income" or "expense"
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string? Description { get; set; }
    public int AccountId { get; set; }
    public int CategoryId { get; set; }
}

public class TransactionCreateDto
{
    public string Type { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime? TransactionDate { get; set; }
    public string? Description { get; set; }
    public int AccountId { get; set; }
    public int CategoryId { get; set; }
}

public class TransactionUpdateDto
{
    public string? Type { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? TransactionDate { get; set; }
    public string? Description { get; set; }
    public int? AccountId { get; set; }
    public int? CategoryId { get; set; }
}
