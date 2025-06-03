using Entidades;
using InfraEstrutura.Contexto;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private ContextoClinica contexto;

        public ConsultaRepository(ContextoClinica contexto)
        {
            this.contexto = contexto;
        }

        public Consulta addConsulta(Consulta consulta)
        {
            this.contexto.Set<Consulta>().Add(consulta);
            this.contexto.SaveChanges();
            return consulta;
        }

        public void delete(int id)
        {
            //recuperei obj da base 
            var obj = this.contexto.Set<Consulta>().Find(id);
            if (obj != null)
            {
                //excluir
                this.contexto.Set<Consulta>().Remove(obj);
                this.contexto.SaveChanges();
            }
        }

        public IEnumerable<Consulta> getAll()
        {
            return this.contexto.Set<Consulta>().ToList().OrderBy(a => a.id);
        }

        public Consulta GetConsulta(int id)
        {
            return this.contexto.Set<Consulta>().Find(id);
        }

        public Consulta recuperar(Func<Consulta, bool> expressao)
        {
            return this.contexto.Set<Consulta>().Where(expressao).FirstOrDefault();
        }

        public Consulta updateConsulta(Consulta consulta)
        {
            var prodaux = contexto.Set<Consulta>().Find(consulta.id);



            if (prodaux != null)
            {
                contexto.Entry(prodaux).State = EntityState.Detached;
                this.contexto.Set<Consulta>().Update(consulta);
                this.contexto.SaveChanges();
            }


            return consulta;
        }
    }
}
