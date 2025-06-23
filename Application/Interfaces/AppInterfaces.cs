namespace App.Application.Interfaces
{
    using App.Application.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAccountsService
    {
        Task<AccountDto> CreateAsync(AccountCreateDto dto);
        Task<AccountDto> GetByIdAsync(int id);
        Task<List<AccountDto>> GetAllAsync();
        Task<AccountDto> UpdateAsync(int id, AccountUpdateDto dto);
        Task DeleteAsync(int id);
    }

    public interface ICategoriesService
    {
        Task<CategoryDto> CreateAsync(CategoryCreateDto dto);
        Task<CategoryDto> GetByIdAsync(int id);
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> UpdateAsync(int id, CategoryUpdateDto dto);
        Task DeleteAsync(int id);
    }

    public interface ITransactionsService
    {
        Task<TransactionDto> CreateAsync(TransactionCreateDto dto);
        Task<TransactionDto> GetByIdAsync(int id);
        Task<List<TransactionDto>> GetAllAsync();
        Task<TransactionDto> UpdateAsync(int id, TransactionUpdateDto dto);
        Task DeleteAsync(int id);

        Task<List<TransactionDto>> GetByAccountIdAsync(int accountId);
        Task<List<TransactionDto>> GetByCategoryIdAsync(int categoryId);
    }

    public interface IBudgetsService
    {
        Task<BudgetDto> CreateAsync(BudgetCreateDto dto);
        Task<BudgetDto> GetByIdAsync(int id);
        Task<List<BudgetDto>> GetAllAsync();
        Task<BudgetDto> UpdateAsync(int id, BudgetUpdateDto dto);
        Task DeleteAsync(int id);

        Task<BudgetDto> GetByCategoryAndPeriodAsync(int categoryId, string period);
    }
}
