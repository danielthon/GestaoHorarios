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
        private List<Vertice> v_Horarios;

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

            this.groupBox1.Enabled = false;
            this.groupBox2.Enabled = false;

            this.btGravar.Enabled = false;
        }

        private void ManutencaoHorarios_Load(object sender, EventArgs e)
        {
            lb_titulo.Text = "Alocação de Horários";
            lbExibeProfessor.Text = "";

            Manager.CarregarGrafoPeloBanco();

            v_Horarios = Manager.GetHorarios();

            List<Vertice> periodos = Manager.GetPeriodos();

            foreach(Vertice v in periodos)
                cbPeriodo.Items.Add(((Periodo)v.GetDado).Numero);
        }

        private void Click_lb_Horario(object sender, EventArgs e)
        {
            foreach (Label lb in lb_Horarios)
                lb.BackColor = Color.White;

            Label clicado = (Label)sender;

            clicado.BackColor = Color.Turquoise;

            if (clicado.Text == "")
            {
                this.groupBox2.Enabled = true;

                cbDisciplina.SelectedIndex = -1;
                lbExibeProfessor.Text = "";
                btGravar.Enabled = false;
            }
            else
            {
                this.groupBox2.Enabled = false;

                cbDisciplina.SelectedItem = clicado.Text;
                // "cbDisciplina_SelectedValueChanged" carrega o professor
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

            //limpa tuto
            
            groupBox2.Enabled = false;

            lbHorarioEscolhido.Text = "";
            cbDisciplina.Items.Clear();
            lbExibeProfessor.Text = "";

            // limpa todos os labels de horario
            foreach (Label lb in lb_Horarios)
            {
                lb.BackColor = Color.White;
                lb.Text = "";
            }

            // carrega as disciplinas
            List<Vertice> disciplinas = Manager.GetDisciplinasPorPeriodo(periodoSelecionado);

            foreach (Vertice v in disciplinas)
                cbDisciplina.Items.Add(((Disciplina)v.GetDado).Nome);

            // carrega os horarios que tem disciplina alocada
            for (int i = 0; i < lb_Horarios.Count; i++)
            {
                Vertice disciplina = Manager.GetDisciplinaAlocada(periodoSelecionado, v_Horarios[i]);

                if (disciplina != null)
                    lb_Horarios[i].Text = ((Disciplina)disciplina.GetDado).Nome;
            }

            this.groupBox1.Enabled = true;
        }

        private void cbDisciplina_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbDisciplina.SelectedIndex != -1)
            {
                Disciplina aux = new Disciplina(cbDisciplina.SelectedItem.ToString(), 0, 0);

                lbExibeProfessor.Enabled = true;
                lbExibeProfessor.Text = ((Professor)Manager.GetProfessorDeDisciplina(Manager.GetVerticeNaGrade(aux)).GetDado).Nome;

                btGravar.Enabled = true;
            }
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Confirma a alocação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.No)
                return;

            Label lb_Selec = null;

            Vertice vd = Manager.GetVerticeNaGrade(new Disciplina(cbDisciplina.SelectedItem.ToString(), 0, 0));
            Vertice vh = null;

            for (int i = 0; i < lb_Horarios.Count; i++)
            {
                if (lb_Horarios[i].BackColor != Color.White)
                {
                    lb_Selec = lb_Horarios[i];
                    vh = v_Horarios[i]; //a lista de labels está na mesma ordem da lista de vertices de horarios
                    break;
                }
            }

            if (Manager.TentarAlocar(vh, vd)) //ja realiza a alocação no grafo e grava no banco
            {
                MessageBox.Show("Alocação gravada!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                lb_Selec.Text = cbDisciplina.SelectedItem.ToString();

                foreach (Label lb in lb_Horarios)
                    lb.BackColor = Color.White;

                lbHorarioEscolhido.Text = null;

                groupBox2.Enabled = false;

                cbDisciplina.SelectedIndex = -1;
                lbExibeProfessor.Text = "";
                btGravar.Enabled = false;
            }
            else
                MessageBox.Show("Não foi possível gravar a alocação! Este professor já ministra uma disciplina neste mesmo horário, em outro período.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
    }
}