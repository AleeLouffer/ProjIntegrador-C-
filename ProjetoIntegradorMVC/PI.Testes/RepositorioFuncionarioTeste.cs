﻿using Microsoft.EntityFrameworkCore;
using PI.Testes.Helpers;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PI.Testes
{
    public class RepositorioFuncionarioTeste
    {
        private readonly Contexto _contexto;
        private readonly RepositorioFuncionario _repo;
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private Funcionario _funcionario;
        private Funcionario _funcionario2;
        private JornadaDeTrabalho _jornada;
        public RepositorioFuncionarioTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteFuncionarios");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _repo = new RepositorioFuncionario(_contexto);

            var diasDeTrabalho = new List<DiaDaSemana> { new DiaDaSemana("Segunda"), new DiaDaSemana("Terca"), new DiaDaSemana("Quarta"), new DiaDaSemana("Quinta"), new DiaDaSemana("Sexta") };
            var horariosDeTrabalho = new List<Horario> { new Horario("08:00"), new Horario("12:00"), new Horario("13:00"), new Horario("17:00") };
            _jornada = new(diasDeTrabalho, horariosDeTrabalho);

            _funcionario = new("Cleide", "cleide@cleide.com", "123", "59819300045", _jornada);
            _funcionario2 = new("Ravona", "ravona@ravona.com", "ravona@ravona.com", "17159590007", _jornada);
        }

        [Fact]
        public void Deve_retornar_funcionarios_pelas_ids()
        {
            _contexto.Funcionarios.Add(_funcionario);
            _contexto.Funcionarios.Add(_funcionario2);
            _contexto.SaveChanges();
            var ids = new List<int>() { 1, 2 };

            var funcionarios = _repo.BuscarFuncionariosPorIds(ids);

            var funcionariosIds = funcionarios.Select(funcionario => funcionario.Id).ToList();
            Assert.Equal(ids, funcionariosIds);
        }

        [Fact]
        public void Deve_adicionar_os_funcionarios()
        {
            var funcionariosASeremAdicionados = new List<Funcionario> { new Funcionario("Cleido","cleido@cleido.com", "123",  "23882052040", _jornada), 
                new Funcionario("Ravon","ravon@ravon.com", "123", "85769390026", _jornada) };
            _repo.Adicionarfuncionarios(funcionariosASeremAdicionados);
            var funcionariosRetornados = new List<Funcionario>();

            foreach (var funcionario in funcionariosASeremAdicionados)
            {
                funcionariosRetornados.Add(_repo.BuscarFuncionarioPorCpf(funcionario.CPF));
            }

            Assert.Equal(funcionariosASeremAdicionados, funcionariosRetornados);
        }

        [Fact]
        public void Deve_verificar_funcionario_existente()
        {
            _contexto.Funcionarios.Add(_funcionario);
            _contexto.Funcionarios.Add(_funcionario2);
            _contexto.SaveChanges();
            var listaFuncionariosExistentes = new List<Funcionario> {_funcionario, _funcionario2 };

            var funcionarioExiste = _repo.VerificarFuncionarioExistente(listaFuncionariosExistentes[0]);

            Assert.True(funcionarioExiste);
        }

        [Fact]
        public void Nao_deve_adicionar_funcionario_existente()
        {
            const string mensagemEsperada = "O funcionário já existe";
            _contexto.Funcionarios.Add(_funcionario);
            _contexto.Funcionarios.Add(_funcionario2);
            _contexto.SaveChanges();
            var listaFuncionariosExistentes = new List<Funcionario> { _funcionario, _funcionario2 };

            void Acao() => _repo.Adicionarfuncionarios(listaFuncionariosExistentes);

            var mensagem = Assert.Throws<DuplicateNameException>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
