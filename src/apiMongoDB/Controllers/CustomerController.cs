using System.Net;
using System.Reflection.Metadata;
using apiMongoDB.Models;
using apiMongoDB.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly AddressService _addressService;
        private readonly CityService _cityService;

        public CustomerController(CustomerService customerService, AddressService addressService, CityService cityService)
        {
            _customerService = customerService;
            _addressService = addressService;
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get() => _customerService.Get();

        [HttpGet("{id:length(24)}", Name ="GetCustomer")]
       
        public ActionResult<Customer>Get(string id)
        {
            var customer = _customerService.Get(id);

            if (customer == null) return NotFound();

            return customer;
        }


        [HttpPost]

        public ActionResult<Customer> Create(Customer customer)
        {
            if (customer.Address.City.Id != String.Empty)
                customer.Address.City = _cityService.Get(customer.Address.City.Id);
            else
                customer.Address.City = _cityService.Create(customer.Address.City);

            if (customer.Address.Id != String.Empty)
                customer.Address =_addressService.Get(customer.Address.Id);
            else
                customer.Address =_addressService.Create(customer.Address);

            return _customerService.Create(customer);
        }

        [HttpPut("{id:length(24)}")]

        public ActionResult Update (string id, Customer customer)
        {
            var cust = _customerService.Get(id);
            if (cust == null) return NotFound();
            _customerService.Update(id, customer);

            return Ok();
        }

        [HttpDelete("{id:length(24)}")]

        public ActionResult Delete (string id)
        {
            if (id == null) return NotFound();

            var customer = _customerService.Get(id);
            if(customer == null) return NotFound();
            _customerService.Delete(id);
            return Ok();
        }


    }
}
