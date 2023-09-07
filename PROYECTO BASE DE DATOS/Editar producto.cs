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
    public partial class Editar_producto : Form
    {
        private string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();
        public Editar_producto()
        {
            InitializeComponent();

            string sqlConsulta = @"SELECT Id_categoria,Nombre_Categoria FROM Categoria";
            llenar_cmbx(sqlConsulta, idcat);
            idcat.ValueMember = "Id_categoria";
            idcat.DisplayMember = "Nombre_Categoria";

            string sqlConsulta1 = @"SELECT Id_Provedor,Nombre_Proveedor from Provedores";
            llenar_cmbx(sqlConsulta1, provcmbx);
            provcmbx.ValueMember = "Id_Provedor";
            provcmbx.DisplayMember = "Nombre_Proveedor";
        }

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

   

        private void Editar_producto_Load(object sender, EventArgs e)
        {
            conectar.ConnectionString = server;
            conectar.Open();

            //codigo para mostrar la info del data greedview
            agrgar_cosas ag = new agrgar_cosas();
            //mando el nombre de la tabla, el nombre del data grid y la id del producto 
            ag.mostrar_todos_productos("Productos",data_prod_edit);

            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();
        }

        private void data_prod_edit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                idproducto_tb.Text = data_prod_edit.CurrentRow.Cells[0].Value.ToString();
                nombre_prod_tb.Text = data_prod_edit.CurrentRow.Cells[1].Value.ToString();
                precio_producto_tb.Text = data_prod_edit.CurrentRow.Cells[2].Value.ToString();
                Existencia_prod_tb.Text = data_prod_edit.CurrentRow.Cells[3].Value.ToString();
                idcat.Text = data_prod_edit.CurrentRow.Cells[4].Value.ToString();
                idcaracteristicas_prod_tb.Text = data_prod_edit.CurrentRow.Cells[5].Value.ToString();
                idcaracteristicas_tb.Text = data_prod_edit.CurrentRow.Cells[5].Value.ToString();
                marca_auto_tb.Text = data_prod_edit.CurrentRow.Cells[6].Value.ToString();
                modelo_auto_tb.Text = data_prod_edit.CurrentRow.Cells[7].Value.ToString();
                año_tb.Text = data_prod_edit.CurrentRow.Cells[8].Value.ToString();
                unidad_medida_tb.Text= data_prod_edit.CurrentRow.Cells[9].Value.ToString();

                idubicacion_prod_tb.Text = data_prod_edit.CurrentRow.Cells[10].Value.ToString();
                id_ubicacion_tb.Text = data_prod_edit.CurrentRow.Cells[10].Value.ToString();
                estante_tb.Text = data_prod_edit.CurrentRow.Cells[11].Value.ToString();
                nivel_tb.Text = data_prod_edit.CurrentRow.Cells[12].Value.ToString();
                seccion_nivel_tb.Text = data_prod_edit.CurrentRow.Cells[13].Value.ToString();
                subseccion_tb.Text = data_prod_edit.CurrentRow.Cells[14].Value.ToString();
                provcmbx.Text = data_prod_edit.CurrentRow.Cells[15].Value.ToString();
                

            }
            catch
            {

            }
        }

        private void boton_añadir_producto_Click(object sender, EventArgs e)
        {

            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Modifica_Producto", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

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
            ag.mostrar_todos_productos("Productos", data_prod_edit);

            //cerramos conexion despues de realizar todos los procedimientos 
            conectar.Close();
            idproducto_tb.Text =""; 
            nombre_prod_tb.Text = "";
            precio_producto_tb.Text =""; 
            Existencia_prod_tb.Text = "";
            idcat.Text = "";
            idcaracteristicas_prod_tb.Text ="";
            idcaracteristicas_tb.Text = "";
            marca_auto_tb.Text = "";
            modelo_auto_tb.Text = "";
            año_tb.Text = "";
            unidad_medida_tb.Text ="";

            idubicacion_prod_tb.Text =""; 
            id_ubicacion_tb.Text ="";
            estante_tb.Text = "";
            nivel_tb.Text = "";
            seccion_nivel_tb.Text =""; 
            subseccion_tb.Text = "";
            provcmbx.Text = "";

        }



    }
}
