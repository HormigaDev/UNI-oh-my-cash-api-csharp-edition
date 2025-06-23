namespace App.Api.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.DTOs;
using App.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/budgets")]
public class BudgetsController(IBudgetsService budgetsService) : ControllerBase
{
    private readonly IBudgetsService _budgetsService = budgetsService;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<BudgetDto>>>> GetAll()
    {
        var budgets = await _budgetsService.GetAllAsync();
        return Ok(new ApiResponse<List<BudgetDto>>
        {
            Message = "Orçamentos recuperados com sucesso",
            Data = budgets
        });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<BudgetDto>>> GetById(int id)
    {
        var budget = await _budgetsService.GetByIdAsync(id);
        return Ok(new ApiResponse<BudgetDto>
        {
            Message = "Orçamento encontrado",
            Data = budget
        });
    }

    [HttpGet("by-category/{categoryId:int}/{period}")]
    public async Task<ActionResult<ApiResponse<BudgetDto>>> GetByCategoryAndPeriod(int categoryId, string period)
    {
        var budget = await _budgetsService.GetByCategoryAndPeriodAsync(categoryId, period);
        return Ok(new ApiResponse<BudgetDto>
        {
            Message = "Orçamento encontrado",
            Data = budget
        });
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<BudgetDto>>> Create([FromBody] BudgetCreateDto dto)
    {
        var created = await _budgetsService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ApiResponse<BudgetDto>
        {
            Message = "Orçamento criado com sucesso",
            Data = created
        });
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ApiResponse<object>>> Update(int id, [FromBody] BudgetUpdateDto dto)
    {
        await _budgetsService.UpdateAsync(id, dto);
        return Ok(new ApiResponse<object>
        {
            Message = "Orçamento atualizado com sucesso",
            Data = new { }
        });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _budgetsService.DeleteAsync(id);
        return NoContent();
    }
}
