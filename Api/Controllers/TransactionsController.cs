namespace App.Api.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.DTOs;
using App.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/transactions")]
public class TransactionsController(ITransactionsService transactionsService) : ControllerBase
{
    private readonly ITransactionsService _transactionsService = transactionsService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionDto>>> GetAll()
    {
        var transactions = await _transactionsService.GetAllAsync();
        return Ok(new { message = "Transações recuperadas com sucesso", data = transactions });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TransactionDto>> GetById(int id)
    {
        var transaction = await _transactionsService.GetByIdAsync(id);
        return Ok(new { message = "Transação encontrada", data = transaction });
    }

    [HttpGet("by-account/{accountId:int}")]
    public async Task<ActionResult<IEnumerable<TransactionDto>>> GetByAccountId(int accountId)
    {
        var transactions = await _transactionsService.GetByAccountIdAsync(accountId);
        return Ok(new { message = "Transações recuperadas por conta", data = transactions });
    }

    [HttpGet("by-category/{categoryId:int}")]
    public async Task<ActionResult<IEnumerable<TransactionDto>>> GetByCategoryId(int categoryId)
    {
        var transactions = await _transactionsService.GetByCategoryIdAsync(categoryId);
        return Ok(new { message = "Transações recuperadas por categoria", data = transactions });
    }

    [HttpPost]
    public async Task<ActionResult<TransactionDto>> Create([FromBody] TransactionCreateDto dto)
    {
        var created = await _transactionsService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new { message = "Transação criada com sucesso", data = created });
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] TransactionUpdateDto dto)
    {
        await _transactionsService.UpdateAsync(id, dto);
        return Ok(new { message = "Transação atualizada com sucesso" });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _transactionsService.DeleteAsync(id);
        return NoContent();
    }
}
