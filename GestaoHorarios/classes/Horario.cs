using System;
using System.Collections.Generic;
using GestaoHorarios.classes.estrutura;

namespace GestaoHorarios.classes
{
    public enum DiaSemana
    {
        Segunda,
        Terca,
        Quarta,
        Quinta,
        Sexta,
        Sabado,
        Domingo
    }

    public enum Hora
    {
        _19h00,
        _20h50
    }

    class Horario : IDado
    {
        //private int id; //?
        private DiaSemana diaSemana;
        private Hora hora;

        public DiaSemana DiaNaSemana { get { return this.diaSemana; } }
        public Hora HorarioDeInicio { get { return this.hora; } }

        public Horario(DiaSemana dia, Hora hora)
        {
            this.diaSemana = dia;
            this.hora = hora;
        }

        public int CompareTo(IDado other)
        {
            if (this.diaSemana < ((Horario)other).diaSemana)
                return -1;
            else if (this.diaSemana > ((Horario)other).diaSemana)
                return 1;
            else
            {
                if (this.hora < ((Horario)other).hora)
                    return -1;
                else if (this.hora < ((Horario)other).hora)
                    return 1;
                else
                    return 0;
            }
        }

        public bool Equals(IDado other)
        {
            if (this.Equals((Horario)other)) //cast para lançar exceção
                return true;
            else
                return false;
        }
    }
}
