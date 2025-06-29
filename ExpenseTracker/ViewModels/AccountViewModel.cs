using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using ExpenseTracker.DAL.Models;

namespace ExpenseTracker.PL.ViewModels
{
    public class AccountViewModel
    {

        public string Name { get; set; }

        public int Balance { get; set; }

        


        public string Type { get; set; }
    }
}
