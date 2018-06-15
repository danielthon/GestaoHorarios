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
        protected string[] camposChave;

        public string getNomeTabela { get { return this.tabela; } }

        /// <summary>
        /// Retorna o nome das colunas da respectiva tabela no banco de dados
        /// </summary>
        public string[] getCampos { get { return this.campos; } }

        /// <summary>
        /// Retorna o nome das colunas das quais não podem conter valores duplicados (dois registros com o mesmo dado) no banco de dados
        /// </summary>
        public string[] getCamposChave { get { return this.camposChave; } }

        public void Insert(string[] values)
        {
            StringBuilder str = new StringBuilder();

            str.AppendFormat("INSERT INTO {0} VALUES (null", tabela);

            foreach (string value in values)
            {
                if (value == "" || value == null)
                    str.Append(",null");
                else
                {
                    int aux;

                    if(int.TryParse(value, out aux))
                        str.Append("," + aux);
                    else
                        str.Append(",'" + value + "'");
                }
                    
            }

            str.Append(");");

            Conexao.ExecutaComandoSQL_SemRetorno(str.ToString());
        }

        public DataTable SelectAll()
        {
            return Conexao.ExecutaComandoSQL_Tabela(string.Format("SELECT * FROM {0};", tabela));
        }

        public DataRow Select(string id)
        {
            return Conexao.ExecutaComandoSQL_Linha(string.Format("SELECT * FROM {0} WHERE id={1};", tabela, id));
        }

        public DataTable SelectWhere(string where)
        {
            return Conexao.ExecutaComandoSQL_Tabela(string.Format("SELECT * FROM {0} {1};", tabela, where));
        }

        public string Select(string campo, int id)
        {
            return Conexao.ExecutaComandoSQL_Campo(string.Format("SELECT {0} FROM {1} WHERE id={2};", campo, tabela, id));
        }

        public void Update(string[] values, int id)
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
                {
                    int aux;

                    if (int.TryParse(values[i], out aux))
                        str.AppendFormat("{0}={1}", camposChave[i], aux);
                    else
                        str.AppendFormat("{0}='{1}'", campos[i], values[i]);
                }
            }

            Conexao.ExecutaComandoSQL_SemRetorno(string.Format("UPDATE {0} SET {1} WHERE id={2};", tabela, str.ToString(), id));
        }

        public void Delete(int id)
        {
            Conexao.ExecutaComandoSQL_SemRetorno(string.Format("DELETE FROM {0} WHERE id={1};", tabela, id));
        }

        public bool Exists(string[] valoresChave)
        {
            if (camposChave.Length != valoresChave.Length)
                throw new Exception("Quantidade de campos distinta da quantidade de valores de entrada.");

            StringBuilder str = new StringBuilder();

            for (int i = 0; i < camposChave.Length; i++)
            {
                if (i != 0)
                    str.Append(", ");

                if (valoresChave[i] != "" && valoresChave[i] != null)
                    str.AppendFormat("{0}={1}", camposChave[i], valoresChave[i]);
            }

            return Conexao.ExecutaComandoSQL_Campo(string.Format("SELECT id FROM {0} WHERE {1};", tabela)) != null;
        }

        public bool Exists(string[] valoresChave, out int id)
        {
            if (camposChave.Length != valoresChave.Length)
                throw new Exception("Quantidade de campos distinta da quantidade de valores de entrada.");

            StringBuilder str = new StringBuilder();

            for (int i = 0; i < camposChave.Length; i++)
            {
                if (i != 0)
                    str.Append(", ");

                if (valoresChave[i] != "" && valoresChave[i] != null)
                {
                    int aux;

                    if (int.TryParse(valoresChave[i], out aux))
                        str.AppendFormat("{0}={1}", camposChave[i], aux);
                    else
                        str.AppendFormat("{0}='{1}'", camposChave[i], valoresChave[i]);
                }
            }

            if (int.TryParse(Conexao.ExecutaComandoSQL_Campo(string.Format("SELECT id FROM {0} WHERE {1};", tabela, str.ToString())), out id))
                return true;
            else
                return false;
        }
    }
}
