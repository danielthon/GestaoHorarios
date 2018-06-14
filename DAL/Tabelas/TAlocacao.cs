using System.Data;
using DAL.MySQL;

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

        public DataTable SelectJoinDisciplinaHorario()
        {
            return Conexao.ExecutaComandoSQL_Tabela(
                "SELECT A.id D.* H.* FROM alocacao A"
                + " JOIN disciplina D"
                + " ON D.id = A.id_disciplina"
                + " JOIN horario H"
                + " ON H.id = A.id_horario");
        }
    }
}
