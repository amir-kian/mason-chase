using Microsoft.AspNetCore.Mvc;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Service.Interfaces;

namespace Mc2.CrudTest.Presentation.Server.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _customerService.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "An error occurred while retrieving customers.");
            }
        }

        [HttpGet("{customerId}")]
        public IActionResult GetCustomerById(int customerId)
        {
            try
            {
                var customer = _customerService.GetCustomerById(customerId);
                if (customer == null)
                {
                    return NotFound($"Customer with ID {customerId} not found.");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An error occurred while retrieving the customer.");
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                // Validate input data
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                    return BadRequest(errors);
                }

        var createdCustomer = _customerService.CreateCustomer(
          customer.Firstname,
          customer.Lastname,
          customer.DateOfBirth,
          customer.PhoneNumber,
          customer.Email,
          customer.BankAccountNumber
      );

                return CreatedAtAction(nameof(GetCustomerById), new { customerId = createdCustomer.Id }, createdCustomer);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                // logger.LogError(ex, "An error occurred while creating the customer.");

                return StatusCode(500, "An error occurred while creating the customer.");
            }
        }

        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer(int customerId, [FromBody] Customer customer)
        {
            try
            {
                var existingCustomer = _customerService.GetCustomerById(customerId);
                if (existingCustomer == null)
                {
                    return NotFound($"Customer with ID {customerId} not found.");
                }

                _customerService.UpdateCustomer(customerId, customer.Firstname, customer.Lastname, customer.DateOfBirth, customer.PhoneNumber, customer.Email, customer.BankAccountNumber);
                return NoContent();
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "An error occurred while updating the customer.");
            }
        }

        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            try
            {
                var existingCustomer = _customerService.GetCustomerById(customerId);
                if (existingCustomer == null)
                {
                    return NotFound($"Customer with ID {customerId} not found.");
                }

                _customerService.DeleteCustomer(customerId);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                // Return an appropriate error response
                return StatusCode(500, "An error occurred while deleting the customer.");
            }
        }
    }
}

