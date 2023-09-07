namespace PROYECTO_BASE_DE_DATOS
{
    partial class Editar_categoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editar_categoria));
            this.datagrid_edit_cat = new System.Windows.Forms.DataGridView();
            this.editar_cat_btn = new System.Windows.Forms.Button();
            this.Nombre_cat_tb = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Descripcion_tb = new System.Windows.Forms.TextBox();
            this.Id_cat_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_edit_cat)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagrid_edit_cat
            // 
            this.datagrid_edit_cat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_edit_cat.Location = new System.Drawing.Point(12, 12);
            this.datagrid_edit_cat.Name = "datagrid_edit_cat";
            this.datagrid_edit_cat.Size = new System.Drawing.Size(360, 144);
            this.datagrid_edit_cat.TabIndex = 7;
            this.datagrid_edit_cat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_edit_cat_CellContentClick);
            // 
            // editar_cat_btn
            // 
            this.editar_cat_btn.Location = new System.Drawing.Point(127, 94);
            this.editar_cat_btn.Name = "editar_cat_btn";
            this.editar_cat_btn.Size = new System.Drawing.Size(146, 44);
            this.editar_cat_btn.TabIndex = 8;
            this.editar_cat_btn.Text = "Editar Categoria";
            this.editar_cat_btn.UseVisualStyleBackColor = true;
            this.editar_cat_btn.Click += new System.EventHandler(this.editar_cat_btn_Click);
            // 
            // Nombre_cat_tb
            // 
            this.Nombre_cat_tb.Location = new System.Drawing.Point(97, 43);
            this.Nombre_cat_tb.Name = "Nombre_cat_tb";
            this.Nombre_cat_tb.Size = new System.Drawing.Size(209, 20);
            this.Nombre_cat_tb.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.Nombre_cat_tb);
            this.panel1.Controls.Add(this.editar_cat_btn);
            this.panel1.Controls.Add(this.Descripcion_tb);
            this.panel1.Controls.Add(this.Id_cat_tb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(378, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 143);
            this.panel1.TabIndex = 6;
            // 
            // Descripcion_tb
            // 
            this.Descripcion_tb.Location = new System.Drawing.Point(97, 69);
            this.Descripcion_tb.Name = "Descripcion_tb";
            this.Descripcion_tb.Size = new System.Drawing.Size(209, 20);
            this.Descripcion_tb.TabIndex = 4;
            // 
            // Id_cat_tb
            // 
            this.Id_cat_tb.Enabled = false;
            this.Id_cat_tb.Location = new System.Drawing.Point(97, 17);
            this.Id_cat_tb.Name = "Id_cat_tb";
            this.Id_cat_tb.Size = new System.Drawing.Size(209, 20);
            this.Id_cat_tb.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre Categroa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Categoria";
            // 
            // Editar_categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 163);
            this.Controls.Add(this.datagrid_edit_cat);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Editar_categoria";
            this.Text = "Editar categoria";
            this.Load += new System.EventHandler(this.Editar_categoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_edit_cat)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagrid_edit_cat;
        private System.Windows.Forms.Button editar_cat_btn;
        private System.Windows.Forms.TextBox Nombre_cat_tb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Descripcion_tb;
        private System.Windows.Forms.TextBox Id_cat_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}