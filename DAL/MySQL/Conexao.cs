using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;

namespace DAL.MySQL
{
    public static class Conexao
    {
        static private MySqlConnection conn;
        static private bool transacaoAberta = false;

        public static bool SetConexao(string servidor, string bd, out string mensagem)
        {
            StringBuilder str = new StringBuilder();
            str.Append("server=" + servidor); //padrão = "localhost"
            str.Append(";database=" + bd);
            str.Append(";uid=root");
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
                    str.Append("server=" + servidor);
                    str.Append(";database=mysql");
                    str.Append(";uid=root");
                    str.Append(";pwd=");

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
            DataRowCollection retorno = ExecutaComandoSQL_Tabela(query).Rows;

            if (retorno.Count > 0)
                return retorno[0];
            else
                return null;
        }

        public static string ExecutaComandoSQL_Campo(string query)
        {
            DataRowCollection retorno = ExecutaComandoSQL_Tabela(query).Rows;

            if (retorno.Count > 0)
                return retorno[0][0].ToString();
            else
                return null;
        }
    }
}
