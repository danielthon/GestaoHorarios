using System;
using GestaoHorarios.classes;
using DAL;
using DAL.MySQL;

namespace DAL.Tables
{
    public class TableHorario
    {
        static string tabela = "horario";

        static string[] campos =
        {
            "HoraInicio",
            "HoraTermino",
            "DiaSemana"
        };
    }
}
