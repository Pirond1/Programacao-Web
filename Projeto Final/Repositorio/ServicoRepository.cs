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
    public class ServicoRepository : IServicoRepository
    {
        private ContextoClinica contexto;

        public ServicoRepository(ContextoClinica contexto)
        {
            this.contexto = contexto;
        }

        public Servico addServico(Servico servico)
        {
            this.contexto.Set<Servico>().Add(servico);
            this.contexto.SaveChanges();
            return servico;
        }

        public void delete(int id)
        {
            //recuperei obj da base 
            var obj = this.contexto.Set<Servico>().Find(id);
            if (obj != null)
            {
                //excluir
                this.contexto.Set<Servico>().Remove(obj);
                this.contexto.SaveChanges();
            }
        }

        public IEnumerable<Servico> getAll()
        {
            return this.contexto.Set<Servico>().ToList().OrderBy(a => a.descricao);
        }

        public Servico GetServico(int id)
        {
            return this.contexto.Set<Servico>().Find(id);
        }

        public Servico recuperar(Func<Servico, bool> expressao)
        {
            return this.contexto.Set<Servico>().Where(expressao).FirstOrDefault();
        }

        public Servico updateServico(Servico servico)
        {
            var prodaux = contexto.Set<Servico>().Find(servico.id);



            if (prodaux != null)
            {
                contexto.Entry(prodaux).State = EntityState.Detached;
                this.contexto.Set<Servico>().Update(servico);
                this.contexto.SaveChanges();
            }


            return servico;
        }
    }
}
