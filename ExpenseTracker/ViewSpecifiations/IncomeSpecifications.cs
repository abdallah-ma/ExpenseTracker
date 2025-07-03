

namespace ExpenseTracker.PL.ViewSpecifications
{


    public class IncomeSpecifications
    {

        public int MinAmount { get; set; } = int.MinValue;

        public int MaxAmount { get; set; } = int.MaxValue;

        public DateTime MinDate { get; set; } = DateTime.MinValue;

        public DateTime MaxDate { get; set; } = DateTime.MaxValue;

        public string AccountName { get; set; } = "";

        public int PageSize { get; set; } = 5;

        public int PageIndex { get; set; } = 1;

    }

}