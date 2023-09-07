namespace PROYECTO_BASE_DE_DATOS
{
    partial class Añadir_categoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Añadir_categoria));
            this.Nombre_cat_tb = new System.Windows.Forms.TextBox();
            this.Descripcion_tb = new System.Windows.Forms.TextBox();
            this.Id_cat_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datagrid_add_cat = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.añadir_cat_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_add_cat)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Nombre_cat_tb
            // 
            this.Nombre_cat_tb.Location = new System.Drawing.Point(97, 43);
            this.Nombre_cat_tb.Name = "Nombre_cat_tb";
            this.Nombre_cat_tb.Size = new System.Drawing.Size(125, 20);
            this.Nombre_cat_tb.TabIndex = 5;
            // 
            // Descripcion_tb
            // 
            this.Descripcion_tb.Location = new System.Drawing.Point(97, 69);
            this.Descripcion_tb.Name = "Descripcion_tb";
            this.Descripcion_tb.Size = new System.Drawing.Size(125, 20);
            this.Descripcion_tb.TabIndex = 4;
            // 
            // Id_cat_tb
            // 
            this.Id_cat_tb.Enabled = false;
            this.Id_cat_tb.Location = new System.Drawing.Point(97, 17);
            this.Id_cat_tb.Name = "Id_cat_tb";
            this.Id_cat_tb.Size = new System.Drawing.Size(125, 20);
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
            // datagrid_add_cat
            // 
            this.datagrid_add_cat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_add_cat.Location = new System.Drawing.Point(12, 12);
            this.datagrid_add_cat.Name = "datagrid_add_cat";
            this.datagrid_add_cat.Size = new System.Drawing.Size(295, 107);
            this.datagrid_add_cat.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.Nombre_cat_tb);
            this.panel1.Controls.Add(this.Descripcion_tb);
            this.panel1.Controls.Add(this.Id_cat_tb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(313, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 107);
            this.panel1.TabIndex = 3;
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
            // añadir_cat_btn
            // 
            this.añadir_cat_btn.Location = new System.Drawing.Point(344, 126);
            this.añadir_cat_btn.Name = "añadir_cat_btn";
            this.añadir_cat_btn.Size = new System.Drawing.Size(146, 44);
            this.añadir_cat_btn.TabIndex = 5;
            this.añadir_cat_btn.Text = "Añadir Categoria";
            this.añadir_cat_btn.UseVisualStyleBackColor = true;
            this.añadir_cat_btn.Click += new System.EventHandler(this.añadir_cat_btn_Click);
            // 
            // Añadir_categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 171);
            this.Controls.Add(this.datagrid_add_cat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.añadir_cat_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Añadir_categoria";
            this.Text = "Añadir categoria";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_add_cat)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Nombre_cat_tb;
        private System.Windows.Forms.TextBox Descripcion_tb;
        private System.Windows.Forms.TextBox Id_cat_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView datagrid_add_cat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button añadir_cat_btn;

    }
}