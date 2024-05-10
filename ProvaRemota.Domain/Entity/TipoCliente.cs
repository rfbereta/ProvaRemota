using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProvaRemota.Domain.Entity
{
    public class TipoCliente
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public TipoCliente()
        {
                
        }
        public TipoCliente(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

    }
}
