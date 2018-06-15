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

            if (user.GetType() == typeof(Professor))
                MessageBox.Show("TESTE: Professor");
            else
                MessageBox.Show("TESTE: Administrador");
        }

        private void alocaçãoDeHoráriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManutencaoHorarios childForm = new ManutencaoHorarios();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}
