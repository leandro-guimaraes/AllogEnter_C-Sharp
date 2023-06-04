using Microsoft.AspNetCore.Mvc;
using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly Data _data;

        public CustomerController()
        {
            _data = Data.Instance;
        }

        // GET: api/customers/{customerId}/addresses/{addressId}
        [HttpGet("{customerId}/addresses/{addressId}")]
        public IActionResult GetAddress(int customerId, int addressId)
        {
            // Encontra o customer pelo Id
            var customer = _data.Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                return NotFound(); // Retorna 404 Not Found se o customer não existir
            }

            // Encontra o address pelo Id dentro do customer
            var address = customer.Addresses.FirstOrDefault(a => a.Id == addressId);

            if (address == null)
            {
                return NotFound(); // Retorna 404 Not Found se o address não existir
            }

            // Mapeia o address para um AddressDto e retorna como resposta
            var addressDto = new AddressDto
            {
                Id = address.Id,
                Street = address.Street,
                City = address.City
            };

            return Ok(addressDto);
        }

        // POST: api/customers/{customerId}/addresses
        [HttpPost("{customerId}/addresses")]
        public IActionResult AddAddress(int customerId, [FromBody] AddressDto addressDto)
        {
            // Encontra o customer pelo Id
            var customer = _data.Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                return NotFound(); // Retorna 404 Not Found se o customer não existir
            }

            // Cria um novo address com base no AddressDto
            var newAddress = new Address
            {
                Id = GenerateNewAddressId(), // Gera um novo Id para o address
                Street = addressDto.Street,
                City = addressDto.City
            };

            // Adiciona o novo address ao customer
            customer.Addresses.Add(newAddress);

            return Ok(); // Retorna 200 OK
        }

        // PUT: api/customers/{customerId}/addresses/{addressId}
        [HttpPut("{customerId}/addresses/{addressId}")]
        public IActionResult UpdateAddress(int customerId, int addressId, [FromBody] AddressDto addressDto)
        {
            // Encontra o customer pelo Id
            var customer = _data.Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                return NotFound(); // Retorna 404 Not Found se o customer não existir
            }

            // Encontra o address pelo Id dentro do customer
            var address = customer.Addresses.FirstOrDefault(a => a.Id == addressId);

            if (address == null)
            {
                return NotFound(); // Retorna 404 Not Found se o address não existir
            }

            // Atualiza as propriedades do address com base no AddressDto
            address.Street = addressDto.Street;
            address.City = addressDto.City;

            return Ok(); // Retorna 200 OK
        }

        // DELETE: api/customers/{customerId}/addresses/{addressId}
        [HttpDelete("{customerId}/addresses/{addressId}")]
        public IActionResult RemoveAddress(int customerId, int addressId)
        {
            // Encontra o customer pelo Id
            var customer = _data.Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                return NotFound(); // Retorna 404 Not Found se o customer não existir
            }

            // Encontra o address pelo Id dentro do customer
            var address = customer.Addresses.FirstOrDefault(a => a.Id == addressId);

            if (address == null)
            {
                return NotFound(); // Retorna 404 Not Found se o address não existir
            }

            // Remove o address do customer
            customer.Addresses.Remove(address);

            return Ok(); // Retorna 200 OK
        }

        // GET: api/customers/{customerId}/addresses
        [HttpGet("{customerId}/addresses")]
        public IActionResult GetCustomerWithAddresses(int customerId)
        {
            // Encontra o customer pelo Id
            var customer = _data.Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                return NotFound(); // Retorna 404 Not Found se o customer não existir
            }

            // Mapeia o customer e seus addresses para um CustomerWithAddressesDto
            var customerWithAddressesDto = new CustomerWithAddressesDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Cpf = customer.Cpf,
                Addresses = customer.Addresses.Select(a => new AddressDto
                {
                    Id = a.Id,
                    Street = a.Street,
                    City = a.City
                }).ToList()
            };

            return Ok(customerWithAddressesDto);
        }

        // POST: api/customers
        [HttpPost]
        public IActionResult CreateCustomerWithAddresses([FromBody] CustomerWithAddressesDto customerWithAddressesDto)
        {
            // Cria um novo customer com base no CustomerWithAddressesDto
            var newCustomer = new Customer
            {
                Id = GenerateNewCustomerId(), // Gera um novo Id para o customer
                Name = customerWithAddressesDto.Name,
                Cpf = customerWithAddressesDto.Cpf,
                Addresses = customerWithAddressesDto.Addresses.Select(a => new Address
                {
                    Id = GenerateNewAddressId(), // Gera um novo Id para cada address
                    Street = a.Street,
                    City = a.City
                }).ToList()
            };

            // Adiciona o novo customer à lista de customers
            _data.Customers.Add(newCustomer);

            return Ok(); // Retorna 200 OK
        }

        // PUT: api/customers/{customerId}
        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomerWithAddresses(int customerId, [FromBody] CustomerWithAddressesDto customerWithAddressesDto)
        {
            // Encontra o customer pelo Id
            var customer = _data.Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer == null)
            {
                return NotFound(); // Retorna 404 Not Found se o customer não existir
            }

            // Atualiza as propriedades do customer com base no CustomerWithAddressesDto
            customer.Name = customerWithAddressesDto.Name;
            customer.Cpf = customerWithAddressesDto.Cpf;
            customer.Addresses = customerWithAddressesDto.Addresses.Select(a => new Address
            {
                Id = GenerateNewAddressId(), // Gera um novo Id para cada address
                Street = a.Street,
                City = a.City
            }).ToList();

            return Ok(); // Retorna 200 OK
        }

        // Método auxiliar para gerar um novo Id para address
        private int GenerateNewAddressId()
        {
            // Gera um Id único incremental
            return _data.Customers.SelectMany(c => c.Addresses).Max(a => a.Id) + 1;
        }

        // Método auxiliar para gerar um novo Id para customer
        private int GenerateNewCustomerId()
        {
            // Gera um Id único incremental
            return _data.Customers.Max(c => c.Id) + 1;
        }
    }
}
