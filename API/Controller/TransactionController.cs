using System.Threading.Tasks;
using API.DTOs;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        //GET: api/Transaction/GetAllTransactions
        [HttpGet]
        [Route("GetAllTransactions")]
        public async Task<ActionResult<TransactionModel>> GetAllTransactions()
        {
            var transactions = await _transactionRepository.GetAllTransactions();
            if (transactions is null)
            {
                return NotFound();
            }
            return Ok(transactions);
        }

        //GET: api/Transaction/GetTransactionById/{id}
        [HttpGet]
        [Route("GetTransactionById/{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var transaction = await _transactionRepository.GetTransactionById(id);
            if (transaction is null)
            {
                return NotFound($"Item with the Id {id} was not found!");
            }
            return Ok(transaction);
        }

        //GET: api/Transaction/GetTransactionsByUserId/{id}
        [HttpGet]
        [Route("GetTransactionsByUserId/{id}")]
        public async Task<IActionResult> GetTransactionsByUserId(int id)
        {
            var transactions = await _transactionRepository.GetTransactionsByUserId(id);
            if (transactions is null)
            {
                return NotFound($"Item with the Id {id} was not found!");
            }
            return Ok(transactions);
        }

        //POST: api/Transaction/CreateTransaction
        [HttpPost]
        [Route("CreateTransaction")]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionDto transaction)
        {
            if (transaction is null)
            {
                return BadRequest();
            }
            
            var result = await _transactionRepository.CreateTransaction(transaction);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        //PUT: api/Transaction/UpdateTransaction
        [HttpPut]
        [Route("UpdateTransaction")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] TransactionDto transaction)
        {
            if (transaction is null)
            {
                return BadRequest();
            }

            var result = await _transactionRepository.UpdateTransaction(id, transaction);
            
            if (result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        //DELETE: api/Transaction/DeleteTransaction/{id}
        [HttpDelete]
        [Route("DeleteTransaction/{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var result = await _transactionRepository.DeleteTransaction(id);
            if (result is null)
            {
                return NotFound($"Item with the Id {id} was not found!");
            }
            return Ok(result);
        }
    }
}