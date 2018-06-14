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
    public partial class ManutencaoDisciplinas : FormBase
    {
        public ManutencaoDisciplinas()
        {
            InitializeComponent();
        }

        private void ManutencaoDisciplinas_Load(object sender, EventArgs e)
        {
            lb_titulo.Text = "Manutenção de Disciplinas";
        }
    }
}
