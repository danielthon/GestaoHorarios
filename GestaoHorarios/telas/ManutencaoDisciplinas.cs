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
            Cursor.Current = Cursors.WaitCursor;

            LeituraArquivo.LerAquivo("ArquivoEntrada.txt", ' ');

            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == DialogResult.OK)
            //    LeituraArquivo.LerAquivo(ofd.FileName, ' ');

            MessageBox.Show("Importação finalizada!", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            Cursor.Current = Cursors.Default;
        }
    }
}
