using System;
using System.Collections.Generic;
using DAL.Tabelas;
using BLL.Estruturas;
using System.Data;

namespace BLL.Entidades
{
    public class Disciplina : IEntidade, IDado
    {
        private int id;
        private string nome;
        //private int qtdSemana;
        private int id_professor;
        private int periodo;

        //public string ID { get { return this.id == 0 ? "" : this.id.ToString(); } set { this.id = int.Parse(value); } }
        public int ID { get { return this.id; } }
        public int Periodo { get { return this.periodo; } }
        public string Nome { get { return this.nome; } }
        public int ID_Professor { get { return this.id_professor; } }

        //public int QuantidadeNaSemana { get { return this.qtdSemana; } }

        public Disciplina(string nome, int id_professor, int periodo/*, int qtdSemana*/)
        {
            this.nome = nome;
            this.id_professor = id_professor;
            this.periodo = periodo;
            //this.qtdSemana = qtdSemana;

            this.id = 0;
            this.ExisteNoBanco(); //verifica se existe, se sim, seta o id
        }

        public Disciplina(int id, string nome, int id_professor, int periodo/*, int qtdSemana*/)
        {
            this.nome = nome;
            this.id_professor = id_professor;
            this.periodo = periodo;
            //this.qtdSemana = qtdSemana;

            this.id = id;
        }

        public Disciplina(int id) { this.CarregaAtributos(id); }

        public int CompareTo(IDado other)
        {
            throw new NotSupportedException();
        }

        public bool Equals(IDado other)
        {
            if (this.Equals((Disciplina)other)) //cast para lançar exceção
                return true;
            else
                return false;
        }

        public void SalvarNoBanco()
        {
            TDisciplina tabela = new TDisciplina();

            string[] values =
            {
                this.periodo.ToString(),
                this.nome,
                this.id_professor.ToString()
            };

            if (this.id == 0) //nao possui id, então 'usuario' ainda nao foi inserido no banco
            {
                tabela.Insert(values);  // INSERIR

                if (!this.ExisteNoBanco()) //usuario
                    throw new Exception("Dado não inserido no banco!");
            }
            else
            {
                tabela.Update(values, this.id);  // ALTERAR
            }
        }

        public void RemoverDoBanco()
        {
            throw new NotImplementedException();
        }

        public bool ExisteNoBanco()
        {
            string[] valoresChave =
            {
                this.nome
            };

            if ((new TDisciplina()).Exists(valoresChave, out this.id)) //consulta o banco e seta o id se encontrar o registro
                return true;
            else
                return false;
        }

        public bool CarregaAtributos(int id)
        {
            DataRow linha = (new TDisciplina()).Select(id.ToString());

            if (linha == null)
                return false;
            else
            {
                this.id = id;
                this.periodo = int.Parse(linha[1].ToString());
                this.nome = linha[2].ToString();
                this.id_professor = int.Parse(linha[3].ToString());

                return true;
            }
        }

        public DataTable TodosT()
        {
            return (new TDisciplina()).SelectAll();
        }

        public List<IEntidade> Todos()
        {
            List<IEntidade> lista = new List<IEntidade>();

            foreach (DataRow dr in TodosT().Rows)
                lista.Add(new Disciplina(int.Parse(dr[0].ToString()), dr[1].ToString(), int.Parse(dr[2].ToString()), int.Parse(dr[3].ToString())));

            return lista;
        }
    }
}
