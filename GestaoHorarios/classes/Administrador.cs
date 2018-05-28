﻿using System;
using System.Collections.Generic;

namespace GestaoHorarios.classes
{
    class Administrador : Usuario
    {
        int id_admin;

        public override string ID { get { return this.id_admin == 0 ? "" : this.id_admin.ToString(); } set { this.id_admin = int.Parse(value); } }
        public string ID_Usuario { get { return this.id == 0 ? "" : this.id.ToString(); } set { this.id = int.Parse(value); } }

        public Administrador(string nome, string login, string senha) : base (nome, login, senha) { }
    }
}
