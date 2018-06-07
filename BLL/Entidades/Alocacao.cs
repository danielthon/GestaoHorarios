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
        private int id_disciplina;
        private int id_horario;

        //public string ID { get { return this.id == 0 ? "" : this.id.ToString(); } set { this.id = int.Parse(value); } }
        public int ID { get { return this.id; } }
        public int ID_Disciplina { get { return this.id_disciplina; } }
        public int ID_Horario { get { return this.id_horario; } }

        public Alocacao(Disciplina disciplina, Horario horario)
        {
            this.id_disciplina = disciplina.ID;
            this.id_horario = horario.ID;

            this.ExisteNoBanco(); //verifica se existe, se sim, seta o id
        }

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
            TUsuario tabela = new TUsuario();
            string[] valoresChave =
            {
                this.id_disciplina.ToString(),
                this.id_horario.ToString()
            };

            if (tabela.Exists(valoresChave, out this.id)) //consulta o banco e seta o id se encontrar o registro
                return true;
            else
                return false;
        }
    }
}
