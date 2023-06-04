namespace Univali.Api.Models
{
    // Classe de modelo para atualização parcial de cliente (DTO)
    public class CustomerForPatchDto
    {
        // Propriedade Name para o nome do cliente (com valor padrão vazio)
        public string Name { get; set; } = string.Empty;

        // Propriedade Cpf para o CPF do cliente (com valor padrão vazio)
        public string Cpf { get; set; } = string.Empty;
    }
}
