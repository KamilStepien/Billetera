﻿using FullRESTAPI.Models.Transactions;
using FullRESTAPI.Models.Users;
using FullRESTAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {

        private ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }


        [HttpGet("user/{userId}")]
        public ActionResult<IEnumerable<TransactionModel>> GetTrasactions(int userId)
        {
            try
            {
                IEnumerable<TransactionModel> transactions = _transactionService.GetAll(userId);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }


        [HttpGet("user/{userId}/chardata")]
        public ActionResult<IEnumerable<object>> GetTrasactionsChartData(int userId)
        {
            try
            {
                List<TransactionChartData> date = new List<TransactionChartData>();

                _transactionService.GetAll(userId).Where(x => x.CreateDate.Month == DateTime.Now.Month).GroupBy(x => x.CreateDate).ToList().ForEach(
                    x =>
                    {
                        int income = 0;
                        int expense = 0;
                        x.ToList().ForEach(y =>
                        {
                            if (y.IsExpense)
                                expense += y.Amount;
                            else
                                income += y.Amount;
                        }
                        );
                        date.Add(new TransactionChartData { Date = x.Key, AmountIncome = income, AmountExpense = expense });
                    });


                return Ok(date);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public ActionResult<TransactionModel> GetTrasaction(int id)
        {
            try
            {
                return Ok(_transactionService.GetTransaction(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost]
        public ActionResult<TransactionModel> AddTransaction([FromBody] TransactionAddModel model)
        {
            try
            {
                return Ok(_transactionService.Add(model));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTrasaction(int id)
        {
            try
            {
                _transactionService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public ActionResult<TransactionModel> EditTransaction([FromBody] TransactionEditModel model)
        {
            try
            {
                return Ok(_transactionService.Edit(model));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
