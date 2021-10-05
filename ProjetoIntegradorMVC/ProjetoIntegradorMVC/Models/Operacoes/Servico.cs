﻿using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Operacoes
{
    [Table("Servico")]
    public class Servico : ClasseBase
    {
        private RepositorioServico _repositorioServico;
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }

        private Servico(){ }

        public Servico(string nome, string descricao, decimal preco)
        {
            ValidarInformacoes(nome, descricao, preco);
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        private Servico AdicionarRepositorio(RepositorioServico repositorioServico)
        {
            _repositorioServico = repositorioServico;
            return this;
        }

        public bool ExisteNoBanco(RepositorioServico repositorioServico)
        {
            AdicionarRepositorio(repositorioServico);
            if (_repositorioServico.BuscarServicoPorNomeEPreco(Nome, Preco) != null) return true;
            return false;
        }

        public void ValidarInformacoes(string nome, string descricao, decimal preco)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O serviço deve ter um nome");
            if (string.IsNullOrWhiteSpace(descricao)) throw new Exception("O serviço deve ter uma descrição");
            if (preco == 0) throw new Exception("O serviço deve ter um preço");
        }
    }
}