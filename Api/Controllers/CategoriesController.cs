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
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
    {
        var categories = await _categoriesService.GetAllAsync();
        return Ok(new { message = "Categorias recuperadas com sucesso", data = categories });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryDto>> GetById(int id)
    {
        var category = await _categoriesService.GetByIdAsync(id);
        return Ok(new { message = "Categoria encontrada", data = category });
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> Create([FromBody] CategoryCreateDto dto)
    {
        var created = await _categoriesService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new { message = "Categoria criada com sucesso", data = created });
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdateDto dto)
    {
        await _categoriesService.UpdateAsync(id, dto);
        return Ok(new { message = "Categoria atualizada com sucesso" }) ;
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoriesService.DeleteAsync(id);
        return NoContent();
    }
}
