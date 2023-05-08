using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Aula.ByteBank.Infraestrutura.Testes
{
    public  class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteRepositorioTestes() 
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _clienteRepositorio = provedor.GetService<IClienteRepositorio>(); 
        }

        [Fact]
        public void TestaObterTodosClientes()
        {

            //Act
            List<Cliente> lista = _clienteRepositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
            Assert.Equal(3, lista.Count);
        }

        [Fact]
        public void TestaObterClientePorId()
        {
            //Arrange

            //Act
            var cliente = _clienteRepositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterClientePorVariosId(int id)
        {
            //Arrange

            //Act
            var cliente = _clienteRepositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);
        }

    }
}
