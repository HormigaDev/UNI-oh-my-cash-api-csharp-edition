using App.Domain.Entities;
using App.Application.DTOs;
using AutoMapper;

namespace App.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<AccountCreateDto, Account>();
            CreateMap<AccountUpdateDto, Account>();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();

            CreateMap<Transaction, TransactionDto>().ReverseMap();
            CreateMap<TransactionCreateDto, Transaction>();
            CreateMap<TransactionUpdateDto, Transaction>();

            CreateMap<Budget, BudgetDto>().ReverseMap();
            CreateMap<BudgetCreateDto, Budget>();
            CreateMap<BudgetUpdateDto, Budget>();
        }
    }
}
