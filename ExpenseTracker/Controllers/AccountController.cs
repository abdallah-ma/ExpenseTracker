using ExpenseTracker.BLL.Repositories;
using ExpenseTracker.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.DAL.Models;
using ExpenseTracker.PL.ViewModels;
using AutoMapper;
using ExpenseTracker.BLL.Specifications;

namespace ExpenseTracker.PL.Controllers
{
    public class AccountController : BaseController
    {


        public AccountController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        [HttpGet]

        public async Task<IActionResult> Index(){
            
            var Accounts = await _UnitOfWork.AccountRepository.GetAllAsync();
            return View(Accounts);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountViewModel account)
        {
            if (ModelState.IsValid)
            {
                var MappedAccount = _Mapper.Map<AccountViewModel,Account>(account);


                await _UnitOfWork.AccountRepository.AddAsync(MappedAccount);

                var count = await _UnitOfWork.CompleteAsync();

                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
                
            
            if (id is null) return BadRequest();

            var Account = await _UnitOfWork.AccountRepository.GetAsync(id.Value);
           

            if(Account == null)return NotFound();

            var MappedAccount = _Mapper.Map<Account, AccountViewModel>(Account);

            return View(MappedAccount);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();


            TempData["id"] = id;

            var Account = await _UnitOfWork.AccountRepository.GetAsync(id.Value);

            if (Account == null) return NotFound();

            var MappedAccount = _Mapper.Map<Account, AccountViewModel>(Account);

             

            return View(MappedAccount);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(AccountViewModel account)
        {

            if (ModelState.IsValid)
            {

                

                var MappedAccount = _Mapper.Map<AccountViewModel, Account>(account);

                MappedAccount.Id = (int)TempData["Id"];

                await _UnitOfWork.AccountRepository.UpdateAsync(MappedAccount);

                var Count = await _UnitOfWork.CompleteAsync();

                if (Count > 0) return RedirectToAction(nameof(Index));

                return View(account);
            }

            return RedirectToAction(nameof(Index));
        }


        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound(); 

            var Account = await _UnitOfWork.AccountRepository.GetAsync(id.Value);

            if (Account == null) return NotFound();

            await _UnitOfWork.AccountRepository.DeleteAsync(Account);

            await _UnitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index) , controllerName:"Account");
        }

       


    }

    

}
