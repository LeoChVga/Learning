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
    public partial class Elimina_producto : Form
    {
        private string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
        public Elimina_producto()
        {
            InitializeComponent();
        }

        private void Elimina_producto_Load(object sender, EventArgs e)
        {
            conectar.ConnectionString = server;
            conectar.Open();

            //codigo para mostrar la info del data greedview
            agrgar_cosas ag = new agrgar_cosas();
            //mando el nombre de la tabla, el nombre del data grid y la id del producto 
            ag.mostrar_todos_productos("Productos", data_elim_prod);

            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();
        }

        private void data_elim_prod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                idprod_tb.Text = data_elim_prod.CurrentRow.Cells[0].Value.ToString();
                prod_id_tb.Text = data_elim_prod.CurrentRow.Cells[1].Value.ToString();

            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Elimina_Producto", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id_Producto", idprod_tb.Text);


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
            ag.mostrar_todos_productos("Productos", data_elim_prod);

            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();

            idprod_tb.Text = "";
            prod_id_tb.Text = "";

        }


    }
}
