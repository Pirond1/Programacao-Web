using Interfaces.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoFinal.Configuration;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Controllers
{

    public class FuncionarioController : Controller
    {
        private IFuncionarioModels models;
        private IAreaModels areaModels;

        public FuncionarioController(IFuncionarioModels models, IAreaModels areaModels)
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

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Logout()
        {

            //limpar a sessão
            HttpContext.Session.Remove("nome_usuario");
            HttpContext.Session.Remove("codigo_usuario");
            HttpContext.Session.Clear();

            //redirecionar para login
            return RedirectToAction("Login", "Funcionario");
        }


        [HttpPost]
        public IActionResult Logar(FuncionarioLoginDTO dto)
        {

            //validar Banco de dados
            //model=>repositorio=>banco de dados
            var usuarioDto = models.validarLogin(
                            dto.usuario, dto.senha);

            if (usuarioDto != null)
            {
                //encontrou

                //inserir os dados na sessão
                HttpContext.Session.SetString(
                    "nome_usuario", usuarioDto.nome);
                HttpContext.Session.SetInt32(
                    "codigo_usuario", usuarioDto.id);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //não encontrou
                ViewBag.mensagem = "Dados inválidos";
                return View("Login");
            }


        }

        public IActionResult Cadastrar()
        {
            FuncionarioDTO dto = new FuncionarioDTO();
            dto.id = 0;
            ViewBag.listaArea = carregaListaArea();
            return View(dto);
        }

        [SessionAuthorize]
        public IActionResult Index()
        {
            FuncionarioDTO dto = new FuncionarioDTO();
            dto.id = 0;
            ViewBag.listaArea = carregaListaArea();
            return View(dto);
        }

        [SessionAuthorize]
        public ActionResult Listar()
        {
            var lista = models.getAll();
            return View(lista);
        }

        [SessionAuthorize]
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

        [SessionAuthorize]
        public IActionResult PreAlterar(int id)
        {
            var objDto = this.models.GetFuncionario(id);

            ViewBag.listaArea = carregaListaArea();

            return View("Index", objDto);

        }

        [HttpPost]
        public IActionResult Salvar(FuncionarioDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var produtomesmaDescricao =
                        this.models.recuperar(p => p.usuario == dto.usuario
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
                            " Já existe um Funcionário com esse Usuário";
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

            if (HttpContext.Session.GetString("nome_usuario") != null)
            {
                return View("Index", dto);
            }else
                return View("Cadastrar", dto);

        }
    }
}
