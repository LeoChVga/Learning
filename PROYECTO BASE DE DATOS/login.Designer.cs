namespace PROYECTO_BASE_DE_DATOS
{
    partial class login
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
            this.Inicio_sesion = new System.Windows.Forms.Button();
            this.usuario = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Inicio_sesion
            // 
            this.Inicio_sesion.Location = new System.Drawing.Point(159, 213);
            this.Inicio_sesion.Name = "Inicio_sesion";
            this.Inicio_sesion.Size = new System.Drawing.Size(124, 40);
            this.Inicio_sesion.TabIndex = 0;
            this.Inicio_sesion.Text = "Iniciar sesion ";
            this.Inicio_sesion.UseVisualStyleBackColor = true;
            this.Inicio_sesion.Click += new System.EventHandler(this.Inicio_sesion_Click);
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(140, 116);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(166, 20);
            this.usuario.TabIndex = 1;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(140, 169);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(166, 20);
            this.password.TabIndex = 2;
            this.password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "USUARIO ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "CONTRASEÑA ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PROYECTO_BASE_DE_DATOS.Properties.Resources.logo_2;
            this.pictureBox1.Location = new System.Drawing.Point(48, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 282);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.Inicio_sesion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de sesion ";
            this.Load += new System.EventHandler(this.login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Inicio_sesion;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}