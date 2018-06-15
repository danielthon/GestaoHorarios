using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Arquivo;

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

        private void button1_Click(object sender, EventArgs e)
        {
            LeituraArquivo.LerAquivo("ArquivoEntrada.txt", ' ');
        }
    }
}
