using AutoMapper;
using ExpenseTracker.BLL.Interfaces;
using ExpenseTracker.BLL.Specifications;
using ExpenseTracker.DAL.Models;
using ExpenseTracker.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.PL.Controllers
{
    public class TransferController : BaseController
    {

        public TransferController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<IActionResult> Index()
        {
            var Transfers = await _UnitOfWork.TransferRepository.GetAllAsync();
            return View(Transfers);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransferViewModel transfer)
        {

            if (ModelState.IsValid)
            {
                var MappedTransfer = _Mapper.Map<TransferViewModel,Transfer>(transfer);

                await _UnitOfWork.TransferRepository.AddAsync(MappedTransfer);

                var Count = await _UnitOfWork.CompleteAsync();

                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else return View(transfer);
            }
            return View(transfer);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id is null) return NotFound();

            TempData["Id"] = id.Value;

            var Transfer = await _UnitOfWork.TransferRepository.GetAsync(id.Value);

            if (Transfer is null) return NotFound();

            var MappedTransfer = _Mapper.Map<Transfer, TransferViewModel>(Transfer);


            return View(MappedTransfer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TransferViewModel transfer)
        {
            if (ModelState.IsValid)
            {
                var MappedTransfer = _Mapper.Map<TransferViewModel, Transfer>(transfer);

                MappedTransfer.Id =(int) TempData["Id"];

                await _UnitOfWork.TransferRepository.UpdateAsync(MappedTransfer);

                var Count = await _UnitOfWork.CompleteAsync();
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else return View(transfer);
            }
            return View(transfer);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            var Transfer = await _UnitOfWork.TransferRepository.GetAsync(id.Value);

            var MappedTransfer = _Mapper.Map<Transfer, TransferViewModel>(Transfer);

            if(Transfer is null) return NotFound();

            return View(MappedTransfer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound();
            
            var Transfer = await _UnitOfWork.TransferRepository.GetAsync(id.Value);
            
            if (Transfer is null) return NotFound();
            
            await _UnitOfWork.TransferRepository.DeleteAsync(Transfer);
             
            await _UnitOfWork.CompleteAsync();
             
            return RedirectToAction(nameof(Index));
            
            
        }

    }
}
