using Forum_DAL.Entities;
using Forum_DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
       private IUnitOfWork _ADOuow;
        public UserController(ILogger<UserController> logger,
            IUnitOfWork ado_unitofwork)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
        }


        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersAsync()
        {
            try
            {
                var results = await _ADOuow._userRepository.GetAllAsync();
                _ADOuow.Commit();
                _logger.LogInformation($"Отримали всіх користувачів з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }

        }


        //GET: api/events/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _ADOuow._userRepository.GetAsync(id);
                if (result == null)
                {
                    _logger.LogInformation($"User із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали user з бази даних!");
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllEventsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

    }
}
