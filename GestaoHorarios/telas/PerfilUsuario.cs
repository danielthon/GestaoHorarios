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
    public partial class PerfilUsuario : FormBase
    {
        public PerfilUsuario()
        {
            InitializeComponent();
        }

        private void CarregarUsuario()
        {
            lb_titulo.Text = "Configuração de Perfil";

            Manager.UsuarioLogado.CarregaAtributos(Manager.UsuarioLogado.ID);

            lblLogin.Text = Manager.UsuarioLogado.Login;

            if (Manager.UsuarioLogado.GetType() == typeof(Administrador))
                lblTipo.Text = "Administrador";
            else
                lblTipo.Text = "Professor";

            txtNome.Text = Manager.UsuarioLogado.Nome;

            NaoAlterarSenha();
        }

        public void AlterarSenha()
        {
            btnAlterarSenha.Enabled = false;

            label4.Enabled = true;
            label5.Enabled = true;

            txtNovaSenha.Text = "";
            txtConfirmarSenha.Text = "";
            txtNovaSenha.Enabled = true;
            txtConfirmarSenha.Enabled = true;
        }

        public void NaoAlterarSenha()
        {
            btnAlterarSenha.Enabled = true;

            label4.Enabled = false;
            label5.Enabled = false;

            txtNovaSenha.Text = "zzzzzzzz";
            txtConfirmarSenha.Text = "zzzzzzzz";
            txtNovaSenha.Enabled = false;
            txtConfirmarSenha.Enabled = false;
        }

        private void PerfilUsuario_Load(object sender, EventArgs e)
        {
            CarregarUsuario();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Manager.UsuarioLogado.Nome = txtNome.Text;

            if(txtNovaSenha.Enabled)
            {
                if (txtNovaSenha.Text != txtConfirmarSenha.Text)
                {
                    MessageBox.Show("Senha do campo de confirmação diferente da nova senha!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtConfirmarSenha.Focus();
                    return;
                }

                Manager.UsuarioLogado.Senha = txtNovaSenha.Text;
            }

            Manager.UsuarioLogado.SalvarNoBanco();

            MessageBox.Show("Perfil alterado com sucesso.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            NaoAlterarSenha();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CarregarUsuario();
        }

        private void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            AlterarSenha();
        }
    }
}
