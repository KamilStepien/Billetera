using FullRESTAPI.Models.Transactions;
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
    [Authorize]
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

        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetTrasactions(int userId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            IEnumerable<TransactionModel> transactions = _transactionService.GetAll(userId, accessToken);
            
            if (transactions == null)
            {
                return BadRequest(new { message = "Category element  is null or userID == 0" });
            }


            return Ok(transactions);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionModel>> GetTrasaction( int id)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                return Ok(_transactionService.GetTransaction(id, accessToken));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost]
        public ActionResult<TransactionModel> AddTransaction([FromBody]  TransactionAddEditModel model)
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
        public async  Task<ActionResult> DeleteTrasaction(int id)
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                _transactionService.Delete( id, accessToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public ActionResult EditTransaction([FromBody]  TransactionAddEditModel model)
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
