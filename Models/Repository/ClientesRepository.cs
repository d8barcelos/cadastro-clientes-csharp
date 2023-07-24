using Newtonsoft.Json;

namespace CadastroClientes.Models.Repository
{
    public class ClientesRepository
    {
        public void Salvar(Clientes clientes)
        {
            string clientesTxt = JsonConvert.SerializeObject(clientes) + ',' + Environment.NewLine;
            File.AppendAllText(".//Database//db.txt", clientesTxt);
        }

        public List<Clientes> Listar()
        {
            List<Clientes> ClientesLista = new List<Clientes>();

            // INSTANCIANDO CLIENTE 1
            Clientes cliente = new Clientes();
            cliente.UF = "ES";
            cliente.Fax = "222222";
            cliente.Telefone = "3333333";
            cliente.Documento = "0101010101010101";
            cliente.Email = "vffvf@gmail.com";
            cliente.Nome = "Anderson";
            cliente.Sexo = "Masculino";
            cliente.IdCliente = 12;
            //ADICIONANDO CLIENTE 1
            ClientesLista.Add(cliente);

            // INSTANCIANDO CLIENTE 2
            cliente = new Clientes();
            cliente.UF = "SP";
            cliente.Fax = "1111222";
            cliente.Telefone = "4444443";
            cliente.Documento = "041323723101010101";
            cliente.Email = "enriejhfif@gmail.com";
            cliente.Nome = "Raniel";
            cliente.Sexo = "Masculino";
            cliente.IdCliente = 42;
            //ADICIONANDO CLIENTE 2
            ClientesLista.Add(cliente);

            // INSTANCIANDO CLIENTE 3
            cliente = new Clientes();
            cliente.UF = "PR";
            cliente.Fax = "142423123123";
            cliente.Telefone = "3732323";
            cliente.Documento = "01111111111111";
            cliente.Email = "asasasas@gmail.com";
            cliente.Nome = "Maria";
            cliente.Sexo = "Feminino";
            cliente.IdCliente = 11;
            //ADICIONANDO CLIENTE 3
            ClientesLista.Add(cliente);

            return ClientesLista.OrderByDescending(t=>t.Nome).ToList();
        }
    }
}
