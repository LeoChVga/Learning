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
    public partial class Añadir_Cliente : Form
    {
          private string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
        string cadenaAleatoria = string.Empty;
        string cadenaAleatoria2 = string.Empty;
        string cadenaAleatoria3 = string.Empty;
        public Añadir_Cliente()
        {
            InitializeComponent();
        }

        private void boton_añadir_cliente_Click(object sender, EventArgs e)
        {
            cadenaAleatoria = Guid.NewGuid().ToString();
            cadenaAleatoria2 = Guid.NewGuid().ToString();
            id_cliente.Text = cadenaAleatoria;
            id_dir_cl_tb.Text = cadenaAleatoria2;
           iddir.Text = cadenaAleatoria2;


            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Alta_Cliente", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Cliente",id_cliente.Text);
            string id_c = id_cliente.Text;
	        cmd.Parameters.AddWithValue("@Nombre_Cliente",nom.Text); 
	        cmd.Parameters.AddWithValue("@Apellido_Cliente",ap.Text); 
	        cmd.Parameters.AddWithValue("@Tel_1_Cliente",t1.Text); 
	        cmd.Parameters.AddWithValue("@Tel_2_Cliente",t2.Text); 
	        cmd.Parameters.AddWithValue("@Id_Direccion",id_dir_cl_tb.Text); 
	        cmd.Parameters.AddWithValue("@Email",em.Text); 
	        cmd.Parameters.AddWithValue("@Id_Dir",iddir.Text); 
	       cmd.Parameters.AddWithValue("@Ciudad",ciudad_tb.Text); 
	       cmd.Parameters.AddWithValue("@Colonia",colonia_tb.Text); 
	       cmd.Parameters.AddWithValue("@Calle",calle_tb.Text); 
	       cmd.Parameters.AddWithValue("@Avenida",avenida_tb.Text);
           cmd.Parameters.AddWithValue("@Num_Domicilio", numca.Text);
           try
           {
               cmd.ExecuteNonQuery();
           }
           catch (SqlException EX)
           {
               MessageBox.Show(EX.ToString());
               throw;
           }
           agrgar_cosas ag = new agrgar_cosas();
           //ag.mostrar_clientes("Clientes",a_us_grid,id_c);
           conectar.Close();
        }

        private void Añadir_Cliente_Load(object sender, EventArgs e)
        {
            
        }

        
        }
    }
