using Azure.Core;
using Mc2.CrudTest.Core.DTOs;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Queries;
using Mc2.CrudTest.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Mc2.CrudTest.Presentation.Server.Controllers.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [ActionName("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var query = new GetAllCustomersQuery();
                var customers = await _mediator.Send(query);
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customers.");
                return StatusCode(500, "An error occurred while retrieving customers.");
            }
        }

        [HttpGet("{customerId}")]
        [ActionName("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            try
            {
                var query = new GetCustomerByIdQuery { CustomerId = customerId };
                var customer = await _mediator.Send(query);

                if (customer == null)
                {
                    return NotFound($"Customer with ID {customerId} not found.");
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the customer.");
                return StatusCode(500, "An error occurred while retrieving the customer.");
            }
        }

        [HttpPost]
        [ActionName("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerWriteDTO customer)
        {
            try
            {
                // Validate input data
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                    return BadRequest(errors);
                }

                var command = new CreateCustomerCommand(customer.Firstname, customer.Lastname, customer.DateOfBirth, customer.PhoneNumber, customer.Email, customer.BankAccountNumber);
                var createdCustomer = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetCustomerById), new { customerId = createdCustomer.Id }, createdCustomer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the customer.");
                return StatusCode(500, "An error occurred while creating the customer.");
            }
        }
        [HttpPut("{customerId}")]
        [ActionName("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerWriteDTO customer)
        {
            try
            {
                var bankAccountNumber = new BankAccountNumber(customer.BankAccountNumber);

                var command = new UpdateCustomerCommand(customerId, customer.Firstname, customer.Lastname, customer.DateOfBirth, customer.PhoneNumber, customer.Email, bankAccountNumber);
                await _mediator.Send(command);

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the customer.");
                return StatusCode(500, "An error occurred while updating the customer.");
            }
        }

        [HttpDelete("{customerId}")]
        [ActionName("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            try
            {
                var command = new DeleteCustomerCommand(customerId);
                await _mediator.Send(command);

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the customer.");
                return StatusCode(500, "An error occurred while deleting the customer.");
            }
        }
    }
}