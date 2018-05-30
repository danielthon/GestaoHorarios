
namespace DAL.Tabelas
{
    public class TDisciplina : Tabela
    {
        public TDisciplina()
        {
            this.tabela = "disciplina";

            this.campos = new string[]
            {
                "Id_Periodo",
                "Nome",
                "Id_Professor"
            };

            this.camposChave = new string[]
            {
                "Nome",
                "Id_Professor"
            };
        }
    }
}
