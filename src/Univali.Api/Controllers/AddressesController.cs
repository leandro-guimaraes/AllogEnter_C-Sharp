using Microsoft.AspNetCore.Mvc;
using Univali.Api.Models;

namespace Univali.Api.Controllers
{
    [ApiController]
    [Route("api/customers/{customerId}/addresses")]
    public class AddressController : ControllerBase
    {
        // Método de solicitação GET para obter uma lista de endereços de um cliente específico
        [HttpGet]
        public ActionResult<IEnumerable<AddressDto>> GetAddresses(int customerId)
        {
            // Procura o cliente no banco de dados com base no customerId fornecido
            var customerFromDatabase = Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId);

            // Verifica se o cliente existe
            if (customerFromDatabase == null)
                return NotFound(); // Retorna um resultado HTTP 404 (Not Found) se o cliente não existir

            // Lista para armazenar os endereços convertidos em AddressDto
            var addressesToReturn = new List<AddressDto>();

            // Percorre os endereços do cliente e converte-os em AddressDto
            foreach (var address in customerFromDatabase.Addresses)
            {
                addressesToReturn.Add(new AddressDto
                {
                    Id = address.Id,
                    Street = address.Street,
                    City = address.City
                });
            }

            // Retorna os endereços em formato JSON com um resultado HTTP 200 (OK)
            return Ok(addressesToReturn);
        }

        // Método de solicitação GET para obter um endereço específico de um cliente
        [HttpGet("{addressId}")]
        public ActionResult<AddressDto> GetAddress(int customerId, int addressId)
        {
            // Obtém o endereço correspondente ao customerId e addressId fornecidos
            var addressToReturn = Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId)
                ?.Addresses.FirstOrDefault(address => address.Id == addressId);

            // Verifica se o endereço existe
            if (addressToReturn != null)
                return Ok(addressToReturn); // Retorna o endereço em formato JSON com um resultado HTTP 200 (OK)
            else
                return NotFound(); // Retorna um resultado HTTP 404 (Not Found) se o endereço não existir
        }
    }
}
