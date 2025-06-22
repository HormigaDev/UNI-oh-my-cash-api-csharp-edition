namespace App.Application.DTOs;

public class AccountDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = "cash";
    public decimal Balance { get; set; }
    public string Status { get; set; } = "active";
}

public class AccountCreateDto
{
    public string Name { get; set; } = null!;
    public string Type { get; set; } = "cash";
    public decimal Balance { get; set; } = 0;
}

public class AccountUpdateDto
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public decimal? Balance { get; set; }
    public string? Status { get; set; }
}
