using System.Data;
using DAL.MySQL;

namespace DAL.Tabelas
{
    public class TAdministrador : Tabela
    {
        public TAdministrador()
        {
            this.tabela = "administrador";

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
                "SELECT A.id U.* FROM usuario U"
                + " JOIN administrador A"
                + " ON U.id = A.id_usuario;");
        }
    }
}
