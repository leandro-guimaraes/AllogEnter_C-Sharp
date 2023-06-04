namespace Univali.Api.Models
{
    // Classe de modelo para endereço (DTO)
    public class AddressDto
    {
        // Propriedade Id para o identificador do endereço
        public int Id { get; set; }

        // Propriedade Street para a rua do endereço (com valor padrão vazio)
        public string Street { get; set; } = string.Empty;

        // Propriedade City para a cidade do endereço (com valor padrão vazio)
        public string City { get; set; } = string.Empty;
    }
}
