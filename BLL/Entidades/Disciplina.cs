using System;
using System.Collections.Generic;
using DAL.Tabelas;
using BLL.Estruturas;

namespace BLL.Entidades
{
    public class Disciplina : IEntidade, IDado
    {
        private int id;
        private string nome;
        private int qtdSemana;
        private Professor professor;
        private int periodo;

        public string ID { get { return this.id == 0 ? "" : this.id.ToString(); } set { this.id = int.Parse(value); } }
        public int Periodo { get { return this.periodo; } }
        public string Nome { get { return this.nome; } }
        public Professor Professor { get { return this.professor; } }

        public int QuantidadeNaSemana { get { return this.qtdSemana; } }

        public Disciplina(string nome, int qtdSemana)
        {
            this.nome = nome;
            this.qtdSemana = qtdSemana;
        }

        public int CompareTo(IDado other)
        {
            if (this.qtdSemana < ((Disciplina)other).QuantidadeNaSemana)
                return -1;
            if (this.qtdSemana > ((Disciplina)other).QuantidadeNaSemana)
                return 1;
            else
                return 0;
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
            throw new NotImplementedException();
        }

        public void RemoverDoBanco()
        {
            throw new NotImplementedException();
        }

        public bool ExisteNoBanco()
        {
            throw new NotImplementedException();
        }
    }
}
