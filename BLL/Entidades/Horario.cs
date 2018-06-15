using System;
using System.Collections.Generic;
using DAL.Tabelas;
using BLL.Estruturas;
using System.Data;

namespace BLL.Entidades
{
    public enum DiaSemana
    {
        Domingo = 1,
        Segunda = 2,
        Terca = 3,
        Quarta = 4,
        Quinta = 5,
        Sexta = 6,
        Sabado = 7     
    }

    public enum Hora
    {
        _19h00 = 1,
        _20h50 = 2
    }

    public class Horario : IEntidade, IDado
    {
        private int id;
        private DiaSemana diaSemana;
        private Hora hora;

        //public string ID { get { return this.id == 0 ? "" : this.id.ToString(); } set { this.id = int.Parse(value); } }
        public int ID { get { return this.id; } }
        public DiaSemana DiaNaSemana { get { return this.diaSemana; } }
        public Hora Hora { get { return this.hora; } }

        public Horario(DiaSemana dia, Hora hora)
        {
            this.diaSemana = dia;
            this.hora = hora;

            this.id = 0;
            this.ExisteNoBanco(); //verifica se existe, se sim, seta o id
        }

        public Horario(int id, DiaSemana dia, Hora hora)
        {
            this.diaSemana = dia;
            this.hora = hora;

            this.id = id;
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
            if (other.GetType() != typeof(Horario))
                return false;

            if (((Horario)other).ID != 0 && this.id != 0)
            {
                if (((Horario)other).ID == this.id)
                    return true;
                else
                    return false;
            }
            else
            {
                if (((Horario)other).DiaNaSemana == this.diaSemana
                    && ((Horario)other).Hora == this.hora)
                    return true;
                else
                    return false;
            }
        }

        public void SalvarNoBanco()
        {
            throw new NotImplementedException();
        }

        public void RemoverDoBanco()
        {
            throw new NotImplementedException();
        }

        public bool ExisteNoBanco()
        {
            throw new NotImplementedException();
        }

        public bool CarregaAtributos(int id)
        {
            DataRow linha = (new THorario()).Select(id.ToString());

            if (linha == null)
                return false;
            else
            {
                this.id = id;
                this.hora = DateTime.Parse(linha[1].ToString()) == DateTime.Parse("19:00:00") ? Hora._19h00 : Hora._20h50;
                this.diaSemana = (DiaSemana)int.Parse(linha[3].ToString());

                return true;
            }
        }

        public DataTable TodosT()
        {
            return (new THorario()).SelectAll();
        }

        public List<IEntidade> Todos()
        {
            List<IEntidade> lista = new List<IEntidade>();

            foreach (DataRow dr in TodosT().Rows)
            {
                Hora hora = DateTime.Parse(dr[1].ToString()) == DateTime.Parse("19:00:00") ? Hora._19h00 : Hora._20h50;
                DiaSemana diaSemana = (DiaSemana)int.Parse(dr[3].ToString());

                lista.Add(new Horario(int.Parse(dr[0].ToString()), diaSemana, hora));
            }

            return lista;
        }
    }
}
