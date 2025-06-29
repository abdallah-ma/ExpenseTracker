using AutoMapper;
using ExpenseTracker.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.PL.Controllers
{
    public class BaseController : Controller
    {

        protected readonly IMapper _Mapper;
        protected IUnitOfWork _UnitOfWork;

        public BaseController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _Mapper = mapper;
            _UnitOfWork = unitOfWork;
        }
    }
}
