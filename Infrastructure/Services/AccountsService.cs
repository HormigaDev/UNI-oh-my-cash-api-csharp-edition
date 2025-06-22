namespace App.Infrastructure.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Application.DTOs;
using App.Application.Exceptions;
using App.Application.Interfaces;
using App.Domain.Entities;
using App.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class AccountsService(AppDbContext context, IMapper mapper) : IAccountsService
{
    private readonly AppDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<AccountDto> CreateAsync(AccountCreateDto dto)
    {
        var account = _mapper.Map<Account>(dto);
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return _mapper.Map<AccountDto>(account);
    }

    public async Task<IEnumerable<AccountDto>> GetAllAsync()
    {
        var accounts = await _context.Accounts.ToListAsync();
        return _mapper.Map<IEnumerable<AccountDto>>(accounts);
    }

    public async Task<AccountDto> GetByIdAsync(int id)
    {
        var account = await _context.Accounts.FindAsync(id) ?? throw new NotFoundException("Conta não encontrada");
        return _mapper.Map<AccountDto>(account);
    }

    public async Task<AccountDto> UpdateAsync(int id, AccountUpdateDto dto)
    {
        var account = await _context.Accounts.FindAsync(id) ?? throw new NotFoundException("Conta não encontrada");
        if (
            dto.Name == null &&
            dto.Type == null &&
            !dto.Balance.HasValue &&
            dto.Status == null
        )
            throw new BadRequestException("Nenhum campo fornecido para atualização");

        if (dto.Name != null)
            account.Name = dto.Name;

        if (dto.Type != null)
            account.Type = dto.Type;

        if (dto.Balance.HasValue)
            account.Balance = dto.Balance.Value;

        if (dto.Status != null)
            account.Status = dto.Status;

        await _context.SaveChangesAsync();
        return _mapper.Map<AccountDto>(account);
    }

    public async Task DeleteAsync(int id)
    {
        var account = await _context.Accounts.FindAsync(id) ?? throw new NotFoundException("Conta não encontrada");
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }
}
