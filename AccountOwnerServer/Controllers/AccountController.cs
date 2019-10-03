using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Entities.Extensions;


namespace AccountOwnerServer.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repositry;

        public AccountController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repositry = repository;
        }

        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            try
            {
                var Accounts = _repositry.Acccount.GetAllAccount();

                _logger.LogInfo($"returned all account from database");

                return Ok(Accounts);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something Went wrong .{ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAccountById(Guid id)
        {
            try
            {
                var account = _repositry.Acccount.GetAccountById(id);
                if(account.IsEmptyObject())
                {
                    _logger.LogInfo($"Owner with id :{ id} Not Found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Owner with id :{ id} Found");
                    return Ok(account);
                }
            }
            catch(Exception ex)
            {
                _logger.LogInfo($"Something went wrong {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
       
    }
}