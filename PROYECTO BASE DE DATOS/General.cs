using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PROYECTO_BASE_DE_DATOS
{
    public partial class General : Form
    {
        private string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        SqlConnection conectar = new SqlConnection();

        string cadenaAleatoria = string.Empty;
        string cadenaAleatoria2 = string.Empty;
        string cadenaAleatoria3 = string.Empty;
        string cadenaAleatoria4 = string.Empty;


        string prod_lbl;
        string preciolbl;
        string cantidad;
        string comprobar = "";


        public General()
        {
            InitializeComponent();
            nombreusuariolbl.Text = Iniciosesion.NombreCompleto;

        }

        private void General_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void añadirNuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Añadir_Producto new_prod = new Añadir_Producto();
            new_prod.Show();
        }

        private void añadirClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Añadir_Cliente cl = new Añadir_Cliente();
            cl.Show();
        }

        //private void añadirEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    add_us us = new add_us();
        //    us.Show();
        //}

        private void añadirRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Añadir_rol ar = new Añadir_rol();
            ar.Show();
        }

        //private void añadirProvedorToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Añadir_proveedor ap = new Añadir_proveedor();
        //    ap.Show();
        //}

        private void añadirCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Añadir_categoria ac = new Añadir_categoria();
            ac.Show();
        }

        private void editarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editar_producto ep = new Editar_producto();
            ep.Show();
        }

        //private void Productos1_Click(object sender, EventArgs e)
        //{
        //conectar.ConnectionString = server;
        //conectar.Open();

        ////codigo para mostrar la info del data greedview
        //agrgar_cosas ag = new agrgar_cosas();
        ////mando el nombre de la tabla, el nombre del data grid y la id del producto 
        //ag.mostrar_todos_productos("Productos", data_prod);

        ////cerramos conexion despues de realizar todos los procedimientos 
        //conectar.Close();
        //}

        private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Elimina_producto ep = new Elimina_producto();
            ep.Show();
        }

        private void editarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editar_categoria ec = new Editar_categoria();
            ec.Show();
        }

        private void elimianarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar_categoria ec = new Eliminar_categoria();
            ec.Show();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            cadenaAleatoria = Guid.NewGuid().ToString();
            cadenaAleatoria2 = Guid.NewGuid().ToString();
            id_cliente.Text = cadenaAleatoria;
            id_dir_cl_tb.Text = cadenaAleatoria2;
            string iddi = cadenaAleatoria2;


            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Alta_Cliente", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Cliente", id_cliente.Text);
            string id_c = id_cliente.Text;
            cmd.Parameters.AddWithValue("@Nombre_Cliente", nom.Text);
            cmd.Parameters.AddWithValue("@Apellido_Cliente", ap.Text);
            cmd.Parameters.AddWithValue("@Tel_1_Cliente", t1.Text);
            cmd.Parameters.AddWithValue("@Tel_2_Cliente", t2.Text);
            cmd.Parameters.AddWithValue("@Id_Direccion", id_dir_cl_tb.Text);
            cmd.Parameters.AddWithValue("@Email", em.Text);
            cmd.Parameters.AddWithValue("@Id_Dir", id_dir_cl_tb.Text);
            cmd.Parameters.AddWithValue("@Ciudad", ciudad_tb.Text);
            cmd.Parameters.AddWithValue("@Colonia", colonia_tb.Text);
            cmd.Parameters.AddWithValue("@Calle", calle_tb.Text);
            cmd.Parameters.AddWithValue("@Avenida", avenida_tb.Text);
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
            ag.mostrar_clientes("Clientes", clientes_datta);
            conectar.Close();
            id_cliente.Text = "";
            nom.Text = "";
            ap.Text = "";
            t1.Text = "";
            t2.Text = "";
            em.Text = "";

            id_dir_cl_tb.Text = "";
            ciudad_tb.Text = "";
            colonia_tb.Text = "";
            calle_tb.Text = "";
            avenida_tb.Text = "";
            numca.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Modifica_Cliente", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Cliente", id_cliente.Text);
            string id_c = id_cliente.Text;
            cmd.Parameters.AddWithValue("@Nombre_Cliente", nom.Text);
            cmd.Parameters.AddWithValue("@Apellido_Cliente", ap.Text);
            cmd.Parameters.AddWithValue("@Tel_1_Cliente", t1.Text);
            cmd.Parameters.AddWithValue("@Tel_2_Cliente", t2.Text);
            cmd.Parameters.AddWithValue("@Id_Direccion", id_dir_cl_tb.Text);
            cmd.Parameters.AddWithValue("@Email", em.Text);
            cmd.Parameters.AddWithValue("@Id_Dir", id_dir_cl_tb.Text);
            cmd.Parameters.AddWithValue("@Ciudad", ciudad_tb.Text);
            cmd.Parameters.AddWithValue("@Colonia", colonia_tb.Text);
            cmd.Parameters.AddWithValue("@Calle", calle_tb.Text);
            cmd.Parameters.AddWithValue("@Avenida", avenida_tb.Text);
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
            ag.mostrar_clientes("Clientes", clientes_datta);
            conectar.Close();

            id_cliente.Text = "";
            nom.Text = "";
            ap.Text = "";
            t1.Text = "";
            t2.Text = "";
            em.Text = "";

            id_dir_cl_tb.Text = "";
            ciudad_tb.Text = "";
            colonia_tb.Text = "";
            calle_tb.Text = "";
            avenida_tb.Text = "";
            numca.Text = "";
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Elimina_Cliente", conectar);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id_Cliente", id_cliente.Text);
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
            ag.mostrar_clientes("Clientes", clientes_datta);
            conectar.Close();


            id_cliente.Text = "";
            nom.Text = "";
            ap.Text = "";
            t1.Text = "";
            t2.Text = "";
            em.Text = "";

            id_dir_cl_tb.Text = "";
            ciudad_tb.Text = "";
            colonia_tb.Text = "";
            calle_tb.Text = "";
            avenida_tb.Text = "";
            numca.Text = "";
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





        

        private void add_nuevo_usuario_Click(object sender, EventArgs e)
        {

            SqlCommand cmd3 = conectar.CreateCommand();

            cadenaAleatoria = Guid.NewGuid().ToString();
            cadenaAleatoria2 = Guid.NewGuid().ToString();
            Id_usuario_tb.Text = cadenaAleatoria;
            Id_dir_us_tb.Text = cadenaAleatoria2;


            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Alta_Usuario", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd3.CommandText = "select Id_Rol from Roles_Usuario where Nombre_Rol='" + rol_cb.Text + "'";

            cmd.Parameters.AddWithValue("@Id_Usuario", Id_usuario_tb.Text);
            string id = Id_usuario_tb.Text;
            cmd.Parameters.AddWithValue("@usuario", usuario_tb.Text);
            cmd.Parameters.AddWithValue("@Password_Usuario", password_tb.Text);

            cmd.Parameters.AddWithValue("@Nombre_Usuario", Nombre_tb.Text);
            cmd.Parameters.AddWithValue("@Apellido_Usuario", apellidos_tb.Text);
            cmd.Parameters.AddWithValue("@Telefono_1_usuario", tel1_tb.Text);
            cmd.Parameters.AddWithValue("@Telefono_2_usuario", tel2_tb.Text);
            cmd.Parameters.AddWithValue("@Id_Direccion_usuario", Id_dir_us_tb.Text);
            cmd.Parameters.AddWithValue("@Email", Email_tb.Text);
            cmd.Parameters.AddWithValue("@Id_Dir", Id_dir_us_tb.Text);
            cmd.Parameters.AddWithValue("@Ciudad", ciudad_tb.Text);
            cmd.Parameters.AddWithValue("@Colonia", colonia_tb.Text);
            cmd.Parameters.AddWithValue("@Calle", calle_tb.Text);
            cmd.Parameters.AddWithValue("@Avenida", avenida_us_tb.Text);
            cmd.Parameters.AddWithValue("@Num_Domicilio", num_casa_tb.Text);


            cmd3.CommandText = "select Id_Rol from Roles_Usuario where Nombre_Rol='" + rol_cb.Text + "'";
            //en este string guardo el resultado del select
            string ID_rol = ((string)cmd3.ExecuteScalar());
            //se hace la linea de codigo para anadir la id categoria y la id provedor
            cmd.Parameters.AddWithValue("@Id_Rol", ID_rol);

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
            ag.mostrar_usuarios("Usuarios", data_usuario);
            conectar.Close();
        }

        private void edit_usuario_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = conectar.CreateCommand();
            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Modifica_Usuario", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd3.CommandText = "select Id_Rol from Roles_Usuario where Nombre_Rol='" + rol_cb.Text + "'";

            cmd.Parameters.AddWithValue("@Id_Usuario", Id_usuario_tb.Text);
            string id = Id_usuario_tb.Text;
            cmd.Parameters.AddWithValue("@usuario", usuario_tb.Text);
            cmd.Parameters.AddWithValue("@Password_Usuario", password_tb.Text);

            cmd.Parameters.AddWithValue("@Nombre_Usuario", Nombre_tb.Text);
            cmd.Parameters.AddWithValue("@Apellido_Usuario", apellidos_tb.Text);
            cmd.Parameters.AddWithValue("@Telefono_1_usuario", tel1_tb.Text);
            cmd.Parameters.AddWithValue("@Telefono_2_usuario", tel2_tb.Text);
            cmd.Parameters.AddWithValue("@Id_Direccion_usuario", Id_dir_us_tb.Text);
            cmd.Parameters.AddWithValue("@Email",Email_tb.Text);
            cmd.Parameters.AddWithValue("@Id_Dir",Id_dir_us_tb.Text);
            cmd.Parameters.AddWithValue("@Ciudad",ciudad_tb.Text);
            cmd.Parameters.AddWithValue("@Colonia",colonia_tb.Text);
            cmd.Parameters.AddWithValue("@Calle", calle.Text);
            cmd.Parameters.AddWithValue("@Avenida", avenida_tb.Text);
            cmd.Parameters.AddWithValue("@Num_Domicilio", num_casa_tb.Text);


            cmd3.CommandText = "select Id_Rol from Roles_Usuario where Nombre_Rol='" + rol_cb.Text + "'";
            //en este string guardo el resultado del select
            string ID_rol = ((string)cmd3.ExecuteScalar());
            //se hace la linea de codigo para anadir la id categoria y la id provedor
            cmd.Parameters.AddWithValue("@Id_Rol", ID_rol);

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
            ag.mostrar_usuarios("Usuarios", data_usuario);
            conectar.Close();

            Id_usuario_tb.Text = "";
            usuario_tb.Text = "";
            password_tb.Text = "";
            Nombre_tb.Text = "";
            //rol_cb.Text = "";
            apellidos_tb.Text = "";
            Email_tb.Text = "";
            tel1_tb.Text = "";
            tel2_tb.Text = "";
            Id_dir_us_tb.Text = "";
            ciudad.Text = "";
            colonia.Text = "";
            avenida_us_tb.Text = "";
            calle.Text = "";
            num_casa_tb.Text = "";
        }





        private void General_Load(object sender, EventArgs e)//--------------------------------------------------------------------------------
        {
            login nelo= new login();
            nelo.Hide();
            
            conectar.ConnectionString = server;
            conectar.Open();

            agrgar_cosas ag = new agrgar_cosas();
            ag.mostrar_usuarios("Usuarios", data_usuario);
            ag.mostrar_todos_productos("Productos", clientes_datta);
            ag.mostrar_clientes("Clientes", clientes_datta);
            ag.mostrar_provedores("Provedores", data_prov);

            ag.mostrar_todos_productos_compras("Productos", data_prod_comp);
            id_cab_ventas = cadenaAleatoria2;
            cant_prod_Select.Text = "1";

            cadenaAleatoria2 = Guid.NewGuid().ToString();

            string id_cab_compr = cadenaAleatoria2;

            //mando el nombre de la tabla, el nombre del data grid y la id del producto 
            ag.mostrar_todos_productos("Productos", data_prod);

            string sqlConsulta = @"select Id_Rol,Nombre_Rol from Roles_Usuario";
            llenar_cmbx(sqlConsulta, rol_cb);
            rol_cb.ValueMember = "Id_Rol";
            rol_cb.DisplayMember = "Nombre_Rol";

            ///////////////////////7
            string sqlConsulta2 = @"SELECT Id_categoria,Nombre_Categoria FROM Categoria";
            llenar_cmbx(sqlConsulta2, idcat_cb_c);
            idcat_cb_c.ValueMember = "Id_categoria";
            idcat_cb_c.DisplayMember = "Nombre_Categoria";

            string sqlConsulta13 = @"SELECT Id_Provedor,Nombre_Proveedor from Provedores";
            llenar_cmbx(sqlConsulta13, provcmbx_c);
            provcmbx_c.ValueMember = "Id_Provedor";
            provcmbx_c.DisplayMember = "Nombre_Proveedor";



            conectar.Close();
        }

        private void eliminar_us_Click(object sender, EventArgs e)
        {
            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Elimina_Usuario", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd3.CommandText = "select Id_Rol from Roles_Usuario where Nombre_Rol='" + rol_cb.Text + "'";

            cmd.Parameters.AddWithValue("@Id_Usuario", Id_usuario_tb.Text);
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
            ag.mostrar_usuarios("Usuarios", data_usuario);
            conectar.Close();

            Id_usuario_tb.Text = "";
            usuario_tb.Text = "";
            password_tb.Text = "";
            Nombre_tb.Text = "";
            //rol_cb.Text = "";
            apellidos_tb.Text = "";
            Email_tb.Text = "";
            tel1_tb.Text = "";
            tel2_tb.Text = "";
            Id_dir_us_tb.Text = "";
            ciudad.Text = "";
            colonia.Text = "";
            avenida_us_tb.Text = "";
            calle.Text = "";
            num_casa_tb.Text = "";
        }


        //ALTA PROVEDOR
        private void button8_Click(object sender, EventArgs e)
        {
            cadenaAleatoria = Guid.NewGuid().ToString();
            id_proveedor.Text = cadenaAleatoria;
            cadenaAleatoria2 = Guid.NewGuid().ToString();

            iddir.Text = cadenaAleatoria2;

            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Alta_Provedor", conectar);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Id_Provedor", id_proveedor.Text);
            string id_p = id_proveedor.Text;
            cmd.Parameters.AddWithValue("@Nombre_Provedor", nom_prov.Text);
            cmd.Parameters.AddWithValue("@telefono", t1.Text);
            cmd.Parameters.AddWithValue("@Id_Direccion", iddir.Text);
            cmd.Parameters.AddWithValue("@Pagina_Web", pag_web.Text);
            cmd.Parameters.AddWithValue("@Email", email_prov.Text);
            cmd.Parameters.AddWithValue("@Id_Dir", iddir.Text);
            cmd.Parameters.AddWithValue("@Ciudad", ciudad_prov_tb.Text);
            cmd.Parameters.AddWithValue("@Colonia", colonia_prov_tb.Text);
            cmd.Parameters.AddWithValue("@Calle", calle_prov_tb.Text);
            cmd.Parameters.AddWithValue("@Avenida", avenida_prov_tb.Text);
            cmd.Parameters.AddWithValue("@Num_Domicilio", Num_dom_tb.Text);


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
            ag.mostrar_provedores("Provedores", data_prov);
            conectar.Close();
            id_proveedor.Text = "";
            nom_prov.Text = "";
            tel_prov_tb.Text = "";
            email_prov.Text = "";
            iddir.Text = "";
            pag_web.Text = "";
            ciudad_prov_tb.Text = "";
            colonia_prov_tb.Text = "";
            calle_prov_tb.Text = "";
            avenida_prov_tb.Text = "";
            Num_dom_tb.Text = "";
        }

        
        //MODIFICAR PROVEDOR
        private void button7_Click(object sender, EventArgs e)
        {
            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Modifica_Provedor", conectar);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Id_Provedor", id_proveedor.Text);

            cmd.Parameters.AddWithValue("@Nombre_Provedor", nom_prov.Text);
            cmd.Parameters.AddWithValue("@telefono", tel_prov_tb.Text);
            cmd.Parameters.AddWithValue("@Id_Direccion", iddir.Text);
            cmd.Parameters.AddWithValue("@Pagina_Web", pag_web.Text);
            cmd.Parameters.AddWithValue("@Email", email_prov.Text);
            cmd.Parameters.AddWithValue("@Id_Dir", iddir.Text);
            cmd.Parameters.AddWithValue("@Ciudad", ciudad_prov_tb.Text);
            cmd.Parameters.AddWithValue("@Colonia", colonia_prov_tb.Text);
            cmd.Parameters.AddWithValue("@Calle", calle_prov_tb.Text);
            cmd.Parameters.AddWithValue("@Avenida", avenida_prov_tb.Text);
            cmd.Parameters.AddWithValue("@Num_Domicilio", Num_dom_tb.Text);
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
            ag.mostrar_provedores("Provedores", data_prov);
            conectar.Close();
            id_proveedor.Text = "";
            nom_prov.Text = "";
            tel_prov_tb.Text = "";
            email_prov.Text = "";
            iddir.Text = "";
            pag_web.Text = "";
            ciudad_prov_tb.Text = "";
            colonia_prov_tb.Text = "";
            calle_prov_tb.Text = "";
            avenida_prov_tb.Text = "";
            Num_dom_tb.Text = "";

        }
        //codigo para eliminar provedor
        private void button6_Click(object sender, EventArgs e)
        {
            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Elmina_Provedor", conectar);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Id_Prove", id_proveedor.Text);
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
            ag.mostrar_provedores("Provedores", data_prov);
            conectar.Close();
            id_proveedor.Text = "";
            nom_prov.Text = "";
            tel_prov_tb.Text = "";
            email_prov.Text = "";
            iddir.Text = "";
            pag_web.Text = "";
            ciudad_prov_tb.Text = "";
            colonia_prov_tb.Text = "";
            calle_prov_tb.Text = "";
            avenida_prov_tb.Text = "";
            Num_dom_tb.Text = "";
        }
        string id_cab_ventas;
        //codigo para crear la cabecera de la venta
        private void button5_Click(object sender, EventArgs e)
        {

            lbl_n_v.Text = nom.Text + " " + ap.Text;
            lbl_t1.Text = t1.Text;
            lbl_t2.Text = t2.Text;

            cadenaAleatoria2 = Guid.NewGuid().ToString();
            id_cab_ventas = cadenaAleatoria2;


            lbl_direccion.Text = ciudad_tb.Text + ", cd." + colonia_tb.Text + ", " + calle_tb.Text + " y " + avenida_tb.Text + " No. " + numca.Text;
            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Alta_Cabecera_Venta", conectar);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Id_Cliente", id_cliente.Text);
            string id;
            Iniciosesion ini = new Iniciosesion();
            id = ini.id_us();
            cmd.Parameters.AddWithValue("@Id_Usuario", id);
            cmd.Parameters.AddWithValue("@Id_ventasc", id_cab_ventas);

            try
            {
                cmd.ExecuteNonQuery();
                
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
            conectar.Close();

        }
        //procedimiento para procd. almacenado alta detalles venta////////////////////////////////////////////////////////////////////////////////////
        //-----------------------------------------------------------------------------------------------------------------------------------------------------
        private void add_carrito_btn_Click(object sender, EventArgs e)
        {
            cadenaAleatoria2 = Guid.NewGuid().ToString();

            string id_det_ven = cadenaAleatoria2;
            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Alta_Ventas_Detalle", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            if (desc_prod_select.Text.Length == 0)
            {
                desc_prod_select.Text = "0";
            }
            if (cant_prod_Select.Text.Length == 0)
            {
                cant_prod_Select.Text = "0";
            }

            cmd.Parameters.AddWithValue("@Id_Ventas_Detalle", id_det_ven);
            cmd.Parameters.AddWithValue("@Id_Ventas_Cabecera", id_cab_ventas);
            cmd.Parameters.AddWithValue("@Id_Producto", id_prod_Select);
            cmd.Parameters.AddWithValue("@Precio_Producto", Precio_prod_select.Text);
            cmd.Parameters.AddWithValue("@Cantidad_pRODUCTO", cant_prod_Select.Text);
            cmd.Parameters.AddWithValue("@Descuento", desc_prod_select.Text);
            string descuento2 = Convert.ToString(desc_prod_select.Text);

            double descuento = Convert.ToDouble(descuento2);

            descuento = descuento / 100;

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
            conectar.Close();
            conectar.Open();
            ag.Mostrar_prod_carrito("Ventas_Detalles", dta_prod_car, id_cab_ventas);

            SqlCommand cmd1 = new SqlCommand("select SUM(Productos.Precio_Venta*Ventas_Detalles.Cantidad_Producto) as SubTotal from Ventas_Detalles inner join Productos on Ventas_Detalles.Id_Producto=Productos.Id_Producto  where Id_Ventas_cabecera='" + id_cab_ventas + "'", conectar);
            SqlDataReader registro = cmd1.ExecuteReader();
            if (registro.Read())
            {
                subt.Text = registro["SubTotal"].ToString();
            }
            registro.Close();
            conectar.Close();


            conectar.Open();
            SqlCommand cmd2 = new SqlCommand("select SUM((Productos.Precio_Venta* " + descuento + "  )*Ventas_Detalles.Cantidad_Producto) as descuento from Ventas_Detalles inner join Productos on Ventas_Detalles.Id_Producto= Productos.Id_Producto where Id_Ventas_cabecera='" + id_cab_ventas + "'", conectar);
            SqlDataReader registro2 = cmd2.ExecuteReader();
            if (registro2.Read())
            {
                desc_tb.Text = registro2["descuento"].ToString();
            }


            conectar.Close();

            registro2.Close();


            conectar.Close();


            conectar.Open();
            SqlCommand cmd3 = new SqlCommand("select SUM((((Productos.Precio_Venta*Ventas_Detalles.Cantidad_Producto)-(Productos.Precio_Venta* " + descuento + " )*Ventas_Detalles.Cantidad_Producto))*(0.16)) as Iva from Ventas_Detalles inner join Productos on Ventas_Detalles.Id_Producto= Productos.Id_Producto where Id_Ventas_cabecera='" + id_cab_ventas + "'", conectar);
            SqlDataReader registro3 = cmd3.ExecuteReader();
            if (registro3.Read())
            {
                ivatb.Text = registro3["Iva"].ToString();
            }


            conectar.Close();

            registro3.Close();

            conectar.Open();
            SqlCommand cmd4 = new SqlCommand("select SUM((((Productos.Precio_Venta*Ventas_Detalles.Cantidad_Producto)-(Productos.Precio_Venta*'" + descuento + "')*Ventas_Detalles.Cantidad_Producto))*(0.16)+((Productos.Precio_Venta*Ventas_Detalles.Cantidad_Producto)-(Productos.Precio_Venta*'" + descuento + "')*Ventas_Detalles.Cantidad_Producto)) as Total from Ventas_Detalles inner join Productos on Ventas_Detalles.Id_Producto= Productos.Id_Producto where Id_Ventas_cabecera='" + id_cab_ventas + "'", conectar);
            SqlDataReader registro4 = cmd4.ExecuteReader();
            if (registro4.Read())
            {
                Total_tb.Text = registro4["Total"].ToString();
            }


            conectar.Close();

            registro4.Close();

            //id_det_ven = "";
            // id_cab_ventas = "";
            id_prod_Select = "";
            Precio_prod_select.Text = "";
            cant_prod_Select.Text = "1";
            desc_prod_select.Text = "";


        }


        //Hacer um boton en ventas que diga nueva venta para que cuando lo selecciones se limpien los textbox y el datagrid ademas de generar
        //una id de cabecera venta nueva
        //Hacer que la id de cabecera venta se genere al hacer load el programa
        //editar como se agregan los campos de el procedimiento alta cabecera ventas para que se guarde ahi la id cabecera que se genera el hacer load 
        //la idea seria que 



        string id_prod_Select;
       
        private void nueva_ventabtn_Click(object sender, EventArgs e)
        {
            cadenaAleatoria3 = Guid.NewGuid().ToString();
            comprobar = id_cab_ventas;
            id_cab_ventas = cadenaAleatoria3;
         
            lbl_direccion.Text = "";
            lbl_n_v.Text = "";
            lbl_t1.Text = "";
            lbl_t2.Text = "";
            lbl_n_v.Text = "";

            subt.Text = "";
            Total_tb.Text = "";
            desc_tb.Text = "";
            ivatb.Text = "";

            
        }

        private void Productos1_Click(object sender, EventArgs e)
        {
            agrgar_cosas ag = new agrgar_cosas();
            ag.mostrar_todos_productos_compras("Productos", data_prod);
        }

        private void data_prod_comp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                idproducto_tb_c.Text = data_prod_comp.CurrentRow.Cells[0].Value.ToString();
                nombre_prod_tb_c.Text = data_prod_comp.CurrentRow.Cells[1].Value.ToString();
                idcat_cb_c.Text = data_prod_comp.CurrentRow.Cells[2].Value.ToString();
                provcmbx_c.Text = data_prod_comp.CurrentRow.Cells[3].Value.ToString();

                Existencia_prod_tb_c.Text = data_prod_comp.CurrentRow.Cells[10].Value.ToString();


                idcaracteristicas_tb_c.Text = data_prod_comp.CurrentRow.Cells[4].Value.ToString();
                marca_auto_tb_c.Text = data_prod_comp.CurrentRow.Cells[5].Value.ToString();
                modelo_auto_tb_c.Text = data_prod_comp.CurrentRow.Cells[6].Value.ToString();
                año_tb_c.Text = data_prod_comp.CurrentRow.Cells[7].Value.ToString();
                unidad_medida_tb_c.Text = data_prod_comp.CurrentRow.Cells[8].Value.ToString();


                id_ubicacion_tb_c.Text = data_prod_comp.CurrentRow.Cells[9].Value.ToString();
                estante_tb_c.Text = data_prod_comp.CurrentRow.Cells[11].Value.ToString();
                nivel_tb_c.Text = data_prod_comp.CurrentRow.Cells[12].Value.ToString();
                seccion_nivel_tb_c.Text = data_prod_comp.CurrentRow.Cells[13].Value.ToString();
                subseccion_tb_c.Text = data_prod_comp.CurrentRow.Cells[14].Value.ToString();


            }
            catch
            {

            }
        }

        private void comprar_producto_Click(object sender, EventArgs e)
        {
            cadenaAleatoria2 = Guid.NewGuid().ToString();

            string id_cab_compr = cadenaAleatoria2;

            string id;
            Iniciosesion ini = new Iniciosesion();
            id = ini.id_us();
            conectar.ConnectionString = server;
            conectar.Open();
            //se crea el cmd para usar un procedimiento almacenado
            SqlCommand cmd = new SqlCommand("Alta_Cabecera_Compra", conectar);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Id_Compras", id_cab_compr);
            cmd.Parameters.AddWithValue("@Id_Usuario", id);//////////////////////////////////////////////


            SqlCommand cmd3 = conectar.CreateCommand();
            cmd3.CommandText = "select Id_Provedor from Provedores where Nombre_Proveedor='" + provcmbx_c.Text + "'";
            string Id_prov = ((string)cmd3.ExecuteScalar());

            cmd.Parameters.AddWithValue("@Id_Provedorr", Id_prov);
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
            ag.mostrar_todos_productos_compras("Productos", data_prod_comp);
            


            
            cadenaAleatoria4 = Guid.NewGuid().ToString();
            string id_det_com = cadenaAleatoria4;
            

            SqlCommand cmd10 = new SqlCommand("Alta_Compras_Detalle",conectar);
            cmd10.CommandType = CommandType.StoredProcedure;
            int cantidad = Convert.ToInt32(cantidad_tb_c.Text);
            double precio = Convert.ToDouble( precio_producto_tb_c.Text);
            cmd10.Parameters.AddWithValue("@Id_Compras_Detalle",id_det_com);
            cmd10.Parameters.AddWithValue("@Id_Cabecera_Compras",id_cab_compr);
            cmd10.Parameters.AddWithValue("@Id_Producto",idproducto_tb_c.Text);//////////////////////////////////////////////
            cmd10.Parameters.AddWithValue("@Precio",precio);//////////////////////////////////////////////
            cmd10.Parameters.AddWithValue("@Cantidad",cantidad);//////////////////////////////////////////////
            
            

           
            try
            {
                cmd10.ExecuteNonQuery();
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.ToString());
                throw;
            }
          
            conectar.Close();
            
            precio_producto_tb_c.Text = "";
            cantidad_tb_c.Text = "";
            ag.mostrar_todos_productos_compras("Productos",data_prod_comp);

        }

        private void data_prod_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                id_prod_Select = data_prod.CurrentRow.Cells[0].Value.ToString();
                prod_selec.Text = data_prod.CurrentRow.Cells[1].Value.ToString();
                // data_prod_edit.CurrentRow.Cells[1].Value.ToString();
                Precio_prod_select.Text = data_prod.CurrentRow.Cells[2].Value.ToString();
                cant_prod_Select.Text = "";

            }
            catch { }
        }

        private void clientes_datta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                id_cliente.Text = clientes_datta.CurrentRow.Cells[0].Value.ToString();
                nom.Text = clientes_datta.CurrentRow.Cells[1].Value.ToString();
                ap.Text = clientes_datta.CurrentRow.Cells[2].Value.ToString();
                t1.Text = clientes_datta.CurrentRow.Cells[3].Value.ToString();
                t2.Text = clientes_datta.CurrentRow.Cells[4].Value.ToString();
                em.Text = clientes_datta.CurrentRow.Cells[6].Value.ToString();

                id_dir_cl_tb.Text = clientes_datta.CurrentRow.Cells[5].Value.ToString();
                ciudad_tb.Text = clientes_datta.CurrentRow.Cells[7].Value.ToString();
                colonia_tb.Text = clientes_datta.CurrentRow.Cells[8].Value.ToString();
                calle_tb.Text = clientes_datta.CurrentRow.Cells[9].Value.ToString();
                avenida_tb.Text = clientes_datta.CurrentRow.Cells[10].Value.ToString();
                numca.Text = clientes_datta.CurrentRow.Cells[11].Value.ToString();



            }
            catch
            {

            }
        }

       

        private void data_usuario_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Id_usuario_tb.Text = data_usuario.CurrentRow.Cells[0].Value.ToString();
                usuario_tb.Text = data_usuario.CurrentRow.Cells[1].Value.ToString();
                password_tb.Text = data_usuario.CurrentRow.Cells[2].Value.ToString();
                Nombre_tb.Text = data_usuario.CurrentRow.Cells[3].Value.ToString();
                rol_cb.Text = data_usuario.CurrentRow.Cells[5].Value.ToString();
                apellidos_tb.Text = data_usuario.CurrentRow.Cells[4].Value.ToString();
                Email_tb.Text = data_usuario.CurrentRow.Cells[8].Value.ToString();
                tel1_tb.Text = data_usuario.CurrentRow.Cells[6].Value.ToString();
                tel2_tb.Text = data_usuario.CurrentRow.Cells[7].Value.ToString();
                Id_dir_us_tb.Text = data_usuario.CurrentRow.Cells[9].Value.ToString();
                ciudad.Text = data_usuario.CurrentRow.Cells[10].Value.ToString();
                colonia.Text = data_usuario.CurrentRow.Cells[11].Value.ToString();
                avenida_us_tb.Text = data_usuario.CurrentRow.Cells[12].Value.ToString();
                calle.Text = data_usuario.CurrentRow.Cells[13].Value.ToString();
                num_casa_tb.Text = data_usuario.CurrentRow.Cells[14].Value.ToString();
            }
            catch
            {

            }
        }

        private void data_prov_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                id_proveedor.Text = data_prov.CurrentRow.Cells[0].Value.ToString();
                nom_prov.Text = data_prov.CurrentRow.Cells[1].Value.ToString();
                tel_prov_tb.Text = data_prov.CurrentRow.Cells[2].Value.ToString();
                email_prov.Text = data_prov.CurrentRow.Cells[3].Value.ToString();
                iddir.Text = data_prov.CurrentRow.Cells[4].Value.ToString();
                pag_web.Text = data_prov.CurrentRow.Cells[5].Value.ToString();
                ciudad_prov_tb.Text = data_prov.CurrentRow.Cells[6].Value.ToString();
                colonia_prov_tb.Text = data_prov.CurrentRow.Cells[7].Value.ToString();
                calle_prov_tb.Text = data_prov.CurrentRow.Cells[8].Value.ToString();
                avenida_prov_tb.Text = data_prov.CurrentRow.Cells[9].Value.ToString();
                Num_dom_tb.Text = data_prov.CurrentRow.Cells[10].Value.ToString();

            }
            catch
            {

            }
        }

       

        private void añadirNuevoRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Añadir_rol ar = new Añadir_rol();
            ar.Show();
        }

        private void editarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Editar_rol er = new Editar_rol();
            er.Show();
        }

        private void eliminarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Elimina_Rol er = new Elimina_Rol();
            er.Show();
        }


    }
       
    }
