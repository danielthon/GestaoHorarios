﻿using System;
using System.Collections.Generic;
using DAL.Tabelas;
using BLL.Estruturas;

namespace BLL.Entidades
{
    public class Administrador : Usuario//, IEntidade
    {
        int id_admin;

        public override string ID { get { return this.id_admin == 0 ? "" : this.id_admin.ToString(); } set { this.id_admin = int.Parse(value); } }
        public string ID_Usuario { get { return this.id == 0 ? "" : this.id.ToString(); } set { this.id = int.Parse(value); } }

        public Administrador(string nome, string login, string senha) : base (nome, login, senha) { }

        public override void SalvarNoBanco()
        {
            TUsuario tabelaU = new TUsuario();          
            string[] valuesU =
            {
                this.nome,
                this.login,
                this.senha
            };

            TAdministrador tabelaA = new TAdministrador();
            string[] valuesA =
            {
                this.id.ToString() //nao confunda: a variavel 'id' armazena o 'id_usuario'
            };

            if (this.id == 0) //nao possui id, então 'usuario' ainda nao foi inserido no banco
            {
                if (!base.ExisteNoBanco()) //usuario
                {
                    tabelaU.Insert(valuesU);  // INSERIR
                    tabelaA.Insert(valuesA);  // INSERIR
                    
                    if (!base.ExisteNoBanco()) //usuario
                        throw new Exception("Dado não inserido no banco!");
                }
                else
                {
                    tabelaU.Update(valuesU, this.id);  // ALTERAR

                    if (!this.ExisteNoBanco()) //administrador
                        tabelaA.Insert(valuesA);  // INSERIR
                    // *
                    
                    if (!this.ExisteNoBanco()) //administrador
                        throw new Exception("Dado não inserido no banco!");
                }
            }
            else
            {
                if (this.id_admin == 0)
                    throw new Exception("Banco com lógica corrompida! Usuário encontrado sem especialização (Admin. ou Prof.)");

                tabelaU.Update(valuesU, this.id);  // ALTERAR
                // *
            }

            //* aqui haveria o tabelaA.Update, mas se ele ja existe, nao precisa de alterar porque Id_Usuario é a unica variavel
        }

        public override void RemoverDoBanco()
        {
            TUsuario tabelaU = new TUsuario();
            TAdministrador tabelaA = new TAdministrador();

            if (this.id_admin == 0) //nao possui id, então 'this' ainda nao foi inserido no banco
            {
                if (!this.ExisteNoBanco() || !base.ExisteNoBanco())
                    throw new Exception("Não foi encontrado no banco um registro com esses valores.");
                else
                {
                    tabelaA.Delete(this.id_admin);  // REMOVE
                    tabelaU.Delete(this.id);        // REMOVE
                }
            }
            else
            {
                tabelaA.Delete(this.id_admin);  // REMOVE
                tabelaU.Delete(this.id);        // REMOVE
            }
        }

        public override bool ExisteNoBanco()
        {
            TAdministrador tabela = new TAdministrador();
            string[] valoresChave =
            {
                this.id.ToString() //nao confunda: a variavel 'id' armazena o 'id_usuario'
            };

            if (tabela.Exists(valoresChave, out this.id_admin)) //consulta o banco e seta o id se encontrar o registro
                return true;
            else
                return false;
        }
    }
}
