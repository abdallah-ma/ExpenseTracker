

namespace ExpenseTracker.PL.ViewSpecifications
{


    public class AccountSpecifications
    {

        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        public int MinBalance { get; set; } = 0;

        public int MaxBalance { get; set; } = int.MaxValue;

        public string Name { get; set; } = String.Empty;

    }

}