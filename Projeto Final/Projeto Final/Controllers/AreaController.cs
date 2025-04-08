using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Controllers
{
    public class AreaController : Controller
    {
        private IAreaModels models;

        public AreaController(IAreaModels models)
        {
            this.models = models;
        }

        public IActionResult Index()
        {
            AreaDTO dto = new AreaDTO();
            dto.id = 0;
            return View(dto);
        }

        public ActionResult Listar()
        {
            var lista = models.getAll();
            return View(lista);
        }

        [HttpPost]
        public IActionResult Salvar(AreaDTO dto)
        {
            try
            {           
                if (ModelState.IsValid)
                {
                    dto = this.models.save(dto);
                    ViewBag.classe = "text-success";
                    ViewBag.mensagem = "Dados salvos com sucesso!";
                }
                else
                {
                    ViewBag.classe = "text-danger";
                    ViewBag.mensagem = "Não foi possível salvar os dados!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.classe = "alert-danger";
                ViewBag.mensagem = "Erro ao salvar os dados!" + ex.Message;
            }

            return View("Index", dto);
        }
    }
}
