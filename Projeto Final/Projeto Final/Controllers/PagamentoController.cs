using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Controllers
{
    public class PagamentoController : Controller
    {
        private IPagamentoModels models;

        public PagamentoController(IPagamentoModels models)
        {
            this.models = models;
        }
        public IActionResult Index()
        {
            PagamentoDTO dto = new PagamentoDTO();
            dto.id = 0;
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
            var objDto = this.models.GetPagamento(id);
            return View("Index", objDto);

        }

        [HttpPost]
        public IActionResult Salvar(PagamentoDTO dto)
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
                            " Já existe uma Forma de Pagamento com esta Descrição";
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

            return View("Index", dto);
        }
    }
}
