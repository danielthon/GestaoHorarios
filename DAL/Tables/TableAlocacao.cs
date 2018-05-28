using System;
using System.Data;
using GestaoHorarios.classes;
using DAL;
using DAL.MySQL;

namespace DAL.Tables
{
    public class TableAlocacao
    {
        static string tabela = "alocacao";

        static string[] campos =
        {
            "Id_Disciplina",
            "Id_Horario"
        };
    }
}
