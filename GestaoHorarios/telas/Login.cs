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

    public partial class Login : FormBase
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lb_titulo.Text = "";
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            BLL.Entidades.Administrador admin = new BLL.Entidades.Administrador(tbUsuario.Text, tbSenhaUsuario.Text);
            if (admin.ID_Usuario == 0)
            {
                BLL.Entidades.Professor prof = new BLL.Entidades.Professor(tbUsuario.Text, tbSenhaUsuario.Text);
                if (prof.ID_Usuario == 0)
                {
                    tbSenhaUsuario.Clear();
                    tbUsuario.Clear();
                    lbErroLogin.Visible = true;
                }
                else
                {
                    if (prof.SenhaCorreta() == true)
                    {
                        Home.ActiveForm.Visible = true;
                    }

                }
            }
            else
            {
                admin.SenhaCorreta();
            }
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {
            lbErroLogin.Visible = false;
        }
    }
}
