namespace Univali.Api.Models
{
    // Classe de modelo para cliente com endereços (DTO)
    public class CustomerWithAddressesDto
    {
        // Propriedade Id para o identificador do cliente
        public int Id { get; set; }

        // Propriedade Name para o nome do cliente (com valor padrão vazio)
        public string Name { get; set; } = string.Empty;

        // Propriedade Cpf para o CPF do cliente (com valor padrão vazio)
        public string Cpf { get; set; } = string.Empty;

        // Propriedade Addresses para os endereços do cliente
        public ICollection<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    }
}
