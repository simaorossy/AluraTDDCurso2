using Aula.ByteBank.Infraestrutura.Testes.Servico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ByteBank.Infraestrutura.Testes.Servico
{
    public interface IPixRepositorio
    {
        public PixDTO ConsultaPix(Guid pix);
    }

}
