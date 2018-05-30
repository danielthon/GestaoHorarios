
namespace DAL.Tabelas
{
    public class TAlocacao : Tabela
    {
        public TAlocacao()
        {
            this.tabela = "alocacao";

            this.campos = new string[]
            {
                "Id_Disciplina",
                "Id_Horario"
            };

            this.camposChave = new string[]
            {
                "Id_Disciplina",
                "Id_Horario"
            };
        }
    }
}
