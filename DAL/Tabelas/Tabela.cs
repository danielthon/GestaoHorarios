using System;
using System.Text;
using DAL.MySQL;
using System.Data;

namespace DAL.Tabelas
{
    public abstract class Tabela
    {
        protected string tabela;
        protected string[] campos;

        public void Insert(string[] values)
        {
            StringBuilder str = new StringBuilder();

            str.AppendFormat("INSERT INTO {0} VALUES (null", tabela);

            foreach (string value in values)
            {
                if (value == "" || value == null)
                    str.Append(",null");
                else
                    str.Append("," + value);
            }

            str.Append(");");

            Conexao.ExecutaComandoSQL_SemRetorno(str.ToString());
        }

        public DataTable SelectAll()
        {
            return Conexao.ExecutaComandoSQL_Tabela(string.Format("SELECT * FROM {0};", tabela));
        }

        public DataTable Select(string id)
        {
            return Conexao.ExecutaComandoSQL_Tabela(string.Format("SELECT * FROM {0} WHERE id={1};", tabela, id));
        }

        public string Select(string campo, string id)
        {
            return Conexao.ExecutaComandoSQL_Campo(string.Format("SELECT {0} FROM {1} WHERE id={2};", campo, tabela, id));
        }

        public void Update(string[] values, string id)
        {
            if (campos.Length != values.Length)
                throw new Exception("Quantidade de campos distinta da quantidade de valores de entrada.");

            StringBuilder str = new StringBuilder();

            for (int i = 0; i < campos.Length; i++)
            {
                if (i != 0)
                    str.Append(", ");

                if (values[i] == "" || values[i] == null)
                    str.AppendFormat("{0}=null", campos[i]);
                else
                    str.AppendFormat("{0}={1}", campos[i], values[i]);
            }

            Conexao.ExecutaComandoSQL_SemRetorno(string.Format("UPDATE {0} SET {1} WHERE id={2};", tabela, str.ToString(), id));
        }

        public void Delete(string id)
        {
            Conexao.ExecutaComandoSQL_SemRetorno(string.Format("DELETE FROM {0} WHERE id={1};", tabela, id));
        }
    }
}
