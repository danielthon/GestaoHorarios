using System;
using System.Collections.Generic;
using DAL.Tabelas;
using System.Data;

namespace BLL.Entidades
{
    public class Administrador : Usuario//, IEntidade
    {
        int id_admin;

        //public override string ID { get { return this.id_admin == 0 ? "" : this.id_admin.ToString(); } set { this.id_admin = int.Parse(value); } }
        public override int ID { get { return this.id_admin; } }
        //public string ID_Usuario { get { return this.id_usuario == 0 ? "" : this.id_usuario.ToString(); } set { this.id_usuario = int.Parse(value); } }
        public int ID_Usuario { get { return this.id_usuario; } }

        public Administrador(string nome, string login, string senha) : base (nome, login, senha) { }

        public Administrador(int id_admin, int id_usuario) : base(id_usuario) { /*if (this.ExisteNoBanco())*/ this.id_admin = id_admin; }

        public Administrador(int id_usuario, int id_admin, string nome, string login, string senha) : base(id_usuario, nome, login, senha) { this.id_admin = id_admin; }

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
                this.id_usuario.ToString()
            };

            if (this.id_usuario == 0) //nao possui id, então 'usuario' ainda nao foi inserido no banco
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
                    tabelaU.Update(valuesU, this.id_usuario);  // ALTERAR

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

                tabelaU.Update(valuesU, this.id_usuario);  // ALTERAR
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
                    tabelaU.Delete(this.id_usuario);        // REMOVE
                }
            }
            else
            {
                tabelaA.Delete(this.id_admin);  // REMOVE
                tabelaU.Delete(this.id_usuario);        // REMOVE
            }
        }

        public override bool ExisteNoBanco()
        {
            string[] valoresChave =
            {
                this.id_usuario.ToString()
            };

            if ((new TAdministrador()).Exists(valoresChave, out this.id_admin)) //consulta o banco e seta o id se encontrar o registro
                return true;
            else
                return false;
        }

        public override DataTable TodosT()
        {
            return (new TAdministrador()).SelectJoinUsuario();
        }

        public override List<IEntidade> Todos()
        {
            List<IEntidade> lista = new List<IEntidade>();

            foreach (DataRow dr in TodosT().Rows)
                lista.Add(new Administrador(int.Parse(dr[0].ToString()), int.Parse(dr[1].ToString()), dr[2].ToString(), dr[3].ToString(), dr[4].ToString()));

            return lista;
        }
    }
}
