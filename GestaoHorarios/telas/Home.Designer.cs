namespace GestaoHorarios.Telas
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.alocaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alocarHoráriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alocaçãoToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // alocaçãoToolStripMenuItem
            // 
            this.alocaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alocarHoráriosToolStripMenuItem});
            this.alocaçãoToolStripMenuItem.Name = "alocaçãoToolStripMenuItem";
            this.alocaçãoToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.alocaçãoToolStripMenuItem.Text = "Alocação";
            // 
            // alocarHoráriosToolStripMenuItem
            // 
            this.alocarHoráriosToolStripMenuItem.Name = "alocarHoráriosToolStripMenuItem";
            this.alocarHoráriosToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.alocarHoráriosToolStripMenuItem.Text = "Alocar Horários";
            this.alocarHoráriosToolStripMenuItem.Click += new System.EventHandler(this.alocarHoráriosToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Home";
            this.Text = "Home";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem alocaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alocarHoráriosToolStripMenuItem;
    }
}



