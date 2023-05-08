using Alura.ByteBank.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ByteBank.Infraestrutura.Testes.Servico
{
    internal class ByteBankRepositorio : IByteBankRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente
            {
                Nome = "Bruce Kent",
                CPF = "486.074.980-45",
                Identificador = Guid.NewGuid(),
                Profissao = "Empresario",
                Id = 1
            },
            new Cliente
            {
                Nome ="Maria",
                CPF = "877.288.430-44",
                Identificador = Guid.NewGuid(),
                Profissao = "pm",
                Id = 2
            },
            new Cliente
            {
                Nome ="Helio",
                CPF = "743.062.450-20",
                Identificador = Guid.NewGuid(),
                Profissao = "jogador",
                Id = 2
            }
        };



        public List<Agencia> BuscarAgencias()
        {
            throw new NotImplementedException();
        }

        public List<Cliente> BuscarClientes()
        {
            return clientes;
        }

        public List<ContaCorrente> BuscarContasCorrentes()
        {
            throw new NotImplementedException();
        }
    }
}
