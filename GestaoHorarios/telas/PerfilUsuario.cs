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

        private void PerfilUsuario_Load(object sender, EventArgs e)
        {
            lb_titulo.Text = "Configuração de Perfil";

            lblLogin.Text = Manager.UsuarioLogado.Login;

            if (Manager.UsuarioLogado.GetType() == typeof(Administrador))
                lblTipo.Text = "Administrador";
            else
                lblTipo.Text = "Professor";

            txtNome.Text = Manager.UsuarioLogado.Nome;

            txtNovaSenha.Text = "zzzzzzzz";
            txtConfirmarSenha.Text = "zzzzzzzz";
        }
    }
}
