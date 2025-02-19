using Aula2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula2.Controllers
{
    public class UsuárioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar(string usuario, string senha)
        { 
            if (usuario=="admin" && senha=="123456")
                return RedirectToAction("Index", "Pessoa");
            else {
                ViewBag.mensagem = "Dados Inválidos!";
                return View("Index");
            }
                
        }

      
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(UsuárioModels model)
        {
            ViewBag.mensagem = "Dados Salvos com Sucesso! \n Olá " + model.nome;
            return View("Cadastrar");
        }

    }
}
