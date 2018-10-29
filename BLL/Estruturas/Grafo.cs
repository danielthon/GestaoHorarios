using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Estruturas
{
    public class Grafo
    {
        private List<Vertice> vertices;
        private List<Aresta> arestas;

        public List<Vertice> Vertices { get { return this.vertices; } }
        public List<Aresta> Arestas { get { return this.arestas; } }

        public Grafo()
        {
            this.vertices = new List<Vertice>();
            this.arestas = new List<Aresta>();
        }

        public Vertice GetVerticePorDado(IDado dado)
        {
            foreach(Vertice v in this.vertices)
            {
                if (v.GetDado.GetType() == dado.GetType() && v.GetDado.Equals(dado))
                    return v;
            }

            return null;
        }

        public void AddVertice(Vertice novo)
        {
            this.vertices.Add(novo);
        }

        public void AddVertices(List<Vertice> novos)
        {
            this.vertices.AddRange(novos);
        }

        public void AddAresta(Aresta nova)
        {
            this.arestas.Add(nova);
        }

        public void AddArestas(List<Aresta> novas)
        {
            this.arestas.AddRange(novas);
        }

        public void RemoverAresta(Aresta aRemover)
        {
            aRemover.VerticePrimeiro.Arestas.Remove(aRemover);
            aRemover.VerticeSegundo.Arestas.Remove(aRemover);

            this.arestas.Remove(aRemover);
        }
    }
}
