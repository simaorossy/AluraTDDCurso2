using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Aula.ByteBank.Infraestrutura.Testes.Servico;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit.Abstractions;

namespace Aula.ByteBank.Infraestrutura.Testes
{
    public  class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _agenciaRepositorio;
        public ITestOutputHelper SaidaConsoleTeste { get; set; }

        public AgenciaRepositorioTestes(ITestOutputHelper saidaConsoleTeste) 
        {
            SaidaConsoleTeste = saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor executado");

            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _agenciaRepositorio = provedor.GetService<IAgenciaRepositorio>(); 
        }

        [Fact]
        public void TestaObterTodasAgencias()
        {
            //Act
            List<Agencia> lista = _agenciaRepositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
            Assert.Equal(2, lista.Count);
        }

        [Fact]
        public void TestaObterAgenciaPorId()
        {
            //Arrange

            //Act
            var cliente = _agenciaRepositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterAgenciaPorVariosId(int id)
        {
            //Arrange

            //Act
            var cliente = _agenciaRepositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);
        }

        [Fact]
        public void TestaRemoverInformacaoDeterminadaAgencia()
        {
            //Arrange
            //Act
            var atualizado = _agenciaRepositorio.Excluir(2);

            //Assert
            Assert.True(atualizado);
        }
        
        //TESTANDO EXECOES
        [Fact]
        public void TestaExecaoConsultÀgenciaPorId()
        {
            Assert.Throws<Exception>( () => _agenciaRepositorio.ObterPorId(33));
        }

        [Fact]
        public void TestaObterAgenciaMock()
        {
            //Arrange
            var byteBankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = byteBankRepositorioMock.Object;

            //Act
            var lista = mock.BuscarAgencias();

            //Assert
            byteBankRepositorioMock.Verify(b => b.BuscarAgencias());
        }


    }
}
