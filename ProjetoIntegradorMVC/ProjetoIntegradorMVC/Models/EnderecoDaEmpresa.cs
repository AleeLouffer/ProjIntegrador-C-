﻿using Caelum.Stella.CSharp.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Models
{
    [Owned]
    public class EnderecoDaEmpresa : ObjetoDeValor
    {
        public string CEP { get; }
        public string Logradouro { get; }
        public string Complemento { get; }
        public string Bairro { get; }
        public string Localidade { get; }
        public string UF { get; }

        protected EnderecoDaEmpresa() { }

        public EnderecoDaEmpresa(string cep)
        {
            var endereco = new ViaCEP().GetEndereco(cep);
            CEP = endereco.CEP;
            Logradouro = endereco.Logradouro;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Localidade = endereco.Localidade;
            UF = endereco.UF;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CEP;
            yield return Logradouro;
            yield return Complemento;
            yield return Bairro;
            yield return Localidade;
            yield return UF;
        }
    }
}