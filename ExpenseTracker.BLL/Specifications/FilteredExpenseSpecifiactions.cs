using Azure;
using ExpenseTracker.DAL.Data;
using ExpenseTracker.DAL.Models;



namespace ExpenseTracker.BLL.Specifications
{

    public class FilteredExpenseSpecifications : BaseSpecifications<Expense>
    {

        public FilteredExpenseSpecifications(int minAmount,int MaxAmount,DateTime minDate,DateTime maxDate ,string Category ,string AccountName,int PageIndex) :
        base(E => minAmount <= E.Amount && E.Amount <= MaxAmount
        && minDate <= E.Date && E.Date <= maxDate
        && (String.IsNullOrEmpty(Category) || Category == E.Category)
        && (String.IsNullOrEmpty(AccountName) || (AccountName == E.AccountName)))
        {
            ApplyPagination((PageIndex - 1) * PageSize, PageSize);
        }

        public int MinAmount { get; set; } = 0;

        public int MaxAmount { get; set; } = int.MaxValue;

        public DateTime MinDate { get; set; } = DateTime.MinValue;

        public DateTime MaxDate { get; set; } = DateTime.MaxValue;


        public string Category { get; set; } = "";

        public string AccountName { get; set; } = "";

        public int PageSize { get; set; } = 5;


        public int PageIndex { get; set; } = 1;
    }





}
