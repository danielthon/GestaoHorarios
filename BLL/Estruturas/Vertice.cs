using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Estruturas
{
    public class Vertice
    {
        private IDado dados;

        private List<Aresta> arestas;
        public List<Aresta> Arestas { get { return this.arestas; } }

        public IDado GetDado { get { return this.dados; } }

        public Vertice(IDado dados)
        {
            this.dados = dados;
            this.arestas = new List<Aresta>();
        }

        public Vertice(IDado dados, List<Aresta> arestas)
        {
            this.dados = dados;
            this.arestas = arestas;
        }

        //public override bool Equals(object obj)
        //{
        //    if (this.dados.Equals(((Vertice)obj).GetDado))
        //        return true;
        //    else
        //        return false;
        //}

        public bool Contem(Aresta a)
        {
            foreach(Aresta aresta in this.arestas)
            {
                if (aresta.Equals(a))
                    return true;
            }

            return false;
        }

        public List<Vertice> GetAdjacentes()
        {
            List<Vertice> lista = new List<Vertice>();

            foreach (Aresta aresta in this.arestas)
                lista.Add(aresta.OutraExtremidade(this));

            return lista;
        }

        public void RemoverArestas()
        {
            this.arestas.Clear();
        }

        public bool IsAdjacente(Vertice v)
        {
            foreach (Aresta aresta in this.arestas)
            {
                if (aresta.OutraExtremidade(this).Equals(v))
                    return true;
            }

            return false;
        }

        public bool IsAdjacente(List<Vertice> lista)
        {
            foreach (Aresta aresta in this.arestas)
            {
                foreach (Vertice vertice in lista)
                {
                    if (aresta.OutraExtremidade(this).Equals(vertice))
                        return true;
                }
            }

            return false;
        }
    }
}
