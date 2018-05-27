using System;
using System.Collections.Generic;
using GestaoHorarios.classes.estrutura;

namespace GestaoHorarios.classes
{
    class Usuario : IDado
    {
        //private int id; //?
        private string nome;

        public string Nome { get { return this.nome; } }

        public Usuario(string nome)
        {
            this.nome = nome;
        }

        public int CompareTo(IDado other)
        {
            throw new NotSupportedException();
        }

        public bool Equals(IDado other)
        {
            if (this.Equals((Professor)other)) //cast para lançar exceção
                return true;
            else
                return false;
        }
    }
}
