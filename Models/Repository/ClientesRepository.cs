﻿using Newtonsoft.Json;

namespace CadastroClientes.Models.Repository
{
    public class ClientesRepository
    {
        public void Salvar(Clientes clientes)
        {
            var listaClientes = Listar();
            var clienteExistente = listaClientes.FirstOrDefault(t => t.Documento == clientes.Documento);

            if (clienteExistente != null)
            {
                // Atualize os detalhes do cliente existente
                clienteExistente.Nome = clientes.Nome;
                clienteExistente.Email = clientes.Email;
                clienteExistente.Telefone = clientes.Telefone;
                clienteExistente.Fax = clientes.Fax;
                clienteExistente.UF = clientes.UF;
                clienteExistente.Sexo = clientes.Sexo;
            }
            else
            {
                // O cliente não existe na lista, então adicione-o
                listaClientes.Add(clientes);
            }


            var clientesTxt = JsonConvert.SerializeObject(clientes) + ',' + Environment.NewLine;
            File.AppendAllText(".//Database//db.txt", clientesTxt);
        }


        public List<Clientes> Listar()
        {
            var clientes = File.ReadAllText(".//Database//db.txt");
            var listaClientes = JsonConvert.DeserializeObject<List<Clientes>>("["+clientes+"]");

            return listaClientes.OrderByDescending(t=>t.Nome).ToList();
        }

        public bool Deletar(string Documento)
        {
            // LISTAR ITENS
            var listaClientes = Listar();

            // ENCONTRAR O ITEM
            var item = listaClientes.Where(t => t.Documento == Documento).FirstOrDefault();

            if(item != null)
            {
                // REMOVER ITEM DA LISTA
                listaClientes.Remove(item);

                // LIMPAR DB
                File.WriteAllText(".//Database//db.txt", string.Empty);

                // REESCREVER LISTA NO DB
                foreach(var cliente in listaClientes) 
                {
                    Salvar(cliente);
                }
                return true;
            }
            return false;
        }

        public Clientes GetClientes(String Documento)
        {
            var clienteLista = Listar();
            var item = clienteLista.Where(t => t.Documento == Documento).FirstOrDefault();

            return item;
        } 
    }
}
