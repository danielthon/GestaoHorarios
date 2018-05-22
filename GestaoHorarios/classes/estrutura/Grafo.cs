﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHorarios.classes.estrutura
{
    class Grafo
    {
        private List<Vertice> vertices;
        private List<Aresta> arestas;

        public List<Vertice> Vertices { get { return this.vertices; } }
        public List<Aresta> Arestas { get { return this.arestas; } }

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
    }
}
