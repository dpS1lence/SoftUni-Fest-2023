﻿using Newtonsoft.Json;

namespace SoftwareFest.Areas.Client.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Mvc;

    using SoftwareFest.Services.Contracts;

    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> Transactions(
            [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than 0")]
            int pageIndex = 1,
            [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than 0")]
            int pageSize = 50)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await _transactionService.GetPagedTransactions(userId, pageIndex, pageSize);

            return Ok(JsonConvert.SerializeObject(model));
        }
    }
}
