using Microsoft.AspNetCore.Mvc;

namespace Aula1.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Salvar()
        {
            return View();
        }

        public IActionResult Buscar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Salvar1(String nome, String email)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar2()
        {
            return View();
        }
    }
}
