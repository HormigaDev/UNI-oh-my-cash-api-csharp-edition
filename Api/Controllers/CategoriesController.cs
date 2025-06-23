namespace App.Api.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.DTOs;
using App.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/categories")]
public class CategoriesController(ICategoriesService categoriesService) : ControllerBase
{
    private readonly ICategoriesService _categoriesService = categoriesService;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<CategoryDto>>>> GetAll()
    {
        var categories = await _categoriesService.GetAllAsync();
        return Ok(new ApiResponse<List<CategoryDto>>
        {
            Message = "Categorias recuperadas com sucesso",
            Data = categories
        });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<CategoryDto>>> GetById(int id)
    {
        var category = await _categoriesService.GetByIdAsync(id);
        return Ok(new ApiResponse<CategoryDto>
        {
            Message = "Categoria encontrada",
            Data = category
        });
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<CategoryDto>>> Create([FromBody] CategoryCreateDto dto)
    {
        var created = await _categoriesService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ApiResponse<CategoryDto>
        {
            Message = "Categoria criada com sucesso",
            Data = created
        });
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ApiResponse<object>>> Update(int id, [FromBody] CategoryUpdateDto dto)
    {
        await _categoriesService.UpdateAsync(id, dto);
        return Ok(new ApiResponse<object>
        {
            Message = "Categoria atualizada com sucesso",
            Data = new { }
        });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoriesService.DeleteAsync(id);
        return NoContent();
    }
}
