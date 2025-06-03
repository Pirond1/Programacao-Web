using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Final.Models;
using ProjetoFinal.Configuration;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Controllers
{
    [SessionAuthorize]
    public class ConsultaController : Controller
    {
        private IConsultaModels models;
        private IFuncionarioModels funcionarioModels;
        private IServicoModels servicoModels;
        private IClienteModels clienteModels;
        private IPagamentoModels pagamentoModels;

        public ConsultaController(IConsultaModels models, IFuncionarioModels funcionarioModels, IServicoModels servicoModels, IClienteModels clienteModels, IPagamentoModels pagamentoModels)
        {
            this.models = models;
            this.funcionarioModels = funcionarioModels;
            this.servicoModels = servicoModels;
            this.clienteModels = clienteModels;
            this.pagamentoModels = pagamentoModels;
        }
        public IActionResult carregaLista()
        {
            ConsultaDTO dto = new ConsultaDTO();
            dto.id = 0;
            dto.dataConsulta = DateTime.Now;

            //obter as areas e retornar para a View
            var listaFuncionario = funcionarioModels.getAll();
            ViewBag.listaFuncionario = listaFuncionario.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.nome
            }).ToList();

            var listaServico = servicoModels.getAll();
            ViewBag.listaServico = listaServico.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            }).ToList();

            var listaCliente = clienteModels.getAll();
            ViewBag.listaCliente = listaCliente.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.nome
            }).ToList();

            var listaPagamento = pagamentoModels.getAll();
            ViewBag.listaPagamento = listaPagamento.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.descricao
            }).ToList();

            return View("Index", dto);
        }

        public IActionResult Index()
        {
            ConsultaDTO dto = new ConsultaDTO();
            dto.id = 0;
            carregaLista();
            return View();
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
            var objDto = this.models.GetConsulta(id);

            ViewBag.listaArea = carregaLista();

            return View("Index", objDto);

        }

        [HttpPost]
        public IActionResult Salvar(ConsultaDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produtomesmaDescricao =
                        this.models.recuperar(p => p.dataConsulta == dto.dataConsulta && p.idFuncionario == dto.idFuncionario
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
                            " Funcionário já selecionado para essa data";
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
