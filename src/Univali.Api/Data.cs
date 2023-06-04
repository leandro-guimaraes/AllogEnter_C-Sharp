using Univali.Api.Entities;

namespace Univali.Api
{
    // Classe que representa a fonte de dados (simulada) da aplicação
    public class Data
    {
        // Propriedade para armazenar a lista de clientes
        public List<Customer> Customers { get; set; }

        // Propriedade privada que contém a única referência à instância
        private static Data? _instance;

        // Propriedade estática que fornece acesso à instância da classe
        public static Data Instance
        {
            get
            {
                // Assume a instanciação preguiçosa como padrão
                // A instância é criada somente quando necessário e é garantido que haverá apenas uma única instância

                return _instance ??= new Data();
            }
        }

        // Construtor privado e sem parâmetros
        private Data()
        {
            // Inicializa a lista de clientes e seus endereços simulados
            Customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Linus Torvalds",
                    Cpf = "73473943096",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = 1,
                            Street = "Verão do Cometa",
                            City = "Elvira"
                        },
                        new Address
                        {
                            Id = 2,
                            Street = "Borboletas Psicodélicas",
                            City = "Perobia"
                        }
                    }
                },
                new Customer
                {
                    Id = 2,
                    Name = "Bill Gates",
                    Cpf = "95395994076",
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = 3,
                            Street = "Canção Excêntrica",
                            City = "Salandra"
                        }
                    }
                }
            };
        }
    }
}
