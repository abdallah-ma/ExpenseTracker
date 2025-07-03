using ExpenseTracker.DAL.Models;


namespace ExpenseTracker.BLL.Specifications
{

    public class FilteredTransferSpecifications : BaseSpecifications<Transfer>
    {

        public FilteredTransferSpecifications(string sourceAccountName, string recipientAccountName, int minAmount, int maxAmount, DateTime minDate, DateTime maxDate, int PageIndex) :
        base(T => (String.IsNullOrEmpty(sourceAccountName) || T.SourceAccountName == sourceAccountName)
        && (String.IsNullOrEmpty(recipientAccountName) || T.RecipientAccountName == recipientAccountName)
        && minAmount <= T.Amount && T.Amount <= maxAmount
        && minDate <= T.Date &&  T.Date <= maxDate 
        )

        {
            ApplyPagination((PageIndex - 1) * PageSize, PageSize);
        }

        public string SourceAccountName { get; set; }

        public string RecipientAccountName { get; set; }

        public int MinAmount { get; set; }

        public int MaxAmount { get; set; }

        public DateTime MinDate { get; set; }

        public DateTime MaxDate { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; } = 5;

    }

}