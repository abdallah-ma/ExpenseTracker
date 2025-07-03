

namespace ExpenseTracker.PL.ViewSpecifications
{

    public class ExpenseSpecifications
    {


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