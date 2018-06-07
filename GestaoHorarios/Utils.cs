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
        public static Grafo grade;

        public static Grafo Grade { get { return grade; } }

        public static void MontarDisciplinas(IDado[,] arquivo)
        {
            for (int i = 0; i < arquivo.GetLength(0); i++)
            {
                Disciplina di = (Disciplina)arquivo[i, 0];
                Professor pr = (Professor)arquivo[i, 0];
                Periodo pe = (Periodo)arquivo[i, 0];
            }




            Grafo g = new Grafo();

            //string nomeProfessor = "Caram";
            //string nomeDisciplina = "POO";
            //int periodo = 2;
            //int qtdSemana = 2;

            //g.AddVertice(new Vertice(new Professor(nomeProfessor, nomeProfessor, nomeProfessor)));
            //g.AddVertice(new Vertice(new Disciplina(nomeDisciplina, qtdSemana)));
            //g.AddVertice(new Vertice(new Periodo(periodo)));
        }

        public static bool TentarAlocar(Vertice vHorario, Vertice vDisciplina, out Alocacao alocacao)
        {
            alocacao = null;

            if (vHorario.IsAdjacente(vDisciplina.GetAdjacentes()))
                return false;
            else
            {
                Vertice vProfessor = vDisciplina.GetAdjacentes()[0];
                Vertice vPeriodo = vDisciplina.GetAdjacentes()[1];

                Grade.AddAresta(new Aresta(vHorario, vProfessor));
                Grade.AddAresta(new Aresta(vHorario, vPeriodo));
                Grade.AddAresta(new Aresta(vHorario, vDisciplina));

                alocacao = new Alocacao((Disciplina)vDisciplina.GetDado, (Horario)vHorario.GetDado);

                return true;
            }
        }
    }
}
