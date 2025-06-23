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
    public async Task<ActionResult<ApiResponse<List<TransactionDto>>>> GetAll()
    {
        var transactions = await _transactionsService.GetAllAsync();
        return Ok(new ApiResponse<List<TransactionDto>>
        {
            Message = "Transações recuperadas com sucesso",
            Data = transactions
        });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<TransactionDto>>> GetById(int id)
    {
        var transaction = await _transactionsService.GetByIdAsync(id);
        return Ok(new ApiResponse<TransactionDto>
        {
            Message = "Transação encontrada",
            Data = transaction
        });
    }

    [HttpGet("by-account/{accountId:int}")]
    public async Task<ActionResult<ApiResponse<List<TransactionDto>>>> GetByAccountId(int accountId)
    {
        var transactions = await _transactionsService.GetByAccountIdAsync(accountId);
        return Ok(new ApiResponse<List<TransactionDto>>
        {
            Message = "Transações recuperadas por conta",
            Data = transactions
        });
    }

    [HttpGet("by-category/{categoryId:int}")]
    public async Task<ActionResult<ApiResponse<List<TransactionDto>>>> GetByCategoryId(int categoryId)
    {
        var transactions = await _transactionsService.GetByCategoryIdAsync(categoryId);
        return Ok(new ApiResponse<List<TransactionDto>>
        {
            Message = "Transações recuperadas por categoria",
            Data = transactions
        });
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<TransactionDto>>> Create([FromBody] TransactionCreateDto dto)
    {
        var created = await _transactionsService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ApiResponse<TransactionDto>
        {
            Message = "Transação criada com sucesso",
            Data = created
        });
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ApiResponse<object>>> Update(int id, [FromBody] TransactionUpdateDto dto)
    {
        await _transactionsService.UpdateAsync(id, dto);
        return Ok(new ApiResponse<object>
        {
            Message = "Transação atualizada com sucesso",
            Data = new { }
        });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _transactionsService.DeleteAsync(id);
        return NoContent();
    }
}
