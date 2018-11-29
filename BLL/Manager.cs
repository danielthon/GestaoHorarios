using System;
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
        public static bool testing = false;

        private static Usuario logado;
        private static Grafo grade = new Grafo();

        public static Usuario UsuarioLogado { get; set; }

        //public static void CarregarGrafoPeloArquivo(IDado[,] matriz) //teste
        //{
        //    for (int i = 0; i < matriz.GetLength(0); i++)
        //    {
        //        Vertice disc = new Vertice(matriz[i, 0]);
        //        Vertice prof = new Vertice(matriz[i, 1]);
        //        Vertice peri = new Vertice(matriz[i, 2]);

        //        grade.AddVertice(disc);
        //        grade.AddVertice(prof);
        //        grade.AddVertice(peri);

        //        grade.AddAresta(new Aresta(disc, prof));
        //        grade.AddAresta(new Aresta(disc, peri));
        //    }
        //}

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

            foreach (DataRow linha in horarios.Rows)
            {
                // HORARIO

                Horario h = new Horario(
                    (DiaSemana)int.Parse(linha[3].ToString()),
                    DateTime.Parse(linha[1].ToString()) == DateTime.Parse("19:00:00") ? Hora._19h00 : Hora._20h50);

                Vertice vHorario = new Vertice(h);

                grade.AddVertice(vHorario);

                foreach (DataRow linhaAloc in alocacao.Rows)
                {
                    if (linhaAloc[2].ToString() == linha[0].ToString())
                    {
                        Disciplina disc = new Disciplina(int.Parse(linhaAloc[1].ToString()));

                        Vertice vDisciplina = grade.GetVerticePorDado(disc);
                        Vertice vPeriodo = grade.GetVerticePorDado(new Periodo(disc.Periodo));
                        Vertice vProfessor = grade.GetVerticePorDado(new Professor(disc.ID_Professor, 0));

                        grade.AddAresta(new Aresta(vHorario, vDisciplina));
                        grade.AddAresta(new Aresta(vHorario, vPeriodo));
                        grade.AddAresta(new Aresta(vHorario, vProfessor));
                    }
                }
            }
        }

        public static List<Vertice> GetPeriodos()
        {
            List<Vertice> periodos = new List<Vertice>();

            foreach (Vertice v in grade.Vertices)
            {
                if (v.GetDado.GetType() == typeof(Periodo))
                    periodos.Add(v);
            }

            return periodos;
        }

        public static List<Vertice> GetDisciplinasPorPeriodo(Vertice periodo)
        {
            List<Vertice> disciplina = new List<Vertice>();

            foreach (Vertice v in periodo.GetAdjacentes())
            {
                if (v.GetDado.GetType() == typeof(Disciplina))
                    disciplina.Add(v);
            }

            return disciplina;
        }

        public static List<Vertice> GetDisciplinasNaoAlocadasPorPeriodo(Vertice periodo)
        {
            List<Vertice> disciplina = new List<Vertice>();

            foreach (Vertice v in periodo.GetAdjacentes())
            {
                if (v.GetDado.GetType() == typeof(Disciplina))
                {
                    List<Vertice> adjacentes = v.GetAdjacentes();

                    for (int i = 0; i < adjacentes.Count; i++)
                    {
                        if (adjacentes[i].GetDado.GetType() == typeof(Horario))
                            break;
                        else if (i == adjacentes.Count - 1)
                            disciplina.Add(v);
                    }
                }
            }

            return disciplina;
        }

        public static Vertice GetProfessorDeDisciplina(Vertice disciplina)
        {
            foreach (Vertice v in disciplina.GetAdjacentes())
            {
                if (v.GetDado.GetType() == typeof(Professor))
                    return v;
            }

            return null;
        }

        public static Vertice GetDisciplinaAlocada(Vertice periodo, Vertice horario)
        {
            foreach (Vertice v in horario.GetAdjacentes())
            {
                if (v.GetDado.GetType() == typeof(Disciplina))
                {
                    foreach (Vertice p in v.GetAdjacentes())
                    {
                        if (p.GetDado.Equals(periodo.GetDado))
                            return v;
                    }
                }
            }

            return null;
        }

        public static Vertice GetVerticeNaGrade(IDado dado)
        {
            //foreach(Vertice v in Grade.Vertices)
            //{
            //    if (dado.Equals(v.GetDado))
            //        return v;
            //}

            //return null;

            return grade.GetVerticePorDado(dado);
        }

        public static List<Vertice> GetHorarios()
        {
            List<Vertice> horarios = new List<Vertice>();

            foreach (Vertice v in grade.Vertices)
            {
                if (v.GetDado.GetType() == typeof(Horario))
                    horarios.Add(v);
            }

            return horarios;
        }

        public static bool TentarAlocar(Vertice vHorario, Vertice vDisciplina/*, out Alocacao alocacao*/)
        {
            Alocacao alocacao = null;

            if (vHorario.IsAdjacente(vDisciplina.GetAdjacentes()))
                return false;
            else
            {
                Vertice vProfessor = null;
                Vertice vPeriodo = null;

                foreach (Vertice v in vDisciplina.GetAdjacentes())
                {
                    if (v.GetDado.GetType() == typeof(Professor))
                        vProfessor = v;
                    else
                        vPeriodo = v;
                }

                grade.AddAresta(new Aresta(vHorario, vProfessor));
                grade.AddAresta(new Aresta(vHorario, vPeriodo));
                grade.AddAresta(new Aresta(vHorario, vDisciplina));

                alocacao = new Alocacao((Disciplina)vDisciplina.GetDado, (Horario)vHorario.GetDado);

                alocacao.SalvarNoBanco();

                return true;
            }
        }

        public static void Desalocar(Vertice vHorario, Vertice vDisciplina)
        {
            Alocacao alocacao = new Alocacao((Disciplina)vDisciplina.GetDado, (Horario)vHorario.GetDado);

            Vertice vProfessor = null;
            Vertice vPeriodo = null;

            foreach (Vertice v in vDisciplina.GetAdjacentes())
            {
                if (v.GetDado.GetType() == typeof(Professor))
                    vProfessor = v;
                else
                    vPeriodo = v;
            }

            foreach (Aresta a in vHorario.Arestas)
            {
                if (a.Contem(vProfessor) || a.Contem(vPeriodo) || a.Contem(vDisciplina))
                    grade.RemoverAresta(a);
            }

            alocacao.RemoverDoBanco();
        }

        public static bool AbrirConexao(out string mensagemErro)
        {
            if(!testing)
                return Conexao.SetConexao("localhost", "sga", out mensagemErro);
            else
                return Conexao.SetConexao("localhost", "sga_SystemTests", out mensagemErro);
        }
    }
}
