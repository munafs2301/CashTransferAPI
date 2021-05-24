﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CashTransferAPI.Data.Models;
using CashTransferAPI.Enitities;
using CashTransferAPI.Infrastructure.Repositories;
using CashTransferAPI.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<TransactionModel> Post(TransactionModel model)
        {
            try
            {
                var user = _transactionRepo.GetBalance(model.AccountNumber);
                if (user == null)
                {
                    return NotFound("User Account does not exist");
                }

                var beneficiary = _transactionRepo.GetBalance(model.BeneficiaryAccount);
                if (beneficiary == null)
                {
                    return NotFound("Beneficiary Account does not exist");
                }

                if (user.AccountBalance < model.Amount)
                {
                    return BadRequest("You do not have enough cash to make this transfer");
                }


                var transaction = _transactionRepo.MakeTransfer(model, user, beneficiary);

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
            var result = _transactionRepo.Delete(reference);
            if (result == false)
            {
                return BadRequest("This transaction does not exist");
            }
            return Ok("Delete Successful");
        }
    }
}