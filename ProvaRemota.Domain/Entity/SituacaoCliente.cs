using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaRemota.Domain.Entity
{
    public class SituacaoCliente
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public SituacaoCliente()
        {
                
        }
        public SituacaoCliente(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

    }
}
