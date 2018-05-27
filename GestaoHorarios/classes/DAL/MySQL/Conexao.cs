using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace GestaoHorarios.classes.DAL.MySQL
{
    static class Conexao
    {
        static private MySqlConnection conn;

        public static bool SetConexao(string instancia, string bd, out string mensagem)
        {
            StringBuilder str = new StringBuilder();
            str.Append("Server=" + instancia);
            str.Append(";Database=" + bd);
            str.Append(";Uid=root");
            str.Append(";Pwd=");

            conn = new MySqlConnection(str.ToString());

            try
            {
                conn.Open();
                conn.Close();

                mensagem = "";

                return true;
            }
            catch
            {
                try
                {
                    str = new StringBuilder();
                    str.Append("Server=" + instancia);
                    str.Append(";Database=mysql");
                    str.Append(";Uid=root");
                    str.Append(";Pwd=");

                    conn = new MySqlConnection(str.ToString());

                    conn.Open();
                    conn.Close();

                    mensagem = "Banco de dados " + bd + " não encontrado na respectiva instância.";
                }
                catch
                {
                    mensagem = "Instância inacessível no respectivo servidor. Confira se está aberta e disponível.";
                }

                return false;
            }
        }

        public static void ExecutaComandoSQL_SemRetorno(string query)
        {
            conn.Open();

            var cmd = new MySqlCommand(query, conn);
            var da = new MySqlDataAdapter(cmd);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static DataTable ExecutaComandoSQL_Tabela(string query)
        {
            conn.Open();

            var dt = new DataTable();
            var cmd = new MySqlCommand(query, conn);
            var da = new MySqlDataAdapter(cmd);

            da.Fill(dt);

            conn.Close();
            return dt;
        }

        public static DataRow ExecutaComandoSQL_Linha(string query)
        {
            return ExecutaComandoSQL_Tabela(query).Rows[0];
        }

        public static string ExecutaComandoSQL_Campo(string query)
        {
            return ExecutaComandoSQL_Tabela(query).Rows[0][0].ToString();
        }
    }
}
