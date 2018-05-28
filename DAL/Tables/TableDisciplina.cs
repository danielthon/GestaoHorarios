using System;
using System.Data;
using GestaoHorarios.classes;
using DAL;
using DAL.MySQL;

namespace DAL.Tables
{
    public class TableDisciplina
    {
        static string tabela = "disciplina";

        static string[] campos =
        {
            "Id_Periodo",
            "Nome",
            "Id_Professor"
        };
    }
}
