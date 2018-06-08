using System;
using System.Collections.Generic;
using DAL.Tabelas;
using BLL.Estruturas;
using System.Data;

namespace BLL.Entidades
{
    public abstract class Usuario : IEntidade
    {
        protected int id_usuario;
        protected string nome;
        protected string login;
        protected string senha;

        //public virtual string ID { get { return this.id_usuario == 0 ? "" : this.id_usuario.ToString(); } set { this.id_usuario = int.Parse(value); } }
        public virtual int ID { get { return this.id_usuario; } }
        public string Nome { get { return this.nome; } }
        public string Login { get { return this.login; } }
        public string Senha { get { return this.senha; } }

        public Usuario(string nome, string login, string senha)
        {
            this.nome = nome;
            this.login = login;
            this.senha = senha;

            this.ExisteNoBanco(); //verifica se existe, se sim, seta o id
        }

        public Usuario(int id)
        {
            this.CarregaAtributos(id);
        }

        public abstract void SalvarNoBanco();

        //public virtual void SalvarNoBanco()
        //{
        //    TUsuario tabela = new TUsuario();
        //    string[] values =
        //    {
        //        this.nome,
        //        this.login,
        //        this.senha
        //    };

        //    if (this.id == 0) //nao possui id, então 'this' ainda nao foi inserido no banco
        //    {
        //        string[] valoresChave =
        //       {
        //            this.login
        //        };

        //        if (!this.ExisteNoBanco()) 
        //            tabela.Insert(values);  // INSERIR
        //        else
        //            tabela.Update(values, this.id); // ALTERAR
        //    }
        //    else
        //        tabela.Update(values, this.id); // ALTERAR
        //}

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

            if (tabela.Exists(valoresChave, out this.id_usuario)) //consulta o banco e seta o id se encontrar o registro
                return true;
            else
                return false;
        }

        public bool CarregaAtributos(int id)
        {
            DataRow linha = (new TUsuario()).Select(id.ToString());

            if (linha == null)
                return false;
            else
            {
                this.id_usuario = id;
                this.nome = linha[1].ToString();
                this.login = linha[2].ToString();
                this.senha = linha[3].ToString();

                return true;
            }
        }
    }
}
