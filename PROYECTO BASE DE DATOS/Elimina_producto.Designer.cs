namespace PROYECTO_BASE_DE_DATOS
{
    partial class Elimina_producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Elimina_producto));
            this.button1 = new System.Windows.Forms.Button();
            this.data_elim_prod = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.idprod_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prod_id_tb = new System.Windows.Forms.TextBox();
            this.Productolbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_elim_prod)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Elimiar Producto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // data_elim_prod
            // 
            this.data_elim_prod.BackgroundColor = System.Drawing.Color.LightGray;
            this.data_elim_prod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_elim_prod.Location = new System.Drawing.Point(12, 12);
            this.data_elim_prod.Name = "data_elim_prod";
            this.data_elim_prod.Size = new System.Drawing.Size(616, 270);
            this.data_elim_prod.TabIndex = 1;
            this.data_elim_prod.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_elim_prod_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.idprod_tb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.prod_id_tb);
            this.panel1.Controls.Add(this.Productolbl);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(634, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 270);
            this.panel1.TabIndex = 2;
            // 
            // idprod_tb
            // 
            this.idprod_tb.Enabled = false;
            this.idprod_tb.Location = new System.Drawing.Point(71, 16);
            this.idprod_tb.Name = "idprod_tb";
            this.idprod_tb.Size = new System.Drawing.Size(150, 20);
            this.idprod_tb.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id Producto";
            // 
            // prod_id_tb
            // 
            this.prod_id_tb.Location = new System.Drawing.Point(71, 50);
            this.prod_id_tb.Name = "prod_id_tb";
            this.prod_id_tb.Size = new System.Drawing.Size(150, 20);
            this.prod_id_tb.TabIndex = 2;
            // 
            // Productolbl
            // 
            this.Productolbl.AutoSize = true;
            this.Productolbl.Location = new System.Drawing.Point(15, 53);
            this.Productolbl.Name = "Productolbl";
            this.Productolbl.Size = new System.Drawing.Size(50, 13);
            this.Productolbl.TabIndex = 1;
            this.Productolbl.Text = "Producto";
            // 
            // Elimina_producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 317);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.data_elim_prod);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Elimina_producto";
            this.Text = "Elimina producto";
            this.Load += new System.EventHandler(this.Elimina_producto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.data_elim_prod)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView data_elim_prod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox idprod_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox prod_id_tb;
        private System.Windows.Forms.Label Productolbl;
    }
}