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
            // CONEXAO

            string erro;
            while (!Manager.AbrirConexao(out erro))
            {
                DialogResult dr = MessageBox.Show(erro, "Erro de conexão", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                if (dr == DialogResult.Cancel)
                {
                    Application.Exit();
                    break;
                }
            }

            // FIM CONEXAO

            lb_titulo.Text = "";
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            Administrador admin = new Administrador(tbUsuario.Text, tbSenhaUsuario.Text);

            if (admin.ID_Usuario == 0)
            {
                Professor prof = new Professor(tbUsuario.Text, tbSenhaUsuario.Text);

                if (prof.ID_Usuario == 0)
                {
                    tbSenhaUsuario.Clear();
                    tbUsuario.Clear();

                    MessageBox.Show("Login incorreto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                    //lbErroLogin.Visible = true;
                }
                else
                {
                    if (prof.SenhaCorreta())
                    {
                        this.Hide();

                        Home h = new Home(prof);
                        h.ShowDialog();

                        this.Close();
                    }
                    else
                    {
                        tbSenhaUsuario.Clear();
                        MessageBox.Show("Senha incorreta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                       
                }
            }
            else
            {
                if (admin.SenhaCorreta())
                {
                    this.Hide();

                    Home h = new Home(admin);
                    h.ShowDialog();

                    this.Close();
                }
                else
                {
                    tbSenhaUsuario.Clear();
                    MessageBox.Show("Senha incorreta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {
            lbErroLogin.Visible = false;
        }
    }
}
