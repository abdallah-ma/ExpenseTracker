using AutoMapper;
using ExpenseTracker.BLL;
using ExpenseTracker.BLL.Interfaces;
using ExpenseTracker.BLL.Specifications;
using ExpenseTracker.DAL.Models;
using ExpenseTracker.PL.ViewModels;
using ExpenseTracker.PL.ViewSpecifications;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.PL.Controllers
{
    public class ExpenseController : BaseController
    {

        public ExpenseController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
        public async Task<ActionResult < Pagination<Expense> > > Index(ExpenseSpecifications spec)
        {

            var FilterSpecifications = new FilteredExpenseSpecifications(spec.MinAmount , spec.MaxAmount , spec.MinDate , spec.MaxDate , spec.Category , spec.AccountName , spec.PageIndex);

            var Expenses = await _UnitOfWork.ExpenseRepository.GetAllAsyncWithSpec(FilterSpecifications) as IReadOnlyList<Expense>;

            var Count = await _UnitOfWork.ExpenseRepository.GetCountAsync(FilterSpecifications);

            return View(new Pagination<Expense>() {Items = Expenses , Count = Count , PageNo = spec.PageIndex , PageSize = spec.PageSize});
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseViewModel expense)
        {
            if (ModelState.IsValid)
            {
                var MappedExpense = _Mapper.Map<ExpenseViewModel, Expense>(expense);

                


                await _UnitOfWork.ExpenseRepository.AddAsync(MappedExpense);

                var count = await _UnitOfWork.CompleteAsync();



                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if(id is null) return BadRequest();

            var Expense = _UnitOfWork.ExpenseRepository.GetAsync(id.Value).Result;

            TempData["ExpenseId"] = (int)Expense.Id;

            var MappedExpense = _Mapper.Map<Expense, ExpenseViewModel>(Expense);

            return View(MappedExpense);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExpenseViewModel expense)
        {

            if (ModelState.IsValid)
            {
                var MappedExpense = _Mapper.Map<ExpenseViewModel, Expense>(expense);

                MappedExpense.Id = (int)TempData["ExpenseId"];



                await _UnitOfWork.ExpenseRepository.UpdateAsync(MappedExpense);



                var Count = await _UnitOfWork.CompleteAsync();
                
                if(Count > 0)return RedirectToAction(nameof(Index));

                else return View(expense);
            }

            return View(expense);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            var Expense = await _UnitOfWork.ExpenseRepository.GetAsync(id.Value);

            var MappedExpense = _Mapper.Map<Expense, ExpenseViewModel>(Expense);

            if (Expense is null) return NotFound();

            return View(MappedExpense);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            
            var Expense = await _UnitOfWork.ExpenseRepository.GetAsync(id.Value);
            
            if (Expense is null) return NotFound();

            await _UnitOfWork.ExpenseRepository.DeleteAsync(Expense);
            
            var Count = await _UnitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
