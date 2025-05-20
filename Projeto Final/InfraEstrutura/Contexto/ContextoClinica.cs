using Microsoft.EntityFrameworkCore;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraEstrutura.Contexto
{
    public class ContextoClinica : DbContext
    {
        public ContextoClinica(DbContextOptions<ContextoClinica> options) : base(options)
        {
        }

        protected ContextoClinica()
        {
        }

        public DbSet<Area> areas { get; set; }
        public DbSet<Servico> servicos { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Funcionario> funcionarios { get; set; }
        public DbSet<Pagamento> pagamentos { get; set; }
        public DbSet<ConsultaFuncionario> consultafuncionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server -> LAB10-15 ou PC-SMARTGAMER
            optionsBuilder.UseSqlServer("Server=PC-SMARTGAMER; Database=ProjetoClinica; integrated security=true; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(ent => {
                ent.HasKey(p => p.id);
                ent.ToTable("Area");
                ent.Property(p => p.descricao).HasMaxLength(50);
            });

            modelBuilder.Entity<Servico>(ent =>{
                ent.HasKey(p => p.id);
                ent.ToTable("Serviço");
                ent.Property(p => p.descricao).HasMaxLength(50);
                ent.Property(p => p.valorHora).HasPrecision(8, 2);
                //Relacionamento
                ent.HasOne(p => p.area).WithMany(p => p.servicos).HasForeignKey(p => p.idArea).HasConstraintName("FK_Serviço_Area").OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Cliente>(ent => {
                ent.HasKey(p => p.id);
                ent.ToTable("Cliente");
                ent.Property(p => p.nome).HasMaxLength(50);
                ent.Property(p => p.cpf).HasMaxLength(14);
                ent.Property(p => p.telefone).HasMaxLength(19);
            });

            modelBuilder.Entity<Funcionario>(ent => {
                ent.HasKey(p => p.id);
                ent.ToTable("Funcionario");
                ent.Property(p => p.nome).HasMaxLength(50);
                ent.Property(p => p.salario).HasPrecision(8, 2);
                //Relacionamento
                ent.HasOne(p => p.area).WithMany(p => p.funcionarios).HasForeignKey(p => p.idArea).HasConstraintName("FK_Funcionario_Area").OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Pagamento>(ent => {
                ent.HasKey(p => p.id);
                ent.ToTable("Pagamento");
                ent.Property(p => p.descricao).HasMaxLength(50);
            });

            modelBuilder.Entity<Consulta>(ent => {
                ent.HasKey(p => p.id);
                ent.ToTable("Consulta");
                //Relacionamento
                ent.HasOne(p => p.servico).WithMany(p => p.consultas).HasForeignKey(p => p.idServico).HasConstraintName("FK_Consulta_Serviço").OnDelete(DeleteBehavior.NoAction);
                ent.HasOne(p => p.cliente).WithMany(p => p.consultas).HasForeignKey(p => p.idCliente).HasConstraintName("FK_Consulta_Cliente").OnDelete(DeleteBehavior.NoAction);
                ent.HasOne(p => p.pagamento).WithMany(p => p.consultas).HasForeignKey(p => p.idPagamento).HasConstraintName("FK_Consulta_Pagamento").OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<ConsultaFuncionario>(ent =>
            {
                ent.HasKey(p => new { p.consultaId, p.funcionarioId });
                ent.HasOne(p => p.consulta).WithMany(p => p.consultaFuncionarios).HasForeignKey(p => p.consultaId).HasConstraintName("FK_ConsultaFuncionario_Consulta").OnDelete(DeleteBehavior.NoAction);
                ent.HasOne(p => p.funcionario).WithMany(p => p.consultaFuncionarios).HasForeignKey(p => p.funcionarioId).HasConstraintName("FK_ConsultaFuncionario_Funcionario").OnDelete(DeleteBehavior.NoAction);
            });
            
        }
    }
}
