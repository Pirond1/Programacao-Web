using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Controllers
{
    public class ServicoController : Controller
    {
        private IServicoModels models;
        private IAreaModels areaModels;

        public ServicoController(IServicoModels models, IAreaModels areaModels)
        {
            this.models = models;
            this.areaModels = areaModels;
        }

        public IEnumerable<SelectListItem> carregaListaArea()
        {
            //obter as areas e retornar para a View
            var listaArea = areaModels.getAll();

            return listaArea.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            });
        }

        public IActionResult Index()
        {
            ServicoDTO dto = new ServicoDTO();
            dto.id = 0;
            ViewBag.listaArea = carregaListaArea();
            return View(dto);
        }

        public ActionResult Listar()
        {
            var lista = models.getAll();
            return View(lista);
        }

        public ActionResult Excluir(int id)
        {

            try
            {
                this.models.delete(id);
                ViewBag.mensagem = "Exclusão efetuada com sucesso!";
                ViewBag.classe = "alert-success";
            }
            catch (Exception ex)
            {

                ViewBag.mensagem = "Não foi possível excluir o item!";
                ViewBag.classe = "alert-danger";
            }

            var lista = models.getAll();
            return View("Listar", lista);


            //redirecionando pra a action (metodo) Listar
            // return RedirectToAction("Listar");
        }

        public IActionResult PreAlterar(int id)
        {
            var objDto = this.models.GetServico(id);

            ViewBag.listaArea = carregaListaArea();

            return View("Index", objDto);

        }

        [HttpPost]
        public IActionResult Salvar(ServicoDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produtomesmaDescricao =
                        this.models.recuperar(p => p.descricao == dto.descricao
                                                   && ((p.id != dto.id && dto.id != 0)
                                                            || dto.id == 0));

                    if (produtomesmaDescricao == null)
                    {
                        // executar model (salvar)
                        dto = this.models.save(dto);
                        ViewBag.classe = "alert-success";
                        ViewBag.mensagem = "Dados salvos com sucesso!";
                    }
                    else
                    {
                        ViewBag.classe = "alert-danger";
                        ViewBag.mensagem = "Não foi possível salvar!" +
                            " Já existe um Serviço com essa Descrição";
                    }
                }
                else
                {
                    ViewBag.classe = "alert-danger";
                    ViewBag.mensagem = "Não foi possível salvar os dados!";
                }
            }
            catch (Exception ex)
            {

                ViewBag.classe = "alert-danger";
                ViewBag.mensagem = "Erro ao salvar os dados! " +
                    ex.Message;
            }

            ViewBag.listaArea = carregaListaArea();

            return View("Index", dto);
        }
    }
}
