namespace Univali.Api.Models
{
    // Classe de modelo para atualização de cliente (DTO)
    public class CustomerForUpdateDto
    {
        // Propriedade Id para o identificador do cliente
        public int Id { get; set; }

        // Propriedade Name para o nome do cliente (com valor padrão vazio)
        public string Name { get; set; } = string.Empty;

        // Propriedade Cpf para o CPF do cliente (com valor padrão vazio)
        public string Cpf { get; set; } = string.Empty;
    }
}
