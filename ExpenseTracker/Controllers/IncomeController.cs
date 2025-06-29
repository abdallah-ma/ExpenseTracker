using AutoMapper;
using ExpenseTracker.BLL.Interfaces;
using ExpenseTracker.BLL.Specifications;
using ExpenseTracker.DAL.Models;
using ExpenseTracker.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExpenseTracker.PL.Controllers
{
    public class IncomeController : BaseController
    {

        public IncomeController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IActionResult> Index()
        {
            var Incomes = await _UnitOfWork.IncomeRepository.GetAllAsync();
            return View(Incomes);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(IncomeViewModel income)
        {
            if (ModelState.IsValid)
            {
                var MappedIncome = _Mapper.Map<IncomeViewModel , Income>(income);

                await _UnitOfWork.IncomeRepository.AddAsync(MappedIncome);
                
                var Count = await _UnitOfWork.CompleteAsync();
                


                if(Count > 0)return RedirectToAction(nameof(Index));

                return View(income);
            }
            return View(income);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id is null)return BadRequest();

            var Income = await _UnitOfWork.IncomeRepository.GetAsync(id.Value);

            TempData["Id"] = id.Value;

            var MappedIncome = _Mapper.Map<Income, IncomeViewModel>(Income);

            return View(MappedIncome);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IncomeViewModel income)
        {
            if (ModelState.IsValid)
            {
                var MappedExpense = _Mapper.Map<IncomeViewModel, Income>(income);

                MappedExpense.Id = (int)TempData["Id"];

                await _UnitOfWork.IncomeRepository.UpdateAsync(MappedExpense);

                var Count = await _UnitOfWork.CompleteAsync();

                if(Count > 0) return RedirectToAction(nameof(Index));
                else return(View(income));
            }
            return View(income);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();


            var Income = await _UnitOfWork.IncomeRepository.GetAsync(id.Value);

            var MappedIncome = _Mapper.Map<Income, IncomeViewModel>(Income);


            return View(MappedIncome);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if(id is null) return BadRequest();

            var Income = await _UnitOfWork.IncomeRepository.GetAsync(id.Value);

            await _UnitOfWork.IncomeRepository.DeleteAsync(Income);

            await _UnitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
