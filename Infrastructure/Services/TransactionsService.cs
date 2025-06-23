namespace App.Infrastructure.Services;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Application.DTOs;
using App.Application.Exceptions;
using App.Application.Interfaces;
using App.Domain.Entities;
using App.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class TransactionsService(AppDbContext context, IMapper mapper) : ITransactionsService
{
    private readonly AppDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<TransactionDto> CreateAsync(TransactionCreateDto dto)
    {
        var accountExists = await _context.Accounts.AnyAsync(a => a.Id == dto.AccountId);
        if (!accountExists)
            throw new NotFoundException("Conta não encontrada");

        var categoryExists = await _context.Categories.AnyAsync(c => c.Id == dto.CategoryId);
        if (!categoryExists)
            throw new NotFoundException("Categoria não encontrada");

        var transaction = _mapper.Map<Transaction>(dto);

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        return _mapper.Map<TransactionDto>(transaction);
    }

    public async Task<TransactionDto> GetByIdAsync(int id)
    {
        var transaction = await _context.Transactions
            .Include(t => t.Account)
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id) ?? throw new NotFoundException("Transação não encontrada");
        return _mapper.Map<TransactionDto>(transaction);
    }

    public async Task<List<TransactionDto>> GetAllAsync()
    {
        var transactions = await _context.Transactions
            .Include(t => t.Account)
            .Include(t => t.Category)
            .ToListAsync();

        return _mapper.Map<List<TransactionDto>>(transactions);
    }

    public async Task<TransactionDto> UpdateAsync(int id, TransactionUpdateDto dto)
    {
        var transaction = await _context.Transactions.FindAsync(id) ?? throw new NotFoundException("Transação não encontrada");

        if (
            dto.Type == null &&
            !dto.Amount.HasValue &&
            dto.TransactionDate == null &&
            dto.Description == null &&
            !dto.AccountId.HasValue &&
            !dto.CategoryId.HasValue
        )
            throw new BadRequestException("Nenhuma propriedade informada para atualização");

        if (dto.AccountId.HasValue)
        {
            var accountExists = await _context.Accounts.AnyAsync(a => a.Id == dto.AccountId.Value);
            if (!accountExists)
                throw new NotFoundException("Conta não encontrada");
            transaction.AccountId = dto.AccountId.Value;
        }

        if (dto.CategoryId.HasValue)
        {
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == dto.CategoryId.Value);
            if (!categoryExists)
                throw new NotFoundException("Categoria não encontrada");
            transaction.CategoryId = dto.CategoryId.Value;
        }

        if (dto.Type != null)
            transaction.Type = dto.Type;

        if (dto.Amount.HasValue)
            transaction.Amount = dto.Amount.Value;

        if (dto.TransactionDate.HasValue)
            transaction.TransactionDate = dto.TransactionDate.Value;

        if (dto.Description != null)
            transaction.Description = dto.Description;

        await _context.SaveChangesAsync();
        return _mapper.Map<TransactionDto>(transaction);
    }

    public async Task DeleteAsync(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id) ?? throw new NotFoundException("Transação não encontrada");
        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TransactionDto>> GetByAccountIdAsync(int accountId)
    {
        var accountExists = await _context.Accounts.AnyAsync(a => a.Id == accountId);
        if (!accountExists)
            throw new NotFoundException("Conta não encontrada");

        var transactions = await _context.Transactions
            .Where(t => t.AccountId == accountId)
            .Include(t => t.Account)
            .Include(t => t.Category)
            .ToListAsync();

        return _mapper.Map<List<TransactionDto>>(transactions);
    }

    public async Task<List<TransactionDto>> GetByCategoryIdAsync(int categoryId)
    {
        var categoryExists = await _context.Categories.AnyAsync(c => c.Id == categoryId);
        if (!categoryExists)
            throw new NotFoundException("Categoria não encontrada");

        var transactions = await _context.Transactions
            .Where(t => t.CategoryId == categoryId)
            .Include(t => t.Account)
            .Include(t => t.Category)
            .ToListAsync();

        return _mapper.Map<List<TransactionDto>>(transactions);
    }
}
