using ExpenseTracker.DAL.Data;
using ExpenseTracker.DAL.Models;


namespace ExpenseTracker.BLL.Specifications
{


    public class FilteredBudgetSpecifications : BaseSpecifications<Budget>
    {

        public FilteredBudgetSpecifications(string name, int minlimit,int MaxLimit, string Account , int PageIndex) 
        
        : base(B => (String.IsNullOrEmpty(name) || B.Name.ToLower().Contains(name)) && 
        minlimit <= B.Limit && B.Limit <= MaxLimit && ( String.IsNullOrEmpty(Account) || B.Accounts.Any(A => A.Name == Account) ) )
        {
            ApplyPagination((PageIndex - 1)*PageSize , PageSize);
        }

        public string Name { get; set; } = "";

        public int MinLimit { get; set; } = 0;

        public int MaxLimit { get; set; } = int.MaxValue;



        public string Account { get; set; } = "";
        public int PageSize { get; set; } = 5;
        
        public int PageIndex { get; set; }
    }

}
