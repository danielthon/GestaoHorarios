using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using BLL.Entidades;
using BLL.Estruturas;

namespace UTL.TestesUnitarios
{
    [TestClass]
    public class TestManager
    {
        //public TestManager()
        //{
        //    string errMsg;
        //    Manager.AbrirConexao(out errMsg);
        //    Manager.CarregarGrafoPeloBanco();
        //}

        [TestMethod]
        public void TentarAlocar()
        {
            Disciplina d = new Disciplina(0);
            Horario h = new Horario(DiaSemana.Quarta, Hora._20h50);

            Vertice vDisciplina = new Vertice(d);
            Vertice vHorario = new Vertice(h);

            Assert.AreEqual(true, Manager.TentarAlocar(vHorario, vDisciplina), "Erro nçao identificado!");
        }

        private static Grafo grade = new Grafo();

        [TestMethod]
        public void GetPeriodo()
        {

            // linhas que coloquei para testar o método inicia aqui
            grade = new Grafo();
            Periodo p = new Periodo(5);
            grade.Vertices.Add(null);
            //até aqui 

            string msgErro = "Dado inválido";
            List<Vertice> periodos = new List<Vertice>();
            Manager.CarregarGrafoPeloBanco();
            Assert.AreEqual(periodos, Manager.GetPeriodos(), msgErro);
        }
    }
}
