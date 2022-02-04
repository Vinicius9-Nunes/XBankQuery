using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XbankQuery.Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XBankQuery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankBalanceController : ControllerBase
    {
        private readonly IBankBalanceService _bankBalanceService;

        public BankBalanceController(IBankBalanceService bankBalanceService)
        {
            _bankBalanceService = bankBalanceService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBalanceAccountById(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                return Ok(await _bankBalanceService.GetBalanceAccountById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByCpf/{cpf}")]
        public async Task<IActionResult> GetBalanceAccountByCpf(string cpf)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                return Ok(await _bankBalanceService.GetBalanceAccountByCpf(cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
