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
    public partial class Elimina_Rol : Form
    {private string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
        public Elimina_Rol()
        {
            InitializeComponent();
        }

        private void Eliminar_rol_btn_Click(object sender, EventArgs e)
        {

            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Elimina_Rol", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Rol", Id_rol_tb.Text);
        

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
            ag.mostrar_todos_Roles("Clientes", datagrid_elim_rol);
            MessageBox.Show("Rol eliminado exitosamente");
            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();

            Id_rol_tb.Text = "";
            Nombre_rol_tb.Text = "";

            Descripcion_tb.Text = "";
        }

        private void Elimina_Rol_Load(object sender, EventArgs e)
        {
            agrgar_cosas ag = new agrgar_cosas();
            //mando el nombre de la tabla, el nombre del data grid y la id del producto 
            ag.mostrar_todos_Roles("Clientes", datagrid_elim_rol);
        }

        private void datagrid_elim_rol_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                Id_rol_tb.Text = datagrid_elim_rol.CurrentRow.Cells[0].Value.ToString();
                Nombre_rol_tb.Text = datagrid_elim_rol.CurrentRow.Cells[1].Value.ToString();
                Descripcion_tb.Text = datagrid_elim_rol.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            {

            }
        }
    }
}
