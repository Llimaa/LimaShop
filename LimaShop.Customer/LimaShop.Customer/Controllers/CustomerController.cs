using LimaShop.Customer.Application.Commands.InputModels;
using LimaShop.Customer.Application.Queries;
using LimaShop.Customer.Application.Queries.GetById;
using LimaShop.Customer.Application.Queries.GetByName;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LimaShop.Customer.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCustomerQuery();
            var customers = await _mediator.Send(query);

            if (customers == null)
                return NotFound();

            return Ok(customers);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetByIdCustomerQuery(id);
            var customers = await _mediator.Send(query);

            if (customers == null)
                return NotFound();

            return Ok(customers);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var query = new GetByNameCustomerQuery(name);
            var customers = await _mediator.Send(query);

            if (customers == null)
                return NotFound();

            return Ok(customers);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateCustomer command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { Id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCustomer customer)
        {
            customer.CustomerId = id;
            await _mediator.Send(customer);
            return NoContent();
        }

        [HttpPut("update-with-address/{id}")]
        public async Task<IActionResult> PutWithAddress(Guid id, [FromBody] UpdateCustomerWithAddress customerWithAddress)
        {
            customerWithAddress.CustomerId = id;
            await _mediator.Send(customerWithAddress);
            return NoContent();
        }

        [HttpPatch("update/address/{id}")]
        public async Task<IActionResult> PutAddressCustomer(Guid id, UpdateAddressCustomer customer)
        {
            customer.CustomerId = id;
            await _mediator.Send(customer);
            return NoContent();
        }

        [HttpPatch("active/{id}")]
        public async Task<IActionResult> ActiveCustomer(Guid id)
        {
            var activeCustomer = new ActiveCustomer(id);
            await _mediator.Send(activeCustomer);
            return NoContent();
        }

        [HttpPatch("desactive/{id}")]
        public async Task<IActionResult> DesactiveCustomer(Guid id)
        {
            var activeCustomer = new DesactiveCustomer(id);
            await _mediator.Send(activeCustomer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteCustomer = new DeleteCustomer(id);
            var isDeleted = await _mediator.Send(deleteCustomer);

            if (isDeleted == false)
                return NotFound(isDeleted);

            return Ok(isDeleted);

        }
    }
}
