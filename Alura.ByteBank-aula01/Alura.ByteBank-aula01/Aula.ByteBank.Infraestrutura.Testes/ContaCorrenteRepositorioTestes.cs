using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Aula.ByteBank.Infraestrutura.Testes.Servico;
using Aula.ByteBank.Infraestrutura.Testes.Servico.DTO;
using Microsoft.Extensions.DependencyInjection;
using Moq;

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


        [Fact]
        public void TestaConsultaPix()
        {
            //Arrange
            var guid = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e");
            var pix = new PixDTO() {Chave = guid, Saldo = 10 };

            var pixRepositorioMock = new Mock<IPixRepositorio>();
            pixRepositorioMock.Setup(x => x.ConsultaPix(It.IsAny<Guid>())).Returns(pix);

            var mock = pixRepositorioMock.Object;

            //Act
            var saldo = mock.ConsultaPix(guid).Saldo;



            //Assert
            Assert.Equal(10, saldo);


        }

    }
}
