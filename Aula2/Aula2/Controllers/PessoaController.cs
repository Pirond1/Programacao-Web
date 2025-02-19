using Microsoft.AspNetCore.Mvc;

namespace Aula2.Controllers
{
    public class PessoaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View(); 
        }
    }
}
