using AutoMapper;
using ExpenseTracker.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.DAL.Models;
using ExpenseTracker.PL.ViewModels;
using ExpenseTracker.BLL.Repositories;
using System.Linq;
using System.Text.Json;
using System.Linq.Expressions;
using ExpenseTracker.BLL.Specifications;

namespace ExpenseTracker.PL.Controllers
{
    public class BudgetController : BaseController
    {
        public BudgetController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IActionResult> Index()
        {
            var Budgets = await _UnitOfWork.BudgetRepository.GetAllAsync();
            return View(Budgets);
        }


       

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BudgetViewModel budget)
        {

            if (ModelState.IsValid)
            {

                if (budget.Period == "Week") budget.EndDate = budget.StartDate.AddMinutes(2);

                else if(budget.Period == "Month") budget.EndDate = budget.StartDate.AddMonths(1);

                else if(budget.Period == "Year") budget.EndDate = budget.StartDate.AddYears(1);

                var MappedBudget = _Mapper.Map<BudgetViewModel, Budget>(budget);



                


                await _UnitOfWork.BudgetRepository.AddAsync(MappedBudget);

                var Count = await _UnitOfWork.CompleteAsync();

                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index), controllerName: "Budget");
                }
                else
                {
                    return View(budget);
                }
            }


            return View(budget);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if(id is null)return NotFound();


            var Budget = await _UnitOfWork.BudgetRepository.GetAsync(id.Value);

            if (Budget is null) return NotFound();

            await _UnitOfWork.BudgetRepository.DeleteAsync(Budget);

            var Count = await _UnitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index) , controllerName:"Budget");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id is null) return NotFound();

            TempData["Id"] = id.Value;

            var Budget = await _UnitOfWork.BudgetRepository.GetAsync(id.Value);

            if(Budget is null) return NotFound();

            var MappedBudget = _Mapper.Map<Budget, BudgetViewModel>(Budget);

            
            
            return View(MappedBudget);

        }

        [HttpPost]

        public async Task<IActionResult> Edit(BudgetViewModel Budget)
        {

           if(Budget is null) return NotFound();



           var MappedBudget = _Mapper.Map<BudgetViewModel,Budget>(Budget);
            MappedBudget.Accounts = new List<Account>();
            foreach (var Id in Budget.Accounts)
            {
                var Accounts = await _UnitOfWork.AccountRepository.GetAsync(Id);
                MappedBudget.Accounts.Add(Accounts);
            }

            MappedBudget.Id = (int)TempData["Id"];
            

            await _UnitOfWork.BudgetRepository.UpdateAsync(MappedBudget);

            var Count = await _UnitOfWork.CompleteAsync();

            if(Count > 0) return RedirectToAction(nameof(Index) );
            
            return View(Budget);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if(id is null) return NotFound();

            var Budget = await _UnitOfWork.BudgetRepository.GetAsync(id.Value);


            if (Budget is null) return NotFound();

            return View(Budget);

        }


        [HttpPost]
        public async Task<ActionResult> CheckDate()
      {


            var Budgets = await _UnitOfWork.BudgetRepository.GetAllAsync();

            if(Budgets is null) return NotFound();

            foreach(var Budget in Budgets)
            {
                if (DateTime.Now >= Budget.EndDate)
                {

                    switch (Budget.Period)
                    {
                        case "Week":
                            Budget.EndDate = Budget.StartDate.AddDays(7);
                            break;
                        case "Month":
                            Budget.EndDate = Budget.StartDate.AddMonths(1);
                            break;
                        case "Year":
                            Budget.EndDate = Budget.StartDate.AddYears(1);
                            break;
                    }

                    Budget.CurrentAmount = 0;
                    await _UnitOfWork.BudgetRepository.UpdateAsync(Budget);

                }

                await _UnitOfWork.CompleteAsync();
            }


            return Ok();
        }

    }
}
