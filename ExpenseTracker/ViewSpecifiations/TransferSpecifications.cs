

namespace ExpenseTracker.PL.ViewSpecifications
{


    public class TransferSpecifications
    {
        
        public string SourceAccountName { get; set; } = "";

        public string RecipientAccountName { get; set; } = "";

        public int MinAmount { get; set; } = int.MinValue;

        public int MaxAmount { get; set; } = int.MaxValue;

        public DateTime MinDate { get; set; } = DateTime.MinValue;

        public DateTime MaxDate { get; set; } = DateTime.MaxValue;

        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 5;

    }

}