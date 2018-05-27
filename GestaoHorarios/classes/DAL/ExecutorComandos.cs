using System;
using System.Text;
using System.Data;
using GestaoHorarios.classes.DAL.MySQL;

namespace GestaoHorarios.classes.DAL
{
    class ExecutorComandos
    {
        internal static void Insert(string tabela, string[] values)
        {
            StringBuilder str = new StringBuilder();

            str.AppendFormat("INSERT INTO {0} VALUES (''", tabela);

            foreach (string value in values)
            {
                if (value == "")
                    str.Append(",''");
                else
                    str.Append("," + value);
            }

            str.Append(");");

            Conexao.ExecutaComandoSQL_SemRetorno(str.ToString());
        }

        internal static DataTable Select(string tabela)
        {
            return Conexao.ExecutaComandoSQL_Tabela(string.Format("SELECT * FROM {0};", tabela));
        }

        internal static DataTable Select(string tabela, int id)
        {
            return Conexao.ExecutaComandoSQL_Tabela(string.Format("SELECT * FROM {0} WHERE id={1};", tabela, id));
        }

        internal static DataTable Select(string tabela, string[] campos, int id)
        {
            StringBuilder str = new StringBuilder();

            foreach (string campo in campos)
                str.Append("," + campo);

            return Conexao.ExecutaComandoSQL_Tabela(string.Format("SELECT {0} FROM {1} WHERE id={2};", str.ToString(), tabela, id));
        }

        internal static void Update(string tabela, string[] campos, string[] values, int id)
        {
            if (campos.Length != values.Length)
                throw new Exception("Quantidade de campos distinta da quantidade de valores de entrada.");

            StringBuilder str = new StringBuilder();

            for (int i = 0; i < campos.Length; i++)
            {
                if (i != 0)
                    str.Append(", ");

                if (values[i] != "")
                    str.AppendFormat("{0}={1}", campos[i], values[i]);
            }

            Conexao.ExecutaComandoSQL_SemRetorno(string.Format("UPDATE {0} SET {1} WHERE id={2};", tabela, str.ToString(), id));
        }

        internal static void Delete(string tabela, int id)
        {
            Conexao.ExecutaComandoSQL_SemRetorno(string.Format("DELETE FROM {0} WHERE id={1};", tabela, id));
        }
    }
}
