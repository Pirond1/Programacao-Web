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
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private ContextoClinica contexto;

        public FuncionarioRepository(ContextoClinica contexto)
        {
            this.contexto = contexto;
        }

        public Funcionario addFuncionario(Funcionario funcionario)
        {
            this.contexto.Set<Funcionario>().Add(funcionario);
            this.contexto.SaveChanges();
            return funcionario;
        }

        public void delete(int id)
        {
            //recuperei obj da base 
            var obj = this.contexto.Set<Funcionario>().Find(id);
            if (obj != null)
            {
                //excluir
                this.contexto.Set<Funcionario>().Remove(obj);
                this.contexto.SaveChanges();
            }
        }

        public IEnumerable<Funcionario> getAll()
        {
            return this.contexto.Set<Funcionario>().ToList().OrderBy(a => a.nome);
        }

        public Funcionario GetFuncionario(int id)
        {
            return this.contexto.Set<Funcionario>().Find(id);
        }

        public Funcionario recuperar(Func<Funcionario, bool> expressao)
        {
            return this.contexto.Set<Funcionario>().Where(expressao).FirstOrDefault();
        }

        public Funcionario updateFuncionario(Funcionario funcionario)
        {
            var prodaux = contexto.Set<Funcionario>().Find(funcionario.id);



            if (prodaux != null)
            {
                contexto.Entry(prodaux).State = EntityState.Detached;
                this.contexto.Set<Funcionario>().Update(funcionario);
                this.contexto.SaveChanges();
            }


            return funcionario;
        }
    }
}
