using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Estruturas;

namespace BLL.Entidades
{
    public class Periodo : IDado
    {
        private int numero;

        public int Numero { get { return this.numero; } }

        public Periodo(int numero)
        {
            this.numero = numero;
        }

        public int CompareTo(IDado other)
        {
            if (this.numero < ((Periodo)other).Numero)
                return -1;
            else if (this.numero > ((Periodo)other).Numero)
                return 1;
            else
                return 0;
        }

        public bool Equals(IDado other)
        {
            if (this.Equals((Periodo)other)) //cast para lançar exceção
                return true;
            else
                return false;
        }
    }
}
