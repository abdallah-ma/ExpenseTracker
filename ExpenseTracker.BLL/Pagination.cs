using ExpenseTracker.DAL;
using ExpenseTracker.DAL.Models;


namespace ExpenseTracker.BLL
{


    public class Pagination<T> where T : BaseEntity
    {
        
        public IReadOnlyList<T> Items { get; set; }

        public int PageSize { get; set; } = 5;

        public int PageNo { get; set; }

        public int Count { get; set; }

    }

}