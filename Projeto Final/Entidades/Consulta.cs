using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Consulta
    {
        public int id { get; set; }
        public int horas { get; set; }
        public DateTime dataConsulta { get; set; }
        public decimal valorTotal { get; set; }
        public int idServico { get; set; }
        public int idCliente { get; set; }
        public int idPagamento { get; set; }

        public virtual ICollection<ConsultaFuncionario> consultaFuncionarios { get; set; }

        public virtual Servico servico { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual Pagamento pagamento { get; set; }
    }
}
