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
    public class PagamentoRepository : IPagamentoRepository
    {
        private ContextoClinica contexto;

        public PagamentoRepository(ContextoClinica contexto)
        {
            this.contexto = contexto;
        }

        public Pagamento addPagamento(Pagamento pagamento)
        {
            this.contexto.Set<Pagamento>().Add(pagamento);
            this.contexto.SaveChanges();
            return pagamento;
        }

        public void delete(int id)
        {
            //recuperei obj da base 
            var obj = this.contexto.Set<Pagamento>().Find(id);
            if (obj != null)
            {
                //excluir
                this.contexto.Set<Pagamento>().Remove(obj);
                this.contexto.SaveChanges();
            }
        }

        public IEnumerable<Pagamento> getAll()
        {
            return this.contexto.Set<Pagamento>().ToList().OrderBy(a => a.descricao);
        }

        public Pagamento GetPagamento(int id)
        {
            return this.contexto.Set<Pagamento>().Find(id);
        }

        public Pagamento recuperar(Func<Pagamento, bool> expressao)
        {
            return this.contexto.Set<Pagamento>().Where(expressao).FirstOrDefault();
        }

        public Pagamento updatePagamento(Pagamento pagamento)
        {
            var prodaux = contexto.Set<Pagamento>().Find(pagamento.id);



            if (prodaux != null)
            {
                contexto.Entry(prodaux).State = EntityState.Detached;
                this.contexto.Set<Pagamento>().Update(pagamento);
                this.contexto.SaveChanges();
            }


            return pagamento;
        }
    }
}
