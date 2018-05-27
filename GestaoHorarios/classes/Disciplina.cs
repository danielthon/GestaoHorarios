using System;
using System.Collections.Generic;
using GestaoHorarios.classes.estrutura;

namespace GestaoHorarios.classes
{
    class Disciplina : IDado
    {
        //private int id; //?
        private string nome;
        private int qtdSemana;
        //private Professor professor;
        //private int periodo;

        public string Nome { get { return this.nome; } }
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
    }
}
