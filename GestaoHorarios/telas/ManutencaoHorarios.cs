using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Entidades;
using BLL.Estruturas;

namespace GestaoHorarios.Telas
{
    public partial class ManutencaoHorarios : FormBase
    {
        private List<Label> lb_Horarios;

        public ManutencaoHorarios()
        {
            InitializeComponent();

            lb_Horarios = new List<Label>();
            lb_Horarios.Add(lb_segunda1);
            lb_Horarios.Add(lb_segunda2);
            lb_Horarios.Add(lb_terca1);
            lb_Horarios.Add(lb_terca2);
            lb_Horarios.Add(lb_quarta1);
            lb_Horarios.Add(lb_quarta2);
            lb_Horarios.Add(lb_quinta1);
            lb_Horarios.Add(lb_quinta2);
            lb_Horarios.Add(lb_sexta1);
            lb_Horarios.Add(lb_sexta2);

            foreach (Label lb in lb_Horarios)
                lb.Click += Click_lb_Horario;

            //this.cbPeriodo.Items.Add("teste");
            //this.cbDisciplina.Items.Add("teset2");

            this.groupBox1.Enabled = false;
            this.cbDisciplina.Enabled = false;
            this.btGravar.Enabled = false;
        }

        private void ManutencaoHorarios_Load(object sender, EventArgs e)
        {
            lb_titulo.Text = "Alocação de Horários";
            lbExibeProfessor.Text = "";

            Manager.CarregarGrafoPeloBanco();

            List<Vertice> periodos = Manager.GetPeriodos();

            foreach(Vertice v in periodos)
                cbPeriodo.Items.Add(((Periodo)v.GetDado).Numero);
        }

        private void Click_lb_Horario(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = true;

            foreach (Label lb in lb_Horarios)
                lb.BackColor = Color.White;

            Label clicado = (Label)sender;

            clicado.BackColor = Color.Turquoise;
            if (clicado.Text != "")
            {
                this.groupBox2.Enabled = true;
                this.cbDisciplina.Text = clicado.Text;
            }
            else
            {
                this.cbDisciplina.Enabled = true;
            }

            switch (lb_Horarios.IndexOf(clicado))
            {
                case 0:
                    lbHorarioEscolhido.Text = "2ª Feira - Primeiro Horário"; break;
                case 1:
                    lbHorarioEscolhido.Text = "2ª Feira - Segundo Horário"; break;
                case 2:
                    lbHorarioEscolhido.Text = "3ª Feira - Primeiro Horário"; break;
                case 3:
                    lbHorarioEscolhido.Text = "3ª Feira - Segundo Horário"; break;
                case 4:
                    lbHorarioEscolhido.Text = "4ª Feira - Primeiro Horário"; break;
                case 5:
                    lbHorarioEscolhido.Text = "4ª Feira - Segundo Horário"; break;
                case 6:
                    lbHorarioEscolhido.Text = "5ª Feira - Primeiro Horário"; break;
                case 7:
                    lbHorarioEscolhido.Text = "5ª Feira - Segundo Horário"; break;
                case 8:
                    lbHorarioEscolhido.Text = "6ª Feira - Primeiro Horário"; break;
                case 9:
                    lbHorarioEscolhido.Text = "6ª Feira - Segundo Horário"; break;
            }

            cbDisciplina.SelectedIndex = -1;
            lbExibeProfessor.Text = "";
            btGravar.Enabled = false;
        }

        private void cbPeriodo_SelectedValueChanged(object sender, EventArgs e)
        {
            List<Vertice> periodos = Manager.GetPeriodos();
            Vertice periodoSelecionado = null;

            foreach (Vertice v in periodos)
            {
                if(((Periodo)v.GetDado).Numero == int.Parse(cbPeriodo.SelectedItem.ToString()))
                {
                    periodoSelecionado = v;
                    break;
                }
            }

            List<Vertice> disciplinas = Manager.GetDisciplinasPorPeriodo(periodoSelecionado);

            cbDisciplina.Items.Clear();

            foreach (Vertice v in disciplinas)
                cbDisciplina.Items.Add(((Disciplina)v.GetDado).Nome);

            this.groupBox1.Enabled = true;
        }

        private void cbDisciplina_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbDisciplina.SelectedIndex != -1)
            {
                Disciplina aux = new Disciplina(cbDisciplina.SelectedItem.ToString(), 0, 0);

                lbExibeProfessor.Text = ((Professor)Manager.GetProfessorDeDisciplina(Manager.GetVerticeNaGrade(aux)).GetDado).Nome;

                btGravar.Enabled = true;
            }
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            Vertice vd = Manager.GetVerticeNaGrade(new Disciplina(cbDisciplina.SelectedItem.ToString(), 0, 0));
            //Vertice vh = Manager.GetVerticeNaGrade(p);

            //if(Manager.TentarAlocar()
        }
    }
}