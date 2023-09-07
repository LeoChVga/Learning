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
    public partial class Añadir_rol : Form
    {
        private string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
        string cadenaAleatoria = string.Empty;

        public Añadir_rol()
        {
            InitializeComponent();
        }

        private void añadir_rol_btn_Click(object sender, EventArgs e)
        {
            cadenaAleatoria = Guid.NewGuid().ToString();
            Id_rol_tb.Text= cadenaAleatoria;
            string id = Id_rol_tb.Text;

            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Alta_Rol", conectar);
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
            ag.mostrar_Roles ("Clientes", datagrid_add_rol, id);

            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();
        
        
        }

        private void Añadir_rol_Load(object sender, EventArgs e)
        {
            agrgar_cosas ag = new agrgar_cosas();
            ag.mostrar_todos_Roles("Roles", datagrid_add_rol);
        }
    }
}
