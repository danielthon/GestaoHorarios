
namespace DAL.Tabelas
{
    public class TUsuario : Tabela
    {
        public TUsuario()
        {
            this.tabela = "usuario";

            this.campos = new string[]
            {
                "Nome",
                "Login",
                "Senha"
            };

            this.camposChave = new string[]
            {
                "Login"
            };
        }

        //public static void Inserir(Usuario usuario)
        //{
        //    string[] values =
        //    {
        //        usuario.Nome,
        //        usuario.Login,
        //        usuario.Senha
        //    };

        //    ExecutorComandos.Insert(tabela, values);

        //    //usuario.ID = ?
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

        //public static void Alterar(Usuario usuario)
        //{
        //    string[] values =
        //    {
        //        usuario.Nome,
        //        usuario.Login,
        //        usuario.Senha
        //    };

        //    ExecutorComandos.Update(tabela, campos, values, usuario.ID);
        //}

        //public static void Excluir(Usuario usuario)
        //{
        //    ExecutorComandos.Delete(tabela, usuario.ID);
        //    usuario = null;
        //}
    }
}
