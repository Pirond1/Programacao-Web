using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Controllers
{
    public class PagamentoController : Controller
    {
        public IActionResult Index()
        {
            PagamentoDTO dto = new PagamentoDTO();
            dto.id = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(PagamentoDTO dto)
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
