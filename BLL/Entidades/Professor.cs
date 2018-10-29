﻿using System;
using System.Collections.Generic;
using DAL.Tabelas;
using BLL.Estruturas;
using System.Data;

namespace BLL.Entidades
{
    public class Professor : Usuario, IDado//, IEntidade
    {
        int id_prof;

        public override int ID { get { return this.id_prof; } }
        public int ID_Usuario { get { return this.id_usuario; } }

        public Professor(string login, string senha) : base(login, senha)
        {
            this.ExisteNoBanco(); //verifica se existe, se sim, seta o id
        }

        public Professor(string nome, string login, string senha) : base (nome, login, senha) { this.ExisteNoBanco(); } //verifica se existe, se sim, seta o id

        public Professor(int id_prof, int id_usuario) : base(id_usuario) { this.id_prof = id_prof; }

        public Professor(int id_usuario, int id_prof, string nome, string login, string senha) : base(id_usuario, nome, login, senha) { this.id_prof = id_prof; }

        public int CompareTo(IDado other)
        {
            Professor aux = (Professor)other;
            if (aux.nome == this.nome)
            {
                return 0;
            }
            return -1;
        }

        public bool Equals(IDado other)
        {
            if (other.GetType() != typeof(Professor))
                return false;

            if (((Professor)other).ID != 0 && this.id_prof != 0)
            {
                if (((Professor)other).ID == this.id_prof)
                    return true;
                else
                    return false;
            }
            else
            {
                if (((Professor)other).Login == this.login)
                    return true;
                else
                    return false;
            }
        }

        public override void SalvarNoBanco()
        {
            TUsuario tabelaU = new TUsuario();
            string[] valuesU =
            {
                this.nome,
                this.login,
                this.senha
            };

            TProfessor tabelaP = new TProfessor();
            string[] valuesP =
            {
                this.id_usuario.ToString()
            };

            if (this.id_usuario == 0) //nao possui id, então 'usuario' ainda nao foi inserido no banco
            {
                if (!base.ExisteNoBanco()) //usuario
                {
                    tabelaU.Insert(valuesU);  // INSERIR USUARIO

                    if (!base.ExisteNoBanco())
                        throw new Exception("Dado não inserido no banco!");

                    valuesP = new string[]
                    {
                        this.id_usuario.ToString()
                    };

                    tabelaP.Insert(valuesP);  // INSERIR PROFESSOR

                    if (!this.ExisteNoBanco())
                    {
                        tabelaU.Delete(this.id_usuario);
                        throw new Exception("Dado não inserido no banco!");
                    }
                        
                }
                else
                {
                    valuesP = new string[]
                    {
                        this.id_usuario.ToString()
                    };

                    // verificando se existe administrador:

                    Administrador admin = new Administrador(this.login, this.senha);
                    if (admin.ExisteNoBanco() && !this.ExisteNoBanco())
                    {
                        admin.RemoverDoBanco(); // REMOVER ADMINISTRADOR
                        tabelaU.Insert(valuesU); // REINSERIR USUARIO
                        tabelaP.Insert(valuesP); // INSERIR COMO PROFESSOR
                    }
                    else
                    {
                        tabelaU.Update(valuesU, this.id_usuario);  // ALTERAR USUARIO
                    }

                    if (!this.ExisteNoBanco()) //professor
                        throw new Exception("Dado não inserido no banco!");
                }
            }
            else
            {
                if (this.id_prof == 0)
                    throw new Exception("Banco com lógica corrompida! Usuário encontrado sem especialização (Admin. ou Prof.)");

                tabelaU.Update(valuesU, this.id_usuario);  // ALTERAR
            }
        }

        public override void RemoverDoBanco()
        {
            TUsuario tabelaU = new TUsuario();
            TProfessor tabelaP = new TProfessor();

            if (this.id_prof == 0) //nao possui id, então 'this' ainda nao foi inserido no banco
            {
                if (!this.ExisteNoBanco() || !base.ExisteNoBanco())
                    throw new Exception("Não foi encontrado no banco um registro com esses valores.");
                else
                {
                    tabelaP.Delete(this.id_prof);  // REMOVE
                    tabelaU.Delete(this.id_usuario);        // REMOVE
                }
            }
            else
            {
                tabelaP.Delete(this.id_prof);  // REMOVE
                tabelaU.Delete(this.id_usuario);        // REMOVE
            }
        }

        public bool ExisteNoBanco()
        {
            string[] valoresChave =
            {
                this.id_usuario.ToString()
            };

            if ((new TProfessor()).Exists(valoresChave, out this.id_prof)) //consulta o banco e seta o id se encontrar o registro
                return true;
            else
                return false;
        }

        public override DataTable TodosT()
        {
            return (new TProfessor()).SelectJoinUsuario();
        }

        public override List<IEntidade> Todos()
        {
            List<IEntidade> lista = new List<IEntidade>();

            foreach (DataRow dr in TodosT().Rows)
                lista.Add(new Professor(int.Parse(dr[0].ToString()), int.Parse(dr[1].ToString()), dr[2].ToString(), dr[3].ToString(), dr[4].ToString()));

            return lista;
        }
    }
}
