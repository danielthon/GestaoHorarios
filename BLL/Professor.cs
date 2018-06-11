using System;
using System.Collections.Generic;
using DAL.Tabelas;
using BLL.Estruturas;

namespace BLL.Entidades
{
    public class Professor : Usuario, IDado//, IEntidade
    {
        int id_prof;

        public override string ID { get { return this.id_prof == 0 ? "" : this.id_prof.ToString(); } set { this.id_prof = int.Parse(value); } }
        public string ID_Usuario { get { return this.id == 0 ? "" : this.id.ToString(); } set { this.id = int.Parse(value); } }

        public Professor(string nome, string login, string senha) : base (nome, login, senha) { }

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
                this.id.ToString() //nao confunda: a variavel 'id' armazena o 'id_usuario'
            };

            if (this.id == 0) //nao possui id, então 'usuario' ainda nao foi inserido no banco
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
                    tabelaU.Update(valuesU, this.id);  // ALTERAR

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

                tabelaU.Update(valuesU, this.id);  // ALTERAR
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
                    tabelaU.Delete(this.id);        // REMOVE
                }
            }
            else
            {
                tabelaP.Delete(this.id_prof);  // REMOVE
                tabelaU.Delete(this.id);        // REMOVE
            }
        }
        /*
        public override bool ExisteNoBanco()
        {
            TProfessor tabela = new TProfessor();
            string[] valoresChave =
            {
                this.id.ToString() //nao confunda: a variavel 'id' armazena o 'id_usuario'
            };

           // if (tabela.Exists(valoresChave, out this.id_prof)) //consulta o banco e seta o id se encontrar o registro
           //    return true;
           // else
            //    return false;
        }
        */
    }
}
