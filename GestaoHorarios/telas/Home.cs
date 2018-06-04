﻿using System;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void alocarHoráriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlocacaoHorarios childForm = new AlocacaoHorarios();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}
