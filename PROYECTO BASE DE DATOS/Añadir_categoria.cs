using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PROYECTO_BASE_DE_DATOS
{
    public partial class Añadir_categoria : Form
    {
        private string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
        string cadenaAleatoria = string.Empty;
        public Añadir_categoria()
        {
            InitializeComponent();
        }

        private void añadir_cat_btn_Click(object sender, EventArgs e)
        {
            cadenaAleatoria = Guid.NewGuid().ToString();
            Id_cat_tb.Text = cadenaAleatoria;
            

            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Alta_Categoria", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Categoria",Id_cat_tb.Text);
            cmd.Parameters.AddWithValue("@Nombre_Categoria",Nombre_cat_tb.Text );
            cmd.Parameters.AddWithValue("@Descripcion_Categoria",Descripcion_tb.Text);


            try
           {
               cmd.ExecuteNonQuery();
           }
           catch (SqlException EX)
           {
               MessageBox.Show(EX.ToString());
               throw;
           }
            string id = Id_cat_tb.Text;
           agrgar_cosas ag = new agrgar_cosas();
           ag.mostrar_Categorias("Categoria",datagrid_add_cat,id);
           conectar.Close();
        }
        }
    }

