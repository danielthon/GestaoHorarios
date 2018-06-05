using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Estruturas;
using BLL.Entidades;

namespace GestaoHorarios
{
    public static class Utils
    {
        public static Grafo grafo;

        public static Grafo Grafo { get { return grafo; } }

        static void GerarGrade()
        {
            Grafo g = new Grafo();

            string nomeProfessor = "Caram";
            string nomeDisciplina = "POO";
            int periodo = 2;
            int qtdSemana = 2;

            g.AddVertice(new Vertice(new Professor(nomeProfessor, nomeProfessor, nomeProfessor)));
            g.AddVertice(new Vertice(new Disciplina(nomeDisciplina, qtdSemana)));
            g.AddVertice(new Vertice(new Periodo(periodo)));
        }
    }
}
