using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoHorarios.classes
{
    public class Alocacao
    {
        private int id;
        private Disciplina disciplina;
        private Horario horario;

        public string ID { get { return this.id == 0 ? "" : this.id.ToString(); } set { this.id = int.Parse(value); } }
        public Disciplina Disciplina { get { return this.disciplina; } }
        public Horario Horario { get { return this.horario; } }
        public Professor Professor { get { return this.disciplina.Professor; } }
    }
}
