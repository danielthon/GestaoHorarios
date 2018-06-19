using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Entidades;

namespace GestaoHorarios.Telas
{
    public partial class Home : Form
    {
        public Home(Usuario user)
        {
            InitializeComponent();

            if (user.GetType() == typeof(Administrador))
            {
                this.Text += " - Administrador";

                manutToolStrip.DropDownItems.Add("Alocação de Horários").Click += new EventHandler((sender, e) => AbrirChildForm(sender, e, new ManutencaoHorarios())); 
                manutToolStrip.DropDownItems.Add("Disciplinas").Click += new EventHandler((sender, e) => AbrirChildForm(sender, e, new ManutencaoDisciplinas()));
                manutToolStrip.DropDownItems.Add("Usuários").Click += new EventHandler((sender, e) => AbrirChildForm(sender, e, new ManutencaoUsuarios()));
            }
            else
            {
                this.Text += " - Professor";

                manutToolStrip.Text = "Consulta";
                manutToolStrip.DropDownItems.Add("Horários").Click += new EventHandler((sender, e) => AbrirChildForm(sender, e, new ConsultaHorarios()));

                AbrirChildForm(null, null, new ConsultaHorarios());
            }

            configToolStrip.DropDownItems.Add("Meu Perfil").Click += new EventHandler((sender, e) => AbrirChildForm(sender, e, new PerfilUsuario()));
        }

        private void AbrirChildForm(object sender, EventArgs e, Form f)
        {
            foreach (Form aberto in Application.OpenForms)
            {
                if (aberto.GetType() == f.GetType()) //se ja existe um form desse tipo aberto
                {
                    f.Dispose();
                    return;
                }
            }

            f.MdiParent = this;
            f.Show();
        }
    }
}
