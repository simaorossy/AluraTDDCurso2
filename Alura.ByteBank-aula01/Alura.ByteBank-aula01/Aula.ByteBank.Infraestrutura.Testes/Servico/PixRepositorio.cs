using Aula.ByteBank.Infraestrutura.Testes.Servico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.ByteBank.Infraestrutura.Testes.Servico
{
    public class PixRepositorio : IPixRepositorio
    {

        public List<PixDTO> Pixs { get; set; }

        public PixRepositorio()
        {
            this.Pixs = new List<PixDTO>()
            {
                new PixDTO(){Chave = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),Saldo=10},
                new PixDTO(){Chave = new Guid("1f8fad5b-d9cb-469f-a165-70867728950e"),Saldo=236},
                new PixDTO(){Chave = new Guid("2f8fad5b-d9cb-469f-a165-70867728950e"),Saldo=95},
                new PixDTO(){Chave = new Guid("3f8fad5b-d9cb-469f-a165-70867728950e"),Saldo=14},
                new PixDTO(){Chave = new Guid("4f8fad5b-d9cb-469f-a165-70867728950e"),Saldo=189.87},
                new PixDTO(){Chave = new Guid("5f8fad5b-d9cb-469f-a165-70867728950e"),Saldo=5618.87},
                new PixDTO(){Chave = new Guid("6f8fad5b-d9cb-469f-a165-70867728950e"),Saldo=68},
                new PixDTO(){Chave = new Guid("7f8fad5b-d9cb-469f-a165-70867728950e"),Saldo=195},
                new PixDTO(){Chave = new Guid("8f8fad5b-d9cb-469f-a165-70867728950e"),Saldo=68},
                new PixDTO(){Chave = new Guid("9f8fad5b-d9cb-469f-a165-70867728950e"),Saldo=65719.82}
            };
        }

        public PixDTO ConsultaPix(Guid chave)
        {
            PixDTO dto = (from pix in this.Pixs
                          where pix.Chave == chave
                          select pix).SingleOrDefault();
            return dto;
        }
    }
}
