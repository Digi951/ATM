using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controller
{
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        //GET: api/Transaction/GetTransactionById/{id}
        [HttpGet]
        [Route("GetTransactionById/{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var transaction = await _transactionRepository.GetTransactionById(id);
            if (transaction is null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }
    }
}