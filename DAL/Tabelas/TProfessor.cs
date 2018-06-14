using System.Data;
using DAL.MySQL;

namespace DAL.Tabelas
{
    public class TProfessor : Tabela
    {
        public TProfessor()
        {
            this.tabela = "professor";

            this.campos = new string[]
            {
                "Id_Usuario"
            };

            this.camposChave = new string[]
            {
                "Id_Usuario"
            };
        }


        public DataTable SelectJoinUsuario()
        {
            return Conexao.ExecutaComandoSQL_Tabela(
                "SELECT P.id U.* FROM usuario U"
                + " JOIN professor P"
                + " ON U.id = P.id_usuario;");
        }
    }
}
