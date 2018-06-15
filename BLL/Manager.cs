﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entidades;
using BLL.Estruturas;
using DAL.Tabelas;
using DAL.MySQL;
using System.Data;

namespace BLL
{
    public static class Manager
    {
        public static Grafo grade = new Grafo();

        public static Grafo Grade { get { return grade; } }

        public static void CarregarGrafoPeloArquivo(IDado[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                Vertice disc = new Vertice(matriz[i, 0]);
                Vertice prof = new Vertice(matriz[i, 1]);
                Vertice peri = new Vertice(matriz[i, 2]);

                grade.AddVertice(disc);
                grade.AddVertice(prof);
                grade.AddVertice(peri);

                grade.AddAresta(new Aresta(disc, prof));
                grade.AddAresta(new Aresta(disc, peri));
            }
        }

        public static void CarregarGrafoPeloBanco()
        {
            DataTable disciplinas = (new TDisciplina()).SelectAll();
            DataTable horarios = (new THorario()).SelectAll();
            DataTable alocacao = (new TAlocacao()).SelectAll();

            grade = new Grafo();

            foreach (DataRow linha in disciplinas.Rows)
            {
                // DISCIPLINA

                Disciplina d = new Disciplina(linha[2].ToString(), int.Parse(linha[3].ToString()), int.Parse(linha[1].ToString()));
                Vertice vDisciplina = new Vertice(d);
                grade.AddVertice(vDisciplina);

                // PERIODO

                Periodo p = new Periodo(int.Parse(linha[1].ToString()));
                Vertice vPeriodo = grade.GetVerticePorDado(p);

                if (vPeriodo == null)
                {
                    vPeriodo = new Vertice(p);
                    grade.AddVertice(vPeriodo);
                }

                // PROFESSOR

                DataRow linhap = (new TProfessor()).Select(linha[3].ToString()); //uma consulta por inserção de disciplina é muito. Otimizar isso depois

                Professor f = new Professor(int.Parse(linhap[0].ToString()), int.Parse(linhap[1].ToString()));
                Vertice vProfessor = grade.GetVerticePorDado(f);

                if (vProfessor == null)
                {
                    vProfessor = new Vertice(f);
                    grade.AddVertice(vProfessor);
                }

                grade.AddAresta(new Aresta(vDisciplina, vPeriodo));
                grade.AddAresta(new Aresta(vDisciplina, vProfessor));
            }

            foreach(DataRow linha in horarios.Rows)
            {
                // HORARIO

                Horario h = new Horario(
                    (DiaSemana)int.Parse(linha[3].ToString()), 
                    DateTime.Parse(linha[1].ToString()) == DateTime.Parse("19:00:00") ? Hora._19h00 : Hora._20h50);

                Vertice vHorario = new Vertice(h);

                grade.AddVertice(vHorario);

                foreach (DataRow linhaAloc in alocacao.Rows)
                {
                    if(linhaAloc[2].ToString() == linha[0].ToString())
                    {
                        Disciplina disc = new Disciplina(int.Parse(linhaAloc[1].ToString()));

                        Vertice vDisciplina = grade.GetVerticePorDado(disc);
                        Vertice vPeriodo = grade.GetVerticePorDado(new Periodo(disc.Periodo));

                        grade.AddAresta(new Aresta(vHorario, vDisciplina));
                        grade.AddAresta(new Aresta(vHorario, vPeriodo));
                    }
                }
            }
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

        public static bool AbrirConexao(out string mensagemErro)
        {
            return Conexao.SetConexao("localhost", "sga", out mensagemErro);
        }
    }
}
