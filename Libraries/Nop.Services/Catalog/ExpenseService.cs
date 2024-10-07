using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Catalog
{
    public partial class ExpenseService : IExpenseService
    {
        #region Fields

        private readonly IRepository<Expense> _expenseRepository;

        #endregion

        #region Ctor

        public ExpenseService(IRepository<Expense> expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        #endregion

        #region Methods

        public virtual async Task<IPagedList<Expense>> GetAllExpenseAsync(decimal? amount = null,
            string description = default,
            DateTime? createdStartDateTime = default,
            DateTime? createdEndDateTime = default,
            int vendorId = default,
            int pageIndex = 0,
            int pageSize = int.MaxValue)
        {
            return await _expenseRepository.GetAllPagedAsync(query =>
            {
                if (amount.HasValue && !amount.GetValueOrDefault().Equals((int)default))
                    query = query.Where(x => x.Amount.Equals(amount.Value));

                if (!string.IsNullOrEmpty(description))
                    query = query.Where(x => x.Description.Contains(description));

                if (createdStartDateTime.HasValue)
                    query = query.Where(x => x.CreatedDate >= createdStartDateTime.Value);

                if (createdEndDateTime.HasValue)
                    query = query.Where(x => x.CreatedDate <= createdEndDateTime.Value);

                if (!vendorId.Equals((int)default))
                    query = query.Where(x => x.VendorId.Equals(vendorId));

                return query;
            }, pageIndex, pageSize);
        }

        public virtual async Task<Expense> GetExpenseByIdAsync(int id)
        {
            return await _expenseRepository.GetByIdAsync(id);
        }

        public virtual async Task InsertExpenseAsync(Expense expense)
        {
            await _expenseRepository.InsertAsync(expense);
        }

        public virtual async Task UpdateExpenseAsync(Expense expense)
        {
            await _expenseRepository.UpdateAsync(expense);
        }

        public virtual async Task DeleteExpenseAsync(Expense expense)
        {
            await _expenseRepository.DeleteAsync(expense);
        }

        #endregion
    }
}
