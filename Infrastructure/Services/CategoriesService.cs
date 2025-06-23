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

public class CategoriesService(AppDbContext context, IMapper mapper) : ICategoriesService
{
    private readonly AppDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryDto> CreateAsync(CategoryCreateDto dto)
    {
        var category = _mapper.Map<Category>(dto);
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id) ?? throw new NotFoundException("Categoria não encontrada");
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return _mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> UpdateAsync(int id, CategoryUpdateDto dto)
    {
        var category = await _context.Categories.FindAsync(id) ?? throw new NotFoundException("Categoria não encontrada");
        if (dto.Name == null)
            throw new BadRequestException("Nenhuma propriedade informada para atualização");

        category.Name = dto.Name;
        await _context.SaveChangesAsync();

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id) ?? throw new NotFoundException("Categoria não encontrada");
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}
