using System;
using System.Data;
using DAL;
using DAL.MySQL;

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
        }
    }
}
