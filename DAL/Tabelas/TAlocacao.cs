using System;
using System.Data;
using GestaoHorarios.classes;
using DAL;
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
        }
    }
}
