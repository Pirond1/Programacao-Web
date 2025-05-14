using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Configuration;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Controllers
{
    [SessionAuthorize]
    public class ConsultaController : Controller
    {
        public IActionResult Index()
        {
            ConsultaDTO dto = new ConsultaDTO();
            dto.id = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(ConsultaDTO dto)
        {
            if (ModelState.IsValid)
            {
                // executar model (salvar)
                ViewBag.classe = "text-success";
                ViewBag.mensagem = "Dados salvos com sucesso!";
            }
            else
            {
                ViewBag.classe = "text-danger";
                ViewBag.mensagem = "Não foi possível salvar os dados!";
            }

            return View("Index", dto);
        }
    }
}
