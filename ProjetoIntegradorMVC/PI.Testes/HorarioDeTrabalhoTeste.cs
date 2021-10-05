﻿using ExpectedObjects;
using ProjetoIntegradorMVC.Models;
using System;
using System.Globalization;
using Xunit;

namespace PI.Testes
{
    public class HorarioDeTrabalhoTeste
    {
        [Fact]
        public void Deve_criar_um_horario_de_trabalho()
        {
            var horario = DateTime.ParseExact("13:00", "HH:mm", CultureInfo.InvariantCulture);

            var horarioDeTrabalho = new HorarioDeTrabalho("13:00");

            Assert.Equal(horario, horarioDeTrabalho.Horario);
        }
    }
}