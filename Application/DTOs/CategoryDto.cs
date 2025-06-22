namespace App.Application.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

public class CategoryCreateDto
{
    public string Name { get; set; } = null!;
}

public class CategoryUpdateDto
{
    public string? Name { get; set; }
}
