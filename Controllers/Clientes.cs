﻿using CadastroClientes.Models;
using CadastroClientes.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost("Salvar")]

        public object Salvar([FromBody] Clientes cadastro)
        {
            try
            {

            }
            catch (Exception ex)
            { 

            }
            return null;
        }

        [HttpPost("Alterar")]

        public object Alterar([FromBody] Clientes cadastro)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return null;
        }

        [HttpGet("Listar")]

        public object Listar()
        {
            List<Clientes> listaCli = null;
            ClientesRepository clientesRepo = new ClientesRepository();
            listaCli = clientesRepo.Listar();
            return listaCli;
        }


        [HttpDelete("Deletar")]
        public object Excluir(int IdCliente)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
