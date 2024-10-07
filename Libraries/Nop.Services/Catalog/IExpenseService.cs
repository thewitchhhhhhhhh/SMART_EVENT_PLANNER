using Nop.Core;
using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial interface IExpenseService
    {
        Task<IPagedList<Expense>> GetAllExpenseAsync(decimal? amount = default,
            string description = default,
            DateTime? createdStartDateTime = default,
            DateTime? createdEndDateTime = default,
            int vendorId = default,
            int pageIndex = default,
            int pageSize = int.MaxValue);
        Task<Expense> GetExpenseByIdAsync(int id);
        Task InsertExpenseAsync(Expense expense);
        Task UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(Expense expense);
    }
}
