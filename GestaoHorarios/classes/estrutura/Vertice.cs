using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHorarios.classes.estrutura
{
    class Vertice
    {
        private IDado dados;
        private bool visitado;

        private List<Aresta> arestas;
        public List<Aresta> Arestas { get { return this.arestas; } }

        public IDado GetDado { get { return this.dados; } }
        public bool FoiVisitado { get { return this.visitado; } }

        public Vertice(IDado dados)
        {
            this.dados = dados;
            this.visitado = false;
            this.arestas = new List<Aresta>();
        }

        public Vertice(IDado dados, List<Aresta> arestas)
        {
            this.dados = dados;
            this.visitado = false;
            this.arestas = arestas;
        }

        public bool Contem(Aresta a)
        {
            foreach(Aresta aresta in this.arestas)
            {
                if (aresta.Equals(a))
                    return true;
            }

            return false;
        }

        public void Visitar()
        {
            this.visitado = true;
        }


        public void RemoverArestas()
        {
            this.arestas.Clear();
        }
    }
}
