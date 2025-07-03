

namespace ExpenseTracker.PL.ViewSpecifications
{

    public class BudgetSpecifications
    {
        
        public string Name { get; set; } = "";

        public int MinLimit { get; set; } = 0;

        public int MaxLimit { get; set; } = int.MaxValue;
        
        public string Account { get; set; } = "";
        public int PageSize { get; set; } = 5;

        public int PageIndex { get; set; } = 1;


    }


}