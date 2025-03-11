using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Area
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public virtual ICollection<Servico> servicos { get; set; } = new HashSet<Servico>();
        public virtual ICollection<Funcionario> funcionarios { get; set; } = new HashSet<Funcionario>();
    }
}
