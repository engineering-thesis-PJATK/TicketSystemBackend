using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneBan_TMS.Interfaces;
using OneBan_TMS.Models;
using OneBan_TMS.Models.DTOs;

namespace OneBan_TMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly OneManDbContext _context;
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(OneManDbContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersList()
        {
            var customers = _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{customerId}")]

        public async Task<ActionResult<Customer>> GetCustomerById(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            if (customer is null)
                return NotFound();
            return Ok(customer);
        }
    }
}