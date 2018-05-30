using System;
using System.Collections.Generic;
using DAL.Tabelas;
using BLL.Estruturas;

namespace BLL.Entidades
{
    public abstract class Usuario : IEntidade, IDado
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
            if (!this.ExisteNoBanco())
                throw new Exception("Usuário já cadastrado com esse Login!");

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

        public virtual void SalvarNoBanco()
        {
            TUsuario tabela = new TUsuario();
            string[] values =
            {
                this.nome,
                this.login,
                this.senha
            };

            if (this.id == 0) //nao possui id, então 'this' ainda nao foi inserido no banco
            {
                string[] valoresChave =
                {
                    this.login
                };

                if (!this.ExisteNoBanco()) 
                    tabela.Insert(values);  // INSERIR
                else
                    tabela.Update(values, this.id); // ALTERAR
            }
            else
                tabela.Update(values, this.id); // ALTERAR
        }

        public abstract void RemoverDoBanco();

        //public virtual void RemoverDoBanco()
        //{
        //    TUsuario tabela = new TUsuario();

        //    if (this.id == 0) //nao possui id, então 'this' ainda nao foi inserido no banco
        //    {
        //        string[] valoresChave =
        //        {
        //            this.login
        //        };

        //        if (!this.ExisteNoBanco())
        //            throw new Exception("Não foi encontrado no banco um registro com esses valores.");
        //        else
        //            tabela.Delete(this.id);  // REMOVE
        //    }
        //    else
        //        tabela.Delete(this.id);  // REMOVE
        //}

        public virtual bool ExisteNoBanco()
        {
            TUsuario tabela = new TUsuario();
            string[] valoresChave =
            {
                this.login
            };

            if (tabela.Exists(valoresChave, out this.id)) //consulta o banco e seta o id se encontrar o registro
                return true;
            else
                return false;
        }
    }
}
