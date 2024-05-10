using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaRemota.Domain.Entity
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public int? TipoClienteId { get; set; }
        public TipoCliente TipoCliente { get; set; }

        public string Sexo { get; set; }

        public int? SituacaoClienteId { get; set; }
        public SituacaoCliente SituacaoCliente { get; set; }

        public Cliente()
        {

        }
        public Cliente(int id, string nome, string cpf, TipoCliente tipoCliente, string sexo, SituacaoCliente situacaoCliente)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            TipoCliente = tipoCliente;
            TipoClienteId = TipoCliente?.Id;
            Sexo = sexo;
            SituacaoCliente = situacaoCliente;
            SituacaoClienteId = situacaoCliente?.Id;
        }
    }

}
