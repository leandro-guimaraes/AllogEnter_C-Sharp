namespace Univali.Api.Entities
{
    // Classe de entidade para cliente
    public class Customer
    {
        // Propriedade Id para o identificador do cliente
        public int Id { get; set; }

        // Propriedade Name para o nome do cliente (com valor padrão vazio)
        public string Name { get; set; } = string.Empty;

        // Propriedade Cpf para o CPF do cliente (com valor padrão vazio)
        public string Cpf { get; set; } = string.Empty;

        // Propriedade Addresses para a coleção de endereços do cliente (com uma nova lista vazia como valor padrão)
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
