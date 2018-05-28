using System;
using System.Collections.Generic;
using GestaoHorarios.classes.estrutura;

namespace GestaoHorarios.classes
{
    class Usuario : IDado
    {
        protected int id;
        protected string nome;
        protected string login;
        protected string senha;

        public virtual string ID { get { return this.id == 0 ? "" : this.id.ToString(); } set { this.id = int.Parse(value); } }
        public string Nome { get { return this.nome; } }
        public string Login { get { return this.login; } }
        public string Senha { get { return this.senha; } }

        public Usuario(string nome, string login, string senha)
        {
            this.nome = nome;
            this.login = login;
            this.senha = senha;
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
