using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using Entities.Models;
using Entities.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountOwnerServer.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repositry;

        public OwnerController(ILoggerManager logger, IRepositoryWrapper repoistry)
        {
            _logger = logger;
            _repositry = repoistry;
        }

        [HttpGet]
        public ActionResult GetAllOwner()
        {
            try
            {
                var owners = _repositry.Owner.GetAllOwner();

                _logger.LogInfo($"Returnrd all Owner from Database");

                return Ok(owners);
            }
            catch (Exception ex)
            {
                _logger.LogInfo($"Something went wrong inside GetAllOwner :{ex.Message}");

                return StatusCode(500, "Internal Status Error");
            }
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public IActionResult GetOwnerById(Guid id)
        {
            try
            {
                var owner = _repositry.Owner.GetOwnerById(id);
                if (owner.IsEmptyObject())
                {
                    _logger.LogInfo($"Owner with id :{ id} Not Found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Owner with Id ,{id}");
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{Id}/account")]
        public IActionResult GetOwnerWithDetail(Guid Id)
        {
            try
            {
                var owner = _repositry.Owner.GetOwnerWithDetails(Id);
                if (owner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {Id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with details for id: {Id}");
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateNewOwner([FromBody] Owner owner)
        {
            try
            {
                if (owner.IsObjectNull())
                {
                    _logger.LogError("Owner Object Sent to the method is Empty");
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }
                _repositry.Owner.CreateOwner(owner);
                _repositry.Save();

                return CreatedAtRoute("OwnerById", new { id = owner.Id }, owner);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]

        public IActionResult UpdateOwner(Guid id,[FromBody] Owner owner)
        {
            try
            {
                if(owner.IsObjectNull())
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if(!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                var dbOwner = _repositry.Owner.GetOwnerById(id);
                if(dbOwner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id {id} no found.");
                    return NotFound();
                }

                _repositry.Owner.UpdateOwner(dbOwner, owner);
                _repositry.Save();

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError("Owner object sent from client is null.");
                return BadRequest("Owner object is null");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            try
            {
                var dbOwner = _repositry.Owner.GetOwnerById(id);
                if (dbOwner.IsEmptyObject())
                {
                    _logger.LogError($"owner with id {id} not found");
                    return BadRequest("owner not found");
                }

                if(_repositry.Acccount.AccountByOwner(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                }
                _repositry.Owner.DeleteOwner(dbOwner);
                _repositry.Save();

                return NoContent();

            }
               
            catch(Exception ex)
            {
                _logger.LogError($"SomeThing went Wrong inside the DeleteOwner Method {ex.Message} ");

                return StatusCode(500, "Something Went Wrong");
            }
        }
    }
}