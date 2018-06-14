using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            foreach(Label lb in lb_Horarios)
                lb.Click += Click_lb_Horario;
        }

        private void ManutencaoHorarios_Load(object sender, EventArgs e)
        {
            lb_titulo.Text = "Alocação de Horários";
            lbExibeProfessor.Text = "";
        }

        private void Click_lb_Horario(object sender, EventArgs e)
        {
            foreach (Label lb in lb_Horarios)
                lb.BackColor = Color.White;

            Label clicado = (Label)sender;

            clicado.BackColor = Color.Yellow;
            
            switch(lb_Horarios.IndexOf(clicado))
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

        
    }
}
