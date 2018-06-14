
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
    }
}
