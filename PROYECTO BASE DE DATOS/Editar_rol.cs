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
    public partial class Editar_rol : Form
    { private string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
       
        public Editar_rol()
        {
            InitializeComponent();
        }

        private void Editar_rol_btn_Click(object sender, EventArgs e)
        {
             conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Modifica_Rol", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Rol",Id_rol_tb.Text);
            cmd.Parameters.AddWithValue("@Nombre_Rol",Nombre_rol_tb.Text);
            cmd.Parameters.AddWithValue("@Descripcion_Rol",Descripcion_tb.Text);

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
            ag.mostrar_todos_Roles ("Clientes",datagrid_edit_rol);

            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();

            Id_rol_tb.Text = "";
            Nombre_rol_tb.Text = "";

            Descripcion_tb.Text = "";

        }

        private void datagrid_add_rol_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                Id_rol_tb.Text = datagrid_edit_rol.CurrentRow.Cells[0].Value.ToString();
                Nombre_rol_tb.Text= datagrid_edit_rol.CurrentRow.Cells[1].Value.ToString();
                Descripcion_tb.Text= datagrid_edit_rol.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            {

            }
        }

        private void Editar_rol_Load(object sender, EventArgs e)
        {
            agrgar_cosas ag = new agrgar_cosas();
            //mando el nombre de la tabla, el nombre del data grid y la id del producto 
            ag.mostrar_todos_Roles("Clientes", datagrid_edit_rol);
        }
    }
}
