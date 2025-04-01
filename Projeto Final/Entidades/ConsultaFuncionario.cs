using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ConsultaFuncionario
    {
        public int consultaId { get; set; }
        public int funcionarioId { get; set; }

        public virtual Consulta consulta { get; set; }
        public virtual Funcionario funcionario { get; set; }
    }

}
