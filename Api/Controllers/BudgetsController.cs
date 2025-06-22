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
    public async Task<ActionResult<IEnumerable<BudgetDto>>> GetAll()
    {
        var budgets = await _budgetsService.GetAllAsync();
        return Ok(new { message = "Orçamentos recuperados com sucesso", data = budgets });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BudgetDto>> GetById(int id)
    {
        var budget = await _budgetsService.GetByIdAsync(id);
        return Ok(new { message = "Orçamento encontrado", data = budget });
    }

    [HttpGet("by-category/{categoryId:int}/{period}")]
    public async Task<ActionResult<BudgetDto>> GetByCategoryAndPeriod(int categoryId, string period)
    {
        var budget = await _budgetsService.GetByCategoryAndPeriodAsync(categoryId, period);
        return Ok(new { message = "Orçamento encontrado", data = budget });
    }

    [HttpPost]
    public async Task<ActionResult<BudgetDto>> Create([FromBody] BudgetCreateDto dto)
    {
        var created = await _budgetsService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new { message = "Orçamento criado com sucesso", data = created });
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] BudgetUpdateDto dto)
    {
        await _budgetsService.UpdateAsync(id, dto);
        return Ok(new { message = "Orçamento atualizado com sucesso" });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _budgetsService.DeleteAsync(id);
        return NoContent();
    }
}
