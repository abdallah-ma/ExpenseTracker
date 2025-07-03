using ExpenseTracker.BLL.Specifications;
using ExpenseTracker.DAL;
using ExpenseTracker.DAL.Models;


namespace ExpenseTracker.BLL.Specifications
{


    public class FilteredAccountSpecifications : BaseSpecifications<Account>
    {


        public FilteredAccountSpecifications(int minBalance, int maxBalance, string name , int PageIndex) :
        base( A => minBalance <= A.Balance && A.Balance <= maxBalance
        && (String.IsNullOrEmpty(name) || A.Name.ToLower().Contains(name)) )

        {
            ApplyPagination((PageIndex - 1) * PageSize, PageSize);
        }
        public int MinBalance { get; set; } = 0;

        public int MaxBalance { get; set; } = int.MaxValue;

        public string Name { get; set; }

        public int PageSize { get; set; } = 5;
        
        public int PageIndex { get; set; }

    }

}