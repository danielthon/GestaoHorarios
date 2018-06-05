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
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
            pnHeader.BackColor = SystemColors.ControlLightLight;
        }

        bool mouseClicked;
        Point clickedAt;

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClicked)
            {
                this.Location = new Point(this.Parent.PointToClient(MousePosition).X - clickedAt.X, this.Parent.PointToClient(MousePosition).Y - clickedAt.Y);
            }
        }

        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            mouseClicked = true;
            clickedAt = this.PointToClient(MousePosition);
            //clickedAt.X += 7;
            //clickedAt.Y += 28;
        }

        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
