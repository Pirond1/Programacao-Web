using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Servico
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal valorHora { get; set; }
        public int idArea { get; set; }
        public virtual Area area { get; set; }
        public virtual ICollection<Consulta> consultas { get; set; } = new HashSet<Consulta>();
    }
}
