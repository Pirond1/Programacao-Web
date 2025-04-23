using InfraEstrutura.Contexto;
using Interfaces.Models;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Projeto_Final.Models;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar o ProjetoClinica no contêiner de Injeção de Dependência
builder.Services.AddDbContext<ContextoClinica>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAreaModels, AreaModels>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();

builder.Services.AddScoped<IClienteModels, ClienteModels>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<IFuncionarioModels, FuncionarioModels>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

builder.Services.AddScoped<IPagamentoModels, PagamentoModels>();
builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();

builder.Services.AddScoped<IServicoModels, ServicoModels>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
