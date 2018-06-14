using System;
using System.Collections.Generic;
using DAL.Tabelas;
using BLL.Estruturas;
using System.Data;

namespace BLL.Entidades
{
    public class Professor : Usuario, IDado//, IEntidade
    {
        int id_prof;

        //public override string ID { get { return this.id_prof == 0 ? "" : this.id_prof.ToString(); } set { this.id_prof = int.Parse(value); } }
        public override int ID { get { return this.id_prof; } }
        //public string ID_Usuario { get { return this.id_usuario == 0 ? "" : this.id_usuario.ToString(); } set { this.id_usuario = int.Parse(value); } }
        public int ID_Usuario { get { return this.id_usuario; } }

        public Professor(string nome, string login, string senha) : base (nome, login, senha) { this.ExisteNoBanco(); } //verifica se existe, se sim, seta o id

        public Professor(int id_prof, int id_usuario) : base(id_usuario) { /*if (this.ExisteNoBanco())*/ this.id_prof = id_prof; }

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
            if (this.Equals((Professor)other)) //cast para lançar exceção
                return true;
            else
                return false;
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
                this.id_usuario.ToString() //nao confunda: a variavel 'id' armazena o 'id_usuario'
            };

            if (this.id_usuario == 0) //nao possui id, então 'usuario' ainda nao foi inserido no banco
            {
                if (!base.ExisteNoBanco()) //usuario
                {
                    tabelaU.Insert(valuesU);  // INSERIR
                    tabelaP.Insert(valuesP);  // INSERIR

                    if (!base.ExisteNoBanco()) //usuario
                        throw new Exception("Dado não inserido no banco!");
                }
                else
                {
                    tabelaU.Update(valuesU, this.id_usuario);  // ALTERAR

                    if (!this.ExisteNoBanco()) //administrador
                        tabelaP.Insert(valuesP);  // INSERIR
                                                  // *

                    if (!this.ExisteNoBanco()) //administrador
                        throw new Exception("Dado não inserido no banco!");
                }
            }
            else
            {
                if (this.id_prof == 0)
                    throw new Exception("Banco com lógica corrompida! Usuário encontrado sem especialização (Admin. ou Prof.)");

                tabelaU.Update(valuesU, this.id_usuario);  // ALTERAR
                // *
            }

            //* aqui haveria o tabelaA.Update, mas se ele ja existe, nao precisa de alterar porque Id_Usuario é a unica variavel
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

        public override bool ExisteNoBanco()
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
