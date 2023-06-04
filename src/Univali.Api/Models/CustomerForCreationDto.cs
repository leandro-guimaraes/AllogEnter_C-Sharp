using System.ComponentModel.DataAnnotations;

namespace Univali.Api.Models
{
    // Classe de modelo para criação de cliente (DTO)
    public class CustomerForCreationDto
    {
        // Propriedade Name para o nome do cliente (com valor padrão vazio)
        [Required(ErrorMessage = "You should fill out a Name")]
        [MaxLength(100, ErrorMessage = "The name shouldn't have more than 100 characters")]
        public string Name { get; set; } = string.Empty;

        // Propriedade Cpf para o CPF do cliente (com valor padrão vazio)
        [Required(ErrorMessage = "You should fill out a Cpf")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "The Cpf should have 11 characters")]
        public string Cpf { get; set; } = string.Empty;
    }
}
