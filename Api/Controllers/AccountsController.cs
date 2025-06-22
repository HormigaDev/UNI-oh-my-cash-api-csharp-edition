namespace App.Api.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.DTOs;
using App.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/accounts")]
public class AccountsController(IAccountsService accountsService) : ControllerBase
{
    private readonly IAccountsService _accountsService = accountsService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountDto>>> GetAll()
    {
        var accounts = await _accountsService.GetAllAsync();
        return Ok(new { message = "Contas recuperadas com sucesso", data = accounts });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AccountDto>> GetById(int id)
    {
        var account = await _accountsService.GetByIdAsync(id);
        return Ok(new { message = "Conta encontrada", data = account });
    }

    [HttpPost]
    public async Task<ActionResult<AccountDto>> Create([FromBody] AccountCreateDto dto)
    {
        var created = await _accountsService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, new { message = "Conta criada com sucesso", data = created });
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] AccountUpdateDto dto)
    {
        await _accountsService.UpdateAsync(id, dto);
        return Ok(new { message = "Conta atualizada com sucesso" });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _accountsService.DeleteAsync(id);
        return NoContent();
    }
}
