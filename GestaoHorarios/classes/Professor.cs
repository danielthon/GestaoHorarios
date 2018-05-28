using System;
using System.Collections.Generic;

namespace GestaoHorarios.classes
{
    class Professor : Usuario
    {
        int id_prof;

        public override string ID { get { return this.id_prof == 0 ? "" : this.id_prof.ToString(); } set { this.id_prof = int.Parse(value); } }
        public string ID_Usuario { get { return this.id == 0 ? "" : this.id.ToString(); } set { this.id = int.Parse(value); } }

        public Professor(string nome, string login, string senha) : base (nome, login, senha) { }
    }
}
