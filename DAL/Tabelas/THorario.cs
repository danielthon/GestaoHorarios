using System;
using GestaoHorarios.classes;
using DAL;
using DAL.MySQL;

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
        }
    }
}
