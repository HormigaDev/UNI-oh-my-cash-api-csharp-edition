namespace App.Application.DTOs;

public class BudgetDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Period { get; set; } = null!; // "monthly", "weekly", "yearly"
}

public class BudgetCreateDto
{
    public int CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Period { get; set; } = null!;
}

public class BudgetUpdateDto
{
    public int? CategoryId { get; set; }
    public decimal? Amount { get; set; }
    public string? Period { get; set; }
}
