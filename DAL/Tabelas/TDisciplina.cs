
namespace DAL.Tabelas
{
    public class TDisciplina : Tabela
    {
        public TDisciplina()
        {
            this.tabela = "disciplina";

            this.campos = new string[]
            {
                "Periodo",
                "Nome",
                "Id_Professor"
            };

            this.camposChave = new string[]
            {
                "Nome"
            };
        }
    }
}
