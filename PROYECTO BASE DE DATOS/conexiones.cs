using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;



namespace PROYECTO_BASE_DE_DATOS
{
    class agrgar_cosas
    {
        public void Mostrar_prod_carrito(string tabla, DataGridView grid, string idcab)
        {
            string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select p.Nombre_Producto,p.Precio_Venta,vd.Cantidad_Producto,vd.Descuento from Ventas_Detalles vd inner join Cabecera_Venta cv on cv.Id_Venta=vd.Id_Ventas_cabecera inner join Productos p on vd.Id_Producto =p.Id_Producto where cv.Id_Venta='" + idcab + "'";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }
            conectar.Close();
        }
        public void mostrar_todos_categoria(string tabla, DataGridView grid)
        {
            string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select*from Categoria";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }
            conectar.Close();
        }

        public void mostrar_todos_productos_compras(string tabla, DataGridView grid)
        {
            string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select p.Id_Producto,p.Nombre_Producto, c.Nombre_Categoria,pr.Nombre_Proveedor,p.Id_Catacteristicas, car.Marca_Auto,car.Modelo_Auto,car.Año_Auto,car.Unidad_De_Medida ,ub.Id_Ubicacion,p.Existencias,ub.Estante,ub.Nivel_Estante,ub.Seccion_Nivel,ub.Sub_Seccion_Nivel from Productos p inner join Categoria c on  p.Id_Categoria=c.Id_Categoria inner join Ubicacion ub on p.Id_Ubicacion=ub.Id_Ubicacion inner join Caracteristicas car on p.Id_Catacteristicas=car.Id_Catacteristicas  inner join Provedores pr on p.Id_Provedor=pr.Id_Provedor"; 
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }
            conectar.Close();
        }
        public void mostrar_todos_productos(string tabla, DataGridView grid)
        {
            string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select p.Id_Producto,p.Nombre_Producto,p.Precio_Venta,p.Existencias, c.Nombre_Categoria,p.Id_Catacteristicas, car.Marca_Auto,car.Modelo_Auto,car.Año_Auto,car.Unidad_De_Medida ,ub.Id_Ubicacion,ub.Estante,ub.Nivel_Estante,ub.Seccion_Nivel,ub.Sub_Seccion_Nivel,pr.Nombre_Proveedor from Productos p inner join Categoria c on  p.Id_Categoria=c.Id_Categoria inner join Ubicacion ub on p.Id_Ubicacion=ub.Id_Ubicacion inner join Caracteristicas car on p.Id_Catacteristicas=car.Id_Catacteristicas  inner join Provedores pr on p.Id_Provedor=pr.Id_Provedor ";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }
            conectar.Close();
        }
        public void mostrar_productos(string tabla, DataGridView grid, string idproducto)
        {
            string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select Nombre_Producto,Precio_Venta,Existencias,Nombre_Categoria,car.Marca_Auto,car.Modelo_Auto,car.Año_Auto, Nombre_Proveedor, ub.Estante,ub.Nivel_Estante,ub.Seccion_Nivel,ub.Sub_Seccion_Nivel from " + tabla + " p inner join Categoria c on  p.Id_Categoria=c.Id_Categoria inner join Provedores pr on p.Id_Provedor=pr.Id_Provedor inner join Ubicacion ub on p.Id_Ubicacion=ub.Id_Ubicacion inner join Caracteristicas car on p.Id_Catacteristicas=car.Id_Catacteristicas where Id_Producto='" + idproducto + "' ";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }
            conectar.Close();
        }
        public void mostrar_clientes(string tabla, DataGridView grid)
        {
            string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select Id_Clientes,Nombre_Cliente,Apellido_Cliente,telefono_1_Cliente,Telefono_2_cliente,d.Id_Direccion,Email,Ciudad,Colonia,Calle,avenida,Numero_De_Domicilio from Clientes c inner join Direccion d on c.Id_Direccion=d.Id_Direccion";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }
            conectar.Close();
        }

        public void mostrar_usuarios(string tabla, DataGridView grid)
        {
            string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select Id_Usuario ,Usuario,Password_usuario,Nombre_Usuario,Apellido_Usuario,Roles_Usuario.Nombre_Rol,Telefono_1_usuario,Telefono_2_usuario,Email,Direccion.Id_Direccion,Direccion.Ciudad,Direccion.Colonia,Direccion.avenida,Direccion.Calle,Direccion.Numero_De_Domicilio from usuarios inner join Roles_Usuario on Usuarios.Id_Rol=Roles_Usuario.Id_Rol inner join Direccion on Usuarios.Id_Direccion_Usuario=Direccion.Id_Direccion ";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }
            conectar.Close();
        }
        public void mostrar_Roles(string tabla, DataGridView grid, string id)
        {
            string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select *from Roles_Usuario where Id_Rol='" + id + "' ";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }
            conectar.Close();
        }

        public void mostrar_todos_Roles(string tabla, DataGridView grid)
        {
            string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select *from Roles_Usuario";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }
            conectar.Close();
        }
        public void mostrar_provedores(string tabla, DataGridView grid)
        {
            string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select Id_Provedor,Nombre_Proveedor,Telefono,Email,Direccion.Id_Direccion,Pagina_Web,Ciudad,Colonia,calle,avenida,Numero_De_Domicilio from Provedores inner join Direccion on Provedores.Id_Direccion=Direccion.Id_Direccion";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }
            conectar.Close();
        }

        public void mostrar_Categorias(string tabla, DataGridView grid, string id)
        {
            string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = server;
            conectar.Open();
            string query = "select Nombre_Categoria,Descripcion_Categoria from Categoria where Id_Categoria='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error" + ex, ToString());
                throw;
            }
            conectar.Close();
        }

        //CODIGOS PARA VENTAS 
       
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
        //public void subtotal(TextBox tb, string idcab)
        //{

        //    string server = "Data Source=Leo-PC; Initial Catalog=central; Integrated Security=True";
        //    SqlConnection conectar = new SqlConnection();
        //    SqlDataAdapter adapter = new SqlDataAdapter();
        //    DataTable contenedor = new DataTable();
        //    conectar.ConnectionString = server;
        //    conectar.Open();
        //    string query = "select SUM(Productos.Precio_Venta*Ventas_Detalles.Cantidad_Producto) as SubTotal from Ventas_Detalles inner join Productos on Ventas_Detalles.Id_Producto=Productos.Id_Producto  where Id_Ventas_cabecera='"+idcab+"'";
        //    SqlCommand cmd = new SqlCommand(query, conectar);
        //    try
        //    {
        //        cmd.CommandType = CommandType.Text;
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //           tb.Text=reader.ToString();
        //        }
        //        reader.Close();
        //        cmd.Dispose();
              
                
        //        //cmd.ExecuteNonQuery();
        //        //adapter.SelectCommand = cmd;
        //        //adapter.Fill(contenedor);
        //        //tb.Text = Convert.ToString( contenedor);
             
               
            
            
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("Error" + ex, ToString());
        //        throw;
        //    }
        //    conectar.Close();
        //}
    }
}
