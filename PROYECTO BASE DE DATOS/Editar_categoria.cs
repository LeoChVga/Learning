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
    public partial class Editar_categoria : Form
    {
        private string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
        string cadenaAleatoria = string.Empty;
        public Editar_categoria()
        {
            InitializeComponent();
        }

        private void Editar_categoria_Load(object sender, EventArgs e)
        {

            conectar.ConnectionString = server;
            conectar.Open();

            //codigo para mostrar la info del data greedview
            agrgar_cosas ag = new agrgar_cosas();
            //mando el nombre de la tabla, el nombre del data grid y la id del producto 
            ag.mostrar_todos_categoria("Categoria",datagrid_edit_cat);

            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();

        }

        private void datagrid_edit_cat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                Id_cat_tb.Text = datagrid_edit_cat.CurrentRow.Cells[0].Value.ToString();
                Nombre_cat_tb.Text = datagrid_edit_cat.CurrentRow.Cells[1].Value.ToString();
                Descripcion_tb.Text = datagrid_edit_cat.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            {
            }
        }

        private void editar_cat_btn_Click(object sender, EventArgs e)
        {
            conectar.ConnectionString = server;
            conectar.Open();
            SqlCommand cmd = new SqlCommand("Modifica_Categoria", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Categoria", Id_cat_tb.Text);
            cmd.Parameters.AddWithValue("@Nombre_Categoria",Nombre_cat_tb.Text);
            cmd.Parameters.AddWithValue("@Descripcion",Descripcion_tb.Text);


            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            //codigo para mostrar la info del data greedview
            agrgar_cosas ag = new agrgar_cosas();
            //mando el nombre de la tabla, el nombre del data grid y la id del producto 
            ag.mostrar_todos_categoria("Categoria",datagrid_edit_cat);
            conectar.Close();
            Id_cat_tb.Text = "";
            Nombre_cat_tb.Text = "";
            Descripcion_tb.Text = "";
        }
    }
}
