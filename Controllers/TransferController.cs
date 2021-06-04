using AutoMapper;
using CashTransferAPI.Data.Models;
using CashTransferAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace CashTransferAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _link;
        private readonly ITransactionRepository _transactionRepo;

        public TransferController(IMapper mapper, LinkGenerator linkGenerator, ITransactionRepository transactionRepo)
        {
            _mapper = mapper;
            _link = linkGenerator;
            _transactionRepo = transactionRepo;
        }

        [HttpGet]
        public ActionResult<TransactionModel[]> Get()
        {
            var model = _transactionRepo.GetAllTransactions();
            return model;
        }

        [HttpGet("{reference}")]
        public ActionResult<TransactionModel> Get(Guid reference)
        {
            var model = _transactionRepo.GetTransaction(reference);
            return model;
        }

        [HttpPost]
        public async Task<ActionResult<TransactionModel>> Post(TransactionModel model)
        {
            try
            {
                var userAccount = _transactionRepo.GetBalance(model.AccountNumber);
                if (userAccount == null)
                {
                    return NotFound("User Account does not exist");
                }

                var beneficiaryAccount = _transactionRepo.GetBalance(model.BeneficiaryAccount);
                if (beneficiaryAccount == null)
                {
                    return NotFound("Beneficiary Account does not exist");
                }

                if (userAccount.AccountBalance < model.Amount)
                {
                    return BadRequest("You do not have enough cash to make this transfer");
                }


                var transaction = await _transactionRepo.MakeTransfer(model, userAccount, beneficiaryAccount);

                var url = _link.GetPathByAction("Get", "Transfer");

                return Created(url, _mapper.Map<TransactionModel>(transaction));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{reference}")]
        public ActionResult<TransactionModel> Delete(Guid reference)
        {
            var status = _transactionRepo.Delete(reference);
            if (status == false)
            {
                return BadRequest("This transaction does not exist");
            }
            return Ok("Delete Successful");
        }
    }
}
