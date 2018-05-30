
namespace DAL.Tabelas
{
    public class THorario : Tabela
    {
        public THorario()
        {
            this.tabela = "horario";

            this.campos = new string[]
            {
                "HoraInicio",
                "HoraTermino",
                "DiaSemana"
            };

            this.camposChave = new string[]
            {
                "HoraInicio",
                "HoraTermino",
                "DiaSemana"
            };
        }
    }
}
