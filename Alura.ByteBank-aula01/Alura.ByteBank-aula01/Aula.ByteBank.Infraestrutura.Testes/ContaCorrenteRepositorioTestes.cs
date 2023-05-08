using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Aula.ByteBank.Infraestrutura.Testes
{
    public  class ContaCorrenteRepositorioTestes
    {
        private readonly IContaCorrenteRepositorio _ContaCorrenteRepositorio;
        public ContaCorrenteRepositorioTestes() 
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _ContaCorrenteRepositorio = provedor.GetService<IContaCorrenteRepositorio>(); 
        }


        [Fact]
        public void TestaObterContaCorretnePorId()
        {
            //Arrange

            //Act
            var cliente = _ContaCorrenteRepositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterContaCorretnePorVariosId(int id)
        {
            //Arrange

            //Act
            var cliente = _ContaCorrenteRepositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);
        }

        [Fact]
        public void TestaAtualizaSaldoDeterminadaConta()
        {
            //arrange
            var conta = _ContaCorrenteRepositorio.ObterPorId(1);

            double saldoNovo = 15;
            conta.Saldo = saldoNovo;

            //act
            var atualizado = _ContaCorrenteRepositorio.Atualizar(1, conta);

            //assert
            Assert.True(atualizado);

        }

        [Fact]
        public void TestaInsereUmaNovaContaCorrenteNoBancoDeDados()
        {
            //Arrange
            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Kent Nelson",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Bancario",
                    Id = 1
                },
                Agencia = new Agencia()
                {
                    Nome = "Agencia Central Coast City",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua das flores",
                    Numero = 147
                }
            };


            //Act
            var retorno = _ContaCorrenteRepositorio.Adicionar(conta);


            //Assert
            Assert.True(retorno);
        }
    
    }
}
