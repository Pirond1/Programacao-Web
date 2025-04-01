﻿using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.DTOs;

namespace Projeto_Final.Controllers
{
    public class AreaController : Controller
    {
        public IActionResult Index()
        {
            AreaDTO dto = new AreaDTO();
            dto.id = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(AreaDTO dto)
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
