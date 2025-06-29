using AutoMapper;
using ExpenseTracker.PL.ViewModels;
using ExpenseTracker.DAL.Models;

namespace ExpenseTracker.PL.Helpers
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles() {
            CreateMap<AccountViewModel, Account>().ForMember(A => A.Id  , opt => opt.Ignore());


            CreateMap<Account, AccountViewModel>();

            CreateMap<Budget, BudgetViewModel>().
                ForMember(dest => dest.Accounts , opt => opt.MapFrom(src => src.Accounts.Select(A => A.Id) ) );

            CreateMap<BudgetViewModel, Budget>()
                .ForMember(dest => dest.Accounts , opt => opt.MapFrom(src => src.Accounts.Select(A => new Account { Id = A }  ) ) );

            CreateMap<Expense, ExpenseViewModel>().ReverseMap();


            CreateMap<TransferViewModel, Transfer>().ReverseMap();


            CreateMap<Income, IncomeViewModel>().ReverseMap();

        }

       

    }
}
