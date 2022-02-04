using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XbankQuery.Domain.Interfaces;
using XbankQuery.Domain.Models.InputModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XBankQuery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankStatementController : ControllerBase
    {
        private readonly IBankStatementService _bankStatementService;

        public BankStatementController(IBankStatementService bankStatementService)
        {
            _bankStatementService = bankStatementService;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] StatementInputModel statementInputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                return Ok(await _bankStatementService.GetStatement(
                        statementInputModel.Id,
                        statementInputModel.InitialDate,
                        statementInputModel.FinalDate
                    ));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
