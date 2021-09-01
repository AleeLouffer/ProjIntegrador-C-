﻿using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorio_Servico _repositorioServico;
        private readonly IRepositorio_Funcionario _repositorioFuncionario;
        private readonly IRepositorio_FuncionariosComServicos _repositorioFuncComServicos;

        public HomeController(IRepositorio_Servico repositorioServico, IRepositorio_Funcionario repositorioFuncionario, IRepositorio_FuncionariosComServicos repositorioFuncComServicos)
        {
            _repositorioServico = repositorioServico;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioFuncComServicos = repositorioFuncComServicos;
        }

        public IActionResult Home()
        {
            return View(_repositorioServico.GetServicos());
        }

        public IActionResult Servico(int id)
        {
            var servicoDTO = _repositorioServico.GetServico(id);
            var idsFuncionario = _repositorioFuncComServicos.ListarFuncionariosID(id);
            var funcionarios = _repositorioFuncionario.GetFuncionario(idsFuncionario);

            var DTO = new DTOServicos(servicoDTO, funcionarios);
            return View(DTO);
        }
    }
}
