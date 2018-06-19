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
            this.picDrawing = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDrawing)).BeginInit();
            this.SuspendLayout();
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(170, 290);
            this.btLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(65, 35);
            this.btLogin.TabIndex = 39;
            this.btLogin.Text = "Entrar";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // tbSenhaUsuario
            // 
            this.tbSenhaUsuario.Location = new System.Drawing.Point(86, 252);
            this.tbSenhaUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.tbSenhaUsuario.Name = "tbSenhaUsuario";
            this.tbSenhaUsuario.PasswordChar = '•';
            this.tbSenhaUsuario.Size = new System.Drawing.Size(149, 25);
            this.tbSenhaUsuario.TabIndex = 38;
            // 
            // tbUsuario
            // 
            this.tbUsuario.AccessibleDescription = "";
            this.tbUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tbUsuario.Location = new System.Drawing.Point(86, 214);
            this.tbUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(149, 25);
            this.tbUsuario.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 217);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.MaximumSize = new System.Drawing.Size(76, 82);
            this.label1.MinimumSize = new System.Drawing.Size(30, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 40;
            this.label1.Text = "Usuário";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 255);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.MaximumSize = new System.Drawing.Size(76, 82);
            this.label2.MinimumSize = new System.Drawing.Size(30, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 41;
            this.label2.Text = "Senha";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picDrawing
            // 
            this.picDrawing.Image = global::GestaoHorarios.Properties.Resources.unlock;
            this.picDrawing.Location = new System.Drawing.Point(74, 61);
            this.picDrawing.Name = "picDrawing";
            this.picDrawing.Size = new System.Drawing.Size(128, 128);
            this.picDrawing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDrawing.TabIndex = 42;
            this.picDrawing.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 351);
            this.Controls.Add(this.picDrawing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.tbSenhaUsuario);
            this.Controls.Add(this.tbUsuario);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Controls.SetChildIndex(this.tbUsuario, 0);
            this.Controls.SetChildIndex(this.tbSenhaUsuario, 0);
            this.Controls.SetChildIndex(this.btLogin, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.picDrawing, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picDrawing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox tbSenhaUsuario;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picDrawing;
    }
}