using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaRemota.Services.Dtos
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public int? TipoClienteId { get; set; }
        public TipoClienteViewModel TipoCliente { get; set; }

        public string Sexo { get; set; }

        public int? SituacaoClienteId { get; set; }
        public SituacaoClienteViewModel SituacaoCliente { get; set; }

    }
}
