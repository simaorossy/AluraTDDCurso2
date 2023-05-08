using Alura.ByteBank.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ByteBank.Infraestrutura.Testes
{
    public class ByteBankContextoTestes
    {
        [Fact]
        public void TestaConexaoContextoComBDMySQL()
        {
            var contexto = new ByteBankContexto();
            bool conectado;

            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch(Exception ex)
            {
                throw new Exception("Não foi possivel conectar a base de dados.");
            }

            Assert.True(conectado);
        }

    }
}
