using ExpenseTracker.DAL.Data;
using ExpenseTracker.DAL.Models;


namespace ExpenseTracker.BLL.Specifications
{

    public class FilteredIncomeSpecifications : BaseSpecifications<Income>
    {

        public FilteredIncomeSpecifications(decimal minAmount, decimal MaxAmount, DateTime minDate, DateTime maxDate, string AccountName , int PageIndex)
        : base(I => minAmount <= I.Amount && I.Amount <= MaxAmount
         && minDate <= I.Date && I.Date <= maxDate
         && (String.IsNullOrEmpty(AccountName) || AccountName == I.AccountName))
        {
            ApplyPagination((PageIndex - 1) * PageSize, PageSize);
        }

        public int MinAmount { get; set; }

        public int MaxAmount { get; set; }

        public DateTime MinDate { get; set; }

        public DateTime MaxDate { get; set; }

        public string AccountName { get; set; }

        public int PageSize { get; set; } = 5;

        public int PageIndex { get; set; }
    }
}
