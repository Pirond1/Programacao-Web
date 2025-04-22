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
    public class ClienteRepository : IClienteRepository
    {
        private ContextoClinica contexto;

        public ClienteRepository(ContextoClinica contexto)
        {
            this.contexto = contexto;
        }

        public Cliente addCliente(Cliente cliente)
        {
            this.contexto.Set<Cliente>().Add(cliente);
            this.contexto.SaveChanges();
            return cliente;
        }

        public void delete(int id)
        {
            //recuperei obj da base 
            var obj = this.contexto.Set<Cliente>().Find(id);
            if (obj != null)
            {
                //excluir
                this.contexto.Set<Cliente>().Remove(obj);
                this.contexto.SaveChanges();
            }
        }

        public IEnumerable<Cliente> getAll()
        {
            return this.contexto.Set<Cliente>().ToList().OrderBy(c => c.cpf);
        }

        public Cliente GetCliente(int id)
        {
            return this.contexto.Set<Cliente>().Find(id);
        }

        public Cliente recuperar(Func<Cliente, bool> expressao)
        {
            return this.contexto.Set<Cliente>().Where(expressao).FirstOrDefault();
        }

        public Cliente updateCliente(Cliente cliente)
        {
            var prodaux = contexto.Set<Cliente>().Find(cliente.id);



            if (prodaux != null)
            {
                contexto.Entry(prodaux).State = EntityState.Detached;
                this.contexto.Set<Cliente>().Update(cliente);
                this.contexto.SaveChanges();
            }


            return cliente;
        }
    }
}
