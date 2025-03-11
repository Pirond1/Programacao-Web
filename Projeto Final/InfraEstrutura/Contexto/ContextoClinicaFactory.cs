using InfraEstrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
public class ContextoClinicaFactory : IDesignTimeDbContextFactory<ContextoClinica>
{
    public ContextoClinica CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ContextoClinica>();
        optionsBuilder.UseSqlServer("Server=PC-SMARTGAMER; Database=ProjetoClinica; integrated security=true; TrustServerCertificate=True");

    return new ContextoClinica(optionsBuilder.Options);
    }
}