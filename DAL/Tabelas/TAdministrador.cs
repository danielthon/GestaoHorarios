
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
    }
}
