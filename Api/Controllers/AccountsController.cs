namespace App.Api.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.DTOs;
using App.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

public class ApiResponse<T>
{
    public string Message { get; set; } = null!;
    public T Data { get; set; } = default!;
}

[ApiController]
[Route("api/accounts")]
public class AccountsController(IAccountsService accountsService) : ControllerBase
{
    private readonly IAccountsService _accountsService = accountsService;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<AccountDto>>>> GetAll()
    {
        var accounts = await _accountsService.GetAllAsync();
        var response = new ApiResponse<List<AccountDto>>
        {
            Message = "Contas recuperadas com sucesso",
            Data = accounts
        };
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<AccountDto>>> GetById(int id)
    {
        var account = await _accountsService.GetByIdAsync(id);
        var response = new ApiResponse<AccountDto>
        {
            Message = "Conta encontrada",
            Data = account
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<AccountDto>>> Create([FromBody] AccountCreateDto dto)
    {
        var created = await _accountsService.CreateAsync(dto);
        var response = new ApiResponse<AccountDto>
        {
            Message = "Conta criada com sucesso",
            Data = created
        };
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, response);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ApiResponse<object>>> Update(int id, [FromBody] AccountUpdateDto dto)
    {
        await _accountsService.UpdateAsync(id, dto);
        var response = new ApiResponse<object>
        {
            Message = "Conta atualizada com sucesso",
            Data = new { }
        };
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _accountsService.DeleteAsync(id);
        return NoContent();
    }
}
