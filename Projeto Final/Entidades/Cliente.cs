using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public DateOnly dataNascimento { get; set; }
        public virtual ICollection<Consulta> consultas { get; set; } = new HashSet<Consulta>();
    }
}
