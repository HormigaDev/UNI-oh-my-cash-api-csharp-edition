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

public class BudgetsService(AppDbContext context, IMapper mapper) : IBudgetsService
{
    private readonly AppDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<BudgetDto> CreateAsync(BudgetCreateDto dto)
    {
        var categoryExists = await _context.Categories.AnyAsync(c => c.Id == dto.CategoryId);
        if (!categoryExists)
            throw new NotFoundException("Categoria não encontrada");

        var budget = _mapper.Map<Budget>(dto);
        _context.Budgets.Add(budget);
        await _context.SaveChangesAsync();
        return _mapper.Map<BudgetDto>(budget);
    }

    public async Task<BudgetDto> GetByIdAsync(int id)
    {
        var budget = await _context.Budgets
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == id) ?? throw new NotFoundException("Orçamento não encontrado");
        return _mapper.Map<BudgetDto>(budget);
    }

    public async Task<List<BudgetDto>> GetAllAsync()
    {
        var budgets = await _context.Budgets
            .Include(b => b.Category)
            .ToListAsync();

        return _mapper.Map<List<BudgetDto>>(budgets);
    }

    public async Task<BudgetDto> UpdateAsync(int id, BudgetUpdateDto dto)
    {
        var budget = await _context.Budgets.FindAsync(id) ?? throw new NotFoundException("Orçamento não encontrado");
        if (
            dto.Amount == null &&
            dto.Period == null &&
            dto.CategoryId == null
        )
            throw new BadRequestException("Nenhuma propriedade informada para atualização");

        if (dto.Amount.HasValue)
            budget.Amount = dto.Amount.Value;

        if (dto.Period != null)
            budget.Period = dto.Period;

        if (dto.CategoryId.HasValue)
            budget.CategoryId = dto.CategoryId.Value;

        await _context.SaveChangesAsync();
        return _mapper.Map<BudgetDto>(budget);
    }

    public async Task DeleteAsync(int id)
    {
        var budget = await _context.Budgets.FindAsync(id) ?? throw new NotFoundException("Orçamento não encontrado");
        _context.Budgets.Remove(budget);
        await _context.SaveChangesAsync();
    }

    public async Task<BudgetDto> GetByCategoryAndPeriodAsync(int categoryId, string period)
    {
        var budget = await _context.Budgets
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.CategoryId == categoryId && b.Period == period) ?? throw new NotFoundException("Orçamento não encontrado");
        return _mapper.Map<BudgetDto>(budget);
    }
}
