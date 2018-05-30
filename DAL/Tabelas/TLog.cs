
namespace DAL.Tabelas
{
    public class TLog : Tabela
    {
        public TLog()
        {
            this.tabela = "log";

            this.campos = new string[]
            {
                "Hora",
                "Operacao",
                "Id_Alocacao",
                "Id_Usuario"
            };

            this.camposChave = new string[]
            {
                "Hora",
                "Operacao",
                "Id_Alocacao",
                "Id_Usuario"
            };
        }

        //public static void Inserir(string operacao, Usuario usuario, Alocacao alocacao)
        //{
        //    string[] values =
        //    {
        //        string.Format("'{0}'", DateTime.Now.ToString("yyyy-MM-dd hh:mm")),
        //        alocacao.ID,
        //        usuario.ID
        //    };

        //    ExecutorComandos.Insert(tabela, values);
        //}

        //public static DataTable Visualizar()
        //{
        //    return ExecutorComandos.Select(tabela);
        //}

        //public static DataTable Visualizar(string id)
        //{
        //    return ExecutorComandos.Select(tabela, id);
        //}

        //public static string Visualizar(string campo, string id)
        //{
        //    return ExecutorComandos.Select(tabela, campo, id);
        //}
    }
}
