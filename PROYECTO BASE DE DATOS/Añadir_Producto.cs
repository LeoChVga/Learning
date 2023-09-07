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
    public partial class Añadir_Producto : Form
    {
        private string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
        string cadenaAleatoria = string.Empty;
        string cadenaAleatoria2 = string.Empty;
        string cadenaAleatoria3 = string.Empty;


        //Metodo para llenar combobox para ponere nombre de categoria y nombre de proveedor
        public void llenar_cmbx(string sql, ComboBox cmb)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmb.DataSource = dt;
                }
            }


        }
      

        public Añadir_Producto()
        {
            InitializeComponent();


            //procedimientos para agregar informacion a los combobox 

            string sqlConsulta = @"SELECT Id_categoria,Nombre_Categoria FROM Categoria";
            llenar_cmbx(sqlConsulta, idcat);
            idcat.ValueMember = "Id_categoria";
            idcat.DisplayMember = "Nombre_Categoria";

            string sqlConsulta1 = @"SELECT Id_Provedor,Nombre_Proveedor from Provedores";
            llenar_cmbx(sqlConsulta1, provcmbx);
            provcmbx.ValueMember = "Id_Provedor";
            provcmbx.DisplayMember = "Nombre_Proveedor";

        }

        private void boton_añadir_producto_Click(object sender, EventArgs e)
        {
           // --------------------------------------------------
            //new guid genera una cadena aleatoria que se usa para la id de todo lo que necesite 
            cadenaAleatoria = Guid.NewGuid().ToString();
            id_ubicacion_tb.Text = cadenaAleatoria;
            idubicacion_prod_tb.Text = cadenaAleatoria;
            cadenaAleatoria2 = Guid.NewGuid().ToString();
            idproducto_tb.Text = cadenaAleatoria2;
            //guardo la id del producto en una variable para usarla en el metodo de mostar producto
            string id = idproducto_tb.Text;
            cadenaAleatoria3 = Guid.NewGuid().ToString();
            idcaracteristicas_prod_tb.Text = cadenaAleatoria3;
            idcaracteristicas_tb.Text = cadenaAleatoria3;
            //--------------------------------------------------------
            //convierto las variables necesarias a int, double etc
            double precio_venta = Convert.ToDouble(precio_producto_tb.Text);
            int existencias = Convert.ToInt32(Existencia_prod_tb.Text);
            int año = Convert.ToInt32(año_tb.Text);
            //se hace la conexion y se abre 
            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Alta_Producto", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            //se le dan valor a todas las variables 
            cmd.Parameters.AddWithValue("@Id_Producto", idproducto_tb.Text);
            cmd.Parameters.AddWithValue("@Nombre_Producto", nombre_prod_tb.Text);
            cmd.Parameters.AddWithValue("@Precio_Venta", precio_producto_tb.Text);
            cmd.Parameters.AddWithValue("@Id_Caracteristicas", idcaracteristicas_prod_tb.Text);
            cmd.Parameters.AddWithValue("@Existencias", Existencia_prod_tb.Text);
            cmd.Parameters.AddWithValue("@Id_Ubicacion", id_ubicacion_tb.Text);
            cmd.Parameters.AddWithValue("@Id_Caractes", idcaracteristicas_tb.Text);
            cmd.Parameters.AddWithValue("@Marca_Auto", marca_auto_tb.Text);
            cmd.Parameters.AddWithValue("@Modelo_Auto", modelo_auto_tb.Text);
            cmd.Parameters.AddWithValue("@Año_Auto", año_tb.Text);
            cmd.Parameters.AddWithValue("@Unidades_De_Medida", unidad_medida_tb.Text);
            cmd.Parameters.AddWithValue("@Id_Ubic", id_ubicacion_tb.Text);
            cmd.Parameters.AddWithValue("@Estante", estante_tb.Text);
            cmd.Parameters.AddWithValue("@Nivel_Estante", nivel_tb.Text);
            cmd.Parameters.AddWithValue("@Seccion_Nivel", seccion_nivel_tb.Text);
            cmd.Parameters.AddWithValue("@Subseccion_Nivel", subseccion_tb.Text);
            //--------------------------------------------------------------------------
            
               //hago un sqlcoman para poder guarrdar el select donde se almacena la id del nombre de la categoria y otro para 
               // el nombre del proveedor
            SqlCommand cmd3 = conectar.CreateCommand();
            cmd3.CommandText = "select Id_Categoria from Categoria where Nombre_Categoria='" + idcat.Text + "' ";
            //en este string guardo el resultado del select
            string ID_categoria = ((string)cmd3.ExecuteScalar());
            //se hace la linea de codigo para anadir la id categoria y la id provedor
            cmd.Parameters.AddWithValue("@Id_Categoria", ID_categoria);

            cmd3.CommandText = "select Id_Provedor from Provedores where Nombre_Proveedor='" + provcmbx.Text + "'";
            string Id_prov = ((string)cmd3.ExecuteScalar());
            cmd.Parameters.AddWithValue("@Id_Provedor", Id_prov);

           


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
            ag.mostrar_productos ("Productos", dataGridView1,id);

            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();
            idproducto_tb.Text = "";
            nombre_prod_tb.Text = "";
            precio_producto_tb.Text = "";
            Existencia_prod_tb.Text = "";
            idcat.Text = "";
            idcaracteristicas_prod_tb.Text = "";
            idcaracteristicas_tb.Text = "";
            marca_auto_tb.Text = "";
            modelo_auto_tb.Text = "";
            año_tb.Text = "";
            unidad_medida_tb.Text = "";

            idubicacion_prod_tb.Text = "";
            id_ubicacion_tb.Text = "";
            estante_tb.Text = "";
            nivel_tb.Text = "";
            seccion_nivel_tb.Text = "";
            subseccion_tb.Text = "";
            provcmbx.Text = "";

        }










    }
    }

