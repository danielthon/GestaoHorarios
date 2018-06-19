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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuAdmin = new System.Windows.Forms.MenuStrip();
            this.manutToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuAdmin
            // 
            this.menuAdmin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuAdmin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuAdmin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manutToolStrip,
            this.configToolStrip});
            this.menuAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuAdmin.Size = new System.Drawing.Size(1010, 27);
            this.menuAdmin.TabIndex = 1;
            this.menuAdmin.Text = "menuStrip1";
            // 
            // manutToolStrip
            // 
            this.manutToolStrip.Name = "manutToolStrip";
            this.manutToolStrip.Size = new System.Drawing.Size(92, 21);
            this.manutToolStrip.Text = "Manutenção";
            // 
            // configToolStrip
            // 
            this.configToolStrip.Name = "configToolStrip";
            this.configToolStrip.Size = new System.Drawing.Size(98, 21);
            this.configToolStrip.Text = "Configuração";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GestaoHorarios.Properties.Resources.bg01;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1010, 579);
            this.Controls.Add(this.menuAdmin);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "Gestão de Horários";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuAdmin.ResumeLayout(false);
            this.menuAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem manutToolStrip;
        private System.Windows.Forms.ToolStripMenuItem configToolStrip;
    }
}