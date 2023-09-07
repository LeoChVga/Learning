namespace PROYECTO_BASE_DE_DATOS
{
    partial class Elimina_Rol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Elimina_Rol));
            this.Eliminar_rol_btn = new System.Windows.Forms.Button();
            this.datagrid_elim_rol = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Nombre_rol_tb = new System.Windows.Forms.TextBox();
            this.Descripcion_tb = new System.Windows.Forms.TextBox();
            this.Id_rol_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_elim_rol)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Eliminar_rol_btn
            // 
            this.Eliminar_rol_btn.Location = new System.Drawing.Point(498, 126);
            this.Eliminar_rol_btn.Name = "Eliminar_rol_btn";
            this.Eliminar_rol_btn.Size = new System.Drawing.Size(146, 44);
            this.Eliminar_rol_btn.TabIndex = 5;
            this.Eliminar_rol_btn.Text = "Eliminar Rol";
            this.Eliminar_rol_btn.UseVisualStyleBackColor = true;
            this.Eliminar_rol_btn.Click += new System.EventHandler(this.Eliminar_rol_btn_Click);
            // 
            // datagrid_elim_rol
            // 
            this.datagrid_elim_rol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_elim_rol.Location = new System.Drawing.Point(12, 12);
            this.datagrid_elim_rol.Name = "datagrid_elim_rol";
            this.datagrid_elim_rol.Size = new System.Drawing.Size(423, 107);
            this.datagrid_elim_rol.TabIndex = 4;
            this.datagrid_elim_rol.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_elim_rol_CellContentDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.Nombre_rol_tb);
            this.panel1.Controls.Add(this.Descripcion_tb);
            this.panel1.Controls.Add(this.Id_rol_tb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(441, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 107);
            this.panel1.TabIndex = 3;
            // 
            // Nombre_rol_tb
            // 
            this.Nombre_rol_tb.Location = new System.Drawing.Point(78, 43);
            this.Nombre_rol_tb.Name = "Nombre_rol_tb";
            this.Nombre_rol_tb.Size = new System.Drawing.Size(125, 20);
            this.Nombre_rol_tb.TabIndex = 5;
            // 
            // Descripcion_tb
            // 
            this.Descripcion_tb.Location = new System.Drawing.Point(78, 69);
            this.Descripcion_tb.Name = "Descripcion_tb";
            this.Descripcion_tb.Size = new System.Drawing.Size(125, 20);
            this.Descripcion_tb.TabIndex = 4;
            // 
            // Id_rol_tb
            // 
            this.Id_rol_tb.Enabled = false;
            this.Id_rol_tb.Location = new System.Drawing.Point(78, 17);
            this.Id_rol_tb.Name = "Id_rol_tb";
            this.Id_rol_tb.Size = new System.Drawing.Size(125, 20);
            this.Id_rol_tb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Rol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(34, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Rol ";
            // 
            // Elimina_Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 174);
            this.Controls.Add(this.Eliminar_rol_btn);
            this.Controls.Add(this.datagrid_elim_rol);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Elimina_Rol";
            this.Text = "Elimina Rol";
            this.Load += new System.EventHandler(this.Elimina_Rol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_elim_rol)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Eliminar_rol_btn;
        private System.Windows.Forms.DataGridView datagrid_elim_rol;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Nombre_rol_tb;
        private System.Windows.Forms.TextBox Descripcion_tb;
        private System.Windows.Forms.TextBox Id_rol_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}