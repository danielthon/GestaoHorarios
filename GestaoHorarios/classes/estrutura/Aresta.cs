using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHorarios.classes.estrutura
{
    class Aresta
    {
        private Vertice vertice1;
        private Vertice vertice2;

        public Vertice VerticePrimeiro { get { return this.vertice1; } }
        public Vertice VerticeSegundo { get { return this.vertice2; } }

        public Aresta(Vertice v1, Vertice v2)
        {
            this.vertice1 = v1;
            this.vertice2 = v2;
        }

        public bool Contem(Vertice v)
        {
            if (this.vertice1.Equals(v))
                return true;
            else if (this.vertice2.Equals(v))
                return true;
            else
                return false;
        }
    }
}
