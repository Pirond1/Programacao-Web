﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Funcionario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public decimal salario { get; set; }
        public DateOnly dataNascimento { get; set; }
        public int idArea { get; set; }

        public virtual Area area { get; set; }

        public virtual ICollection<Consulta> consultas { get; set; } = new HashSet<Consulta>();
    }
}
