namespace GestaoHorarios.Telas
{
    partial class Login
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
            this.btLogin = new System.Windows.Forms.Button();
            this.tbSenhaUsuario = new System.Windows.Forms.TextBox();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbErroLogin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(170, 333);
            this.btLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(84, 43);
            this.btLogin.TabIndex = 39;
            this.btLogin.Text = "ENTRAR";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // tbSenhaUsuario
            // 
            this.tbSenhaUsuario.Location = new System.Drawing.Point(126, 219);
            this.tbSenhaUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSenhaUsuario.Name = "tbSenhaUsuario";
            this.tbSenhaUsuario.Size = new System.Drawing.Size(190, 29);
            this.tbSenhaUsuario.TabIndex = 38;
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(126, 172);
            this.tbUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(190, 29);
            this.tbUsuario.TabIndex = 37;
            this.tbUsuario.TextChanged += new System.EventHandler(this.tbUsuario_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 175);
            this.label1.MaximumSize = new System.Drawing.Size(98, 101);
            this.label1.MinimumSize = new System.Drawing.Size(39, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 40;
            this.label1.Text = "Usuário:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 222);
            this.label2.MaximumSize = new System.Drawing.Size(98, 101);
            this.label2.MinimumSize = new System.Drawing.Size(39, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 23);
            this.label2.TabIndex = 41;
            this.label2.Text = "Senha:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbErroLogin
            // 
            this.lbErroLogin.AutoSize = true;
            this.lbErroLogin.Enabled = false;
            this.lbErroLogin.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErroLogin.ForeColor = System.Drawing.Color.Red;
            this.lbErroLogin.Location = new System.Drawing.Point(122, 261);
            this.lbErroLogin.MaximumSize = new System.Drawing.Size(190, 100);
            this.lbErroLogin.MinimumSize = new System.Drawing.Size(190, 50);
            this.lbErroLogin.Name = "lbErroLogin";
            this.lbErroLogin.Size = new System.Drawing.Size(190, 50);
            this.lbErroLogin.TabIndex = 42;
            this.lbErroLogin.Text = "DADOS INCORRETOS";
            this.lbErroLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbErroLogin.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 408);
            this.Controls.Add(this.lbErroLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.tbSenhaUsuario);
            this.Controls.Add(this.tbUsuario);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Controls.SetChildIndex(this.tbUsuario, 0);
            this.Controls.SetChildIndex(this.tbSenhaUsuario, 0);
            this.Controls.SetChildIndex(this.btLogin, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lbErroLogin, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox tbSenhaUsuario;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbErroLogin;
    }
}