using System;
using System.Collections.Generic;
using System.Text;
using DAL.Tabelas;
using BLL.Estruturas;

namespace BLL.Entidades
{
    public class Alocacao : IEntidade
    {
        private int id;
        private Disciplina disciplina;
        private Horario horario;

        public string ID { get { return this.id == 0 ? "" : this.id.ToString(); } set { this.id = int.Parse(value); } }
        public Disciplina Disciplina { get { return this.disciplina; } }
        public Horario Horario { get { return this.horario; } }
        public Professor Professor { get { return this.disciplina.Professor; } }

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
    }
}
